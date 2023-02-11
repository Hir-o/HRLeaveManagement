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
    public class GetLeaveAllocationListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private Mock<ILeaveAllocationRepository> _mockRepo;

        public GetLeaveAllocationListRequestHandlerTests()
        {
            _mockRepo = MockLeaveAllocationRepository.GetLeaveAllocationRepository();

            var mappConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mappConfig.CreateMapper();
        }

        [Fact]
        public async Task Get_Valid_Leave_Allocation_List()
        {
            var handler = new GetLeaveAllocationListRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetLeaveAllocationListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveAllocationDto>>();
            result.Count.ShouldBe(2);
            result.ForEach(e =>
            {
                e.LeaveType.ShouldNotBeNull();
            });
        }
    }
}
