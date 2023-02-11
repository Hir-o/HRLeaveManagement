using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Application.Unit.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace HRLeaveManagement.Application.Unit.Tests.LeaveRequests.Commands
{
    public class UpdateLeaveRequestCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveRequestRepository> _mockRepo;
        private readonly UpdateLeaveRequestCommandHandler _handler;
        private readonly UpdateLeaveRequestDto _leaveRequest;
        private readonly ChangeLeaveRequestApprovalDto _leaveRequestChange;

        public UpdateLeaveRequestCommandHandlerTests()
        {
            _mockRepo = MockLeaveRequestRepository.GetLeaveRequestRepository();
            var mappConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mappConfig.CreateMapper();
            _handler = new UpdateLeaveRequestCommandHandler(_mockRepo.Object, _mapper);

            _leaveRequest = new UpdateLeaveRequestDto
            {
                Id = 1,
                StartDate = new DateTime(2023, 12, 8),
                EndDate = new DateTime(2024, 1, 4),
                LeaveTypeId = 1,
                RequestComments = "Edited Request leave comment test.",
                Cancelled = false
            };

            _leaveRequestChange = new ChangeLeaveRequestApprovalDto
            {
                Id = 1,
                Approved = false
            };
        }

        [Fact]
        public async Task Valid_LeaveRequest_Update()
        {
            var result = await _handler.Handle(new UpdateLeaveRequestCommand { UpdateLeaveRequestDto = _leaveRequest }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task Invalid_LeaveRequest_Update()
        {
            _leaveRequest.StartDate = new DateTime(2025, 12, 8);
            var result = await _handler.Handle(new UpdateLeaveRequestCommand { UpdateLeaveRequestDto = _leaveRequest}, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Valid_LeaveRequest_ChangeApproval()
        {
            var result = await _handler.Handle(new UpdateLeaveRequestCommand { ChangeLeaveRequestApprovalDto = _leaveRequestChange}, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
        }
    }
}
