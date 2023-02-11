using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
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

namespace HRLeaveManagement.Application.Unit.Tests.LeaveRequests.Queries
{
    public class GetLeaveRequestListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveRequestRepository> _mockRepo;

        public GetLeaveRequestListRequestHandlerTests()
        {
            _mockRepo = MockLeaveRequestRepository.GetLeaveRequestRepository();
            var mappConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mappConfig.CreateMapper();
        }

        [Fact]
        public async Task Get_LeaveRequest_List()
        {
            //todo
            var handler = new GetLeaveRequestListRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetLeaveRequestListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveRequestListDto>>();
            result.Count.ShouldBeGreaterThan(0);
        }
    }
}
