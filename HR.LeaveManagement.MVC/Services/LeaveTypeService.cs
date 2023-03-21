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

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDto createLEaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(leaveType);
                AddBearerToken();
                var apiResponse = await _client.LeaveTypePOSTAsync(createLEaveTypeDto);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach(var error in apiResponse.Errors)
                        response.ValidationErrors += error + Environment.NewLine;
                }
                return response;
            }catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                AddBearerToken();
                await _client.LeaveTypeDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            AddBearerToken();
            var leaveTypes = await _client.LeaveTypeAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<LeaveTypeVM> GetLeaveTypeWithDetails(int id)
        {
            AddBearerToken();
            var leaveType = await _client.LeaveTypeGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                UpdateLeaveTypeDto leaveTypeDto = _mapper.Map<UpdateLeaveTypeDto>(leaveType);
                AddBearerToken();
                await _client.LeaveTypePUTAsync(leaveTypeDto);
                return new Response<int>() { Success = true };
            } catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
