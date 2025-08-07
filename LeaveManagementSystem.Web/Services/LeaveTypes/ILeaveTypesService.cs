using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services.LeaveTypes
{
    public interface ILeaveTypesService
    {
        Task<bool> CheckIfLeaveTypeNameExists(string name);
        Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
        Task CreateLeaveTypeAsync(LeaveTypeCreateVM leaveType);
        Task<bool> DaysExceedMaximum(int leaveTypeId, int days);
        Task DeleteLeaveTypeAsync(int id);
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypesAsync();
        Task<T?> GetLeaveTypeByIdAsync<T>(int id) where T : class;
        bool LeaveTypeExists(int id);
        Task UpdateLeaveTypeAsync(LeaveTypeEditVM leaveTypeEdit);
    }
}