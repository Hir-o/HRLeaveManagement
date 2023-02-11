using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
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

namespace HRLeaveManagement.Application.Unit.Tests.LeaveAllocations.Commands
{
    public class CreateLeaveAllocationCommandHandlerTesets
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveAllocationRepository> _mockRepo;
        private readonly CreateLeaveAllocationCommandHandler _handler;
        private readonly CreateLeaveAllocationDto _leaveAllocationDto;

        public CreateLeaveAllocationCommandHandlerTesets()
        {
            _mockRepo = MockLeaveAllocationRepository.GetLeaveAllocationRepository();

            var mappConfig = new MapperConfiguration( c=>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mappConfig.CreateMapper();
            _handler = new CreateLeaveAllocationCommandHandler(_mockRepo.Object, _mapper);

            _leaveAllocationDto = new CreateLeaveAllocationDto
            {
                NumberOfDays = 2,
                LeaveTypeId = 2,
                Period = 2024,
            };
        }

        [Fact]
        public async Task Valid_LeaveAllocation_Added()
        {
            var leaveAllocations = await _mockRepo.Object.GetLeaveAllocationsWithDetails();
            var result = await _handler.Handle(new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = _leaveAllocationDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
            leaveAllocations.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Invalid_LeaveAllocation_Added()
        {
            _leaveAllocationDto.NumberOfDays = -1;
            var leaveAllocations = await _mockRepo.Object.GetLeaveAllocationsWithDetails();
            var result = await _handler.Handle(new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = _leaveAllocationDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThan(0);
            leaveAllocations.Count.ShouldBe(2);
        }
    }
}
