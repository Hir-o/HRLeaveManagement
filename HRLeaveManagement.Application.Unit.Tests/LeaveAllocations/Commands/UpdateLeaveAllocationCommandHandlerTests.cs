using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
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

namespace HRLeaveManagement.Application.Unit.Tests.LeaveAllocations.Commands
{
    public class UpdateLeaveAllocationCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveAllocationRepository> _mockRepo;
        private readonly UpdateLeaveAllocationCommandHandler _handler;
        private UpdateLeaveAllocationDto _leaveAllocationDto;

        public UpdateLeaveAllocationCommandHandlerTests()
        {
            _mockRepo = MockLeaveAllocationRepository.GetLeaveAllocationRepository();

            var mappConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mappConfig.CreateMapper();
            _handler = new UpdateLeaveAllocationCommandHandler(_mockRepo.Object, _mapper);

            _leaveAllocationDto = new UpdateLeaveAllocationDto
            {
                Id = 1,
                NumberOfDays = 25,
                LeaveTypeId = 1,
                Period = 2027
            };
        }

        [Fact]
        public async Task Valid_LeaveAllocation_Update()
        {
            var result = await _handler.Handle(new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = _leaveAllocationDto }, CancellationToken.None);
            
            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task Invalid_LeaveAllocation_Update()
        {
            _leaveAllocationDto.Period = 2022;
            var result = await _handler.Handle(new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = _leaveAllocationDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThanOrEqualTo(1);
        }
    }
}
