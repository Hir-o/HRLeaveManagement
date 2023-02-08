using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Application.Unit.Tests.Mocks;
using HRLeaveManagement.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.Unit.Tests.LeaveTypes.Commands
{
    public class UpdateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly UpdateLeaveTypeCommandHandler _handler;
        private readonly UpdateLeaveTypeDto _leaveType;

        public UpdateLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);
            _leaveType = new UpdateLeaveTypeDto
            {
                Id = 1,
                LeaveName = "Test Changed",
                DefaultDays = 4
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Update()
        {
            var result = await _handler.Handle(new UpdateLeaveTypeCommand() { UpdateLeaveTypeDto = _leaveType }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task Invalid_LeaveType_Update()
        {
            _leaveType.DefaultDays = -1;
            var result = await _handler.Handle(new UpdateLeaveTypeCommand() { UpdateLeaveTypeDto = _leaveType }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThanOrEqualTo(1);
        }
    }
}
