using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<LeaveTypeVM> GetLeaveTypeWithDetails(int id);
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task UpdateLeaveType(LeaveTypeVM leaveType);
        Task DeleteLeaveType(LeaveTypeVM leaveType);
        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType);
    }
}
