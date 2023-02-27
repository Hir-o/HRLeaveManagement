using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public LeaveTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(localStorageService, httpClient)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLeaveType(LeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypeVM> GetLeaveTypeWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLeaveType(LeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }
    }
}
