using AutoMapper;
using LeaveManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LeaveManagementSystem.Application.Services.LeaveTypes
{
    public class LeaveTypesService(ApplicationDbContext context, 
        IMapper mapper,
        ILogger<LeaveTypesService> logger) : ILeaveTypesService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<LeaveTypesService> _logger = logger;
        private const string NameExistsValidationMessage = "Leave Type with this name already exists.";

        public async Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypesAsync()
        {
            var data = await _context.LeaveTypes.ToListAsync();
            return _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
        }
        public async Task<T?> GetLeaveTypeByIdAsync<T>(int id) where T : class
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return null;
            }
            return _mapper.Map<T>(leaveType);
        }

        public async Task CreateLeaveTypeAsync(LeaveTypeCreateVM leaveType)
        {
            _logger.LogInformation("Creating a new leave type with name: {Name} - {NumberOfDays}", leaveType.Name, leaveType.NumberOfDays);
            var leaveTypeEntity = _mapper.Map<LeaveType>(leaveType);
            _context.Add(leaveTypeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLeaveTypeAsync(LeaveTypeEditVM leaveTypeEdit)
        {
            var leaveType = _mapper.Map<LeaveType>(leaveTypeEdit);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLeaveTypeAsync(int id)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
                await _context.SaveChangesAsync();
            }
        }

        public bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        public async Task<bool> CheckIfLeaveTypeNameExists(string name)
        {
            var lowerName = name.Trim().ToLower();
            return await _context.LeaveTypes.AnyAsync(e => e.Name.ToLower().Equals(lowerName));
        }

        public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
        {
            var lowerName = leaveTypeEdit.Name.Trim().ToLower();
            return await _context.LeaveTypes.AnyAsync(e => e.Name.ToLower().Equals(lowerName) && e.Id != leaveTypeEdit.Id);
        }

        public async Task<bool> DaysExceedMaximum(int leaveTypeId, int days)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(leaveTypeId);
            return leaveType.NumberOfDays < days;
        }
    }
}
