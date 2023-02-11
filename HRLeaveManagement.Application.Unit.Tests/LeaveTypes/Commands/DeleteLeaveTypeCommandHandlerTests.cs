using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Application.Unit.Tests.Mocks;
using HRLeaveManagement.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.Unit.Tests.LeaveTypes.Commands
{
    public class DeleteLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly DeleteLeaveTypeCommandHandler _handler;
        private int _leaveTypeId = 1;

        public DeleteLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteLeaveTypeCommandHandler(_mockRepo.Object, _mapper);;
        }

        [Fact]
        public async Task Valid_LeaveType_Delete()
        {
            var result = await _handler.Handle(new DeleteLeaveTypeCommand() { Id = _leaveTypeId }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            //result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task Invalid_LeaveType_Delete()
        {
            _leaveTypeId = -1;
            var result = await _handler.Handle(new DeleteLeaveTypeCommand() { Id = _leaveTypeId }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
        }
    }
}
