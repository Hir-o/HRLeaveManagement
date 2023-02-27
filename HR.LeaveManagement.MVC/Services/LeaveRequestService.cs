using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        public LeaveRequestService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
        }
    }
}
