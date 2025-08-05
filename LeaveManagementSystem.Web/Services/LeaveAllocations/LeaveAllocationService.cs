
using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public class LeaveAllocationService(ApplicationDbContext _context, 
        IHttpContextAccessor _httpContextAccessor,
        UserManager<ApplicationUser> _userManager,
        IMapper _mapper) : ILeaveAllocationService
    {
        public async Task AllocateLeave(string employeeId)
        {
            var leaveTypes = await _context.LeaveTypes
                .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId))
                .ToListAsync();

            // get the current period based on the year
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
            // calculate leave based on number of months left in period
            var monthsLeft = period.EndDate.Month - currentDate.Month;

            foreach (var leaveType in leaveTypes)
            {
                // Works but not best practive
                //var allocationExists = await AllocationExists(employeeId, period.Id, leaveType.Id);
                //if(allocationExists)
                //{
                //    continue; // skip if allocation already exists
                //}
                var accrualRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var allocation = new LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    NumberOfDays = (int)Math.Ceiling(accrualRate * monthsLeft),
                    PeriodId = period.Id
                };
                // add the allocation to the context
                _context.LeaveAllocations.Add(allocation);

            }

            await _context.SaveChangesAsync();

        }

        public async Task<List<LeaveAllocation>> GetAllocations(string? userID)
        {
            //string employeeId = string.Empty;
            //if(!string.IsNullOrEmpty(userID))
            //{
            //    employeeId = userID;
            //}
            //else
            //{
            //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            //    employeeId = user.Id;
            //}
            var currentDate = DateTime.Now;
            //var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
            // get all allocations for the employee
            var allocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Period)
                .Where(q => q.EmployeeId == userID && q.Period.EndDate.Year == currentDate.Year)
                .ToListAsync();
            return allocations;
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
        {
            var user = string.IsNullOrEmpty(userId) 
                ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User) 
                : await _userManager.FindByIdAsync(userId);
            var allocations = await GetAllocations(user.Id);
            var allocationVMList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
            var leaveTypesCount = await _context.LeaveTypes.CountAsync();

            var employeeVM = new EmployeeAllocationVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                LeaveAllocations = allocationVMList,
                IsCompletedAllocation = allocations.Count == leaveTypesCount
            };

            return employeeVM;
        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());

            return employees;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
                   .Include(q => q.LeaveType)
                   .Include(q => q.Employee)
                   .FirstOrDefaultAsync(q => q.Id == allocationId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);

            return model;
        }

        public async Task EditAllocation(LeaveAllocationVM allocationEditVm)
        {
            //var leaveAllocation = await GetEmployeeAllocation(allocationEditVm.Id);
            //if (leaveAllocation == null)
            //{
            //    throw new Exception("Leave allocation record does not exist.");
            //}
            //leaveAllocation.Days = allocationEditVm.Days;
            // option 1 _context.Update(leaveAllocation);
            // option 2 _context.Entry(leaveAllocation).State = EntityState.Modified;
            // await _context.SaveChangesAsync();

            await _context.LeaveAllocations
                .Where(q => q.Id == allocationEditVm.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(e => e.NumberOfDays, allocationEditVm.NumberOfDays));
        }
        private async Task<bool> AllocationExists(string userId, int periodId, int leaveTypeId)
        {
            return await _context.LeaveAllocations
                .AnyAsync(q => q.EmployeeId == userId 
                && q.PeriodId == periodId 
                && q.LeaveTypeId == leaveTypeId);
        }
    }
}
