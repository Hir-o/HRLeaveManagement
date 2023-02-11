using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.Unit.Tests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.Unit.Tests.LeaveAllocations.Queries
{
    public class GetLeaveAllocationDetailRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveAllocationRepository> _mockRepo;
        private int _leaveAllocationId = 1;

        public GetLeaveAllocationDetailRequestHandlerTests()
        {
            _mockRepo = MockLeaveAllocationRepository.GetLeaveAllocationRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Get_Valid_LeaveAllocation_Detail()
        {
            var handler = new GetLeaveAllocationDetailRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetLeaveAllocationDetailRequest { Id = _leaveAllocationId }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.LeaveType.ShouldNotBeNull();
            result.ShouldBeOfType<LeaveAllocationDto>();
        }
    }
}
