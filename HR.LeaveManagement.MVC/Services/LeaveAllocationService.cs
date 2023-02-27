using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        public LeaveAllocationService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
        }
    }
}
