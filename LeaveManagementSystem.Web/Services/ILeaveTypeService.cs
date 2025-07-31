using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services
{
    public interface ILeaveTypeService
    {
        Task<bool> CheckIfLeaveTypeNameExists(string name);
        Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
        Task CreateLeaveTypeAsync(LeaveTypeCreateVM leaveType);
        Task DeleteLeaveTypeAsync(int id);
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypesAsync();
        Task<T?> GetLeaveTypeByIdAsync<T>(int id) where T : class;
        bool LeaveTypeExists(int id);
        Task UpdateLeaveTypeAsync(LeaveTypeEditVM leaveTypeEdit);
    }
}