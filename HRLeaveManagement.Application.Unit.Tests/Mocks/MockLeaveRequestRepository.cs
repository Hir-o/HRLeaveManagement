using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Unit.Tests.Mocks
{
    public static class MockLeaveRequestRepository
    {
        public static Mock<ILeaveRequestRepository> GetLeaveRequestRepository()
        {
            var leaveRequests = new List<LeaveRequest>
            {
                new LeaveRequest
                {
                    Id = 1,
                    StartDate = new DateTime(2023, 11, 5),
                    EndDate = new DateTime(2024, 11, 15),
                    LeaveType = new LeaveType
                    {
                        Id = 7,
                        DefaultDays = 7,
                        LeaveName = "Request Leave Test",
                        CreatedBy = "Seed User",
                        LastModifiedBy = "Seed User",
                    },
                    LeaveTypeId = 7,
                    DateRequested = new DateTime(2023, 11, 5),
                    RequestComments = "Request leave comment test.",
                    DateActioned = new DateTime(2023, 11, 5),
                    Cancelled = false
                }
            };

            var mockRepo = new Mock<ILeaveRequestRepository>();
            mockRepo.Setup(m => m.GetLeaveRequestsWithDetails()).ReturnsAsync(leaveRequests);
            mockRepo.Setup(m => m.GetLeaveRequestWithDetails(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                foreach (var leaveRequest in leaveRequests)
                    if (leaveRequest.Id == id)
                        return leaveRequest;
                return null;
            });
            mockRepo.Setup(m => m.Add(It.IsAny<LeaveRequest>())).ReturnsAsync((LeaveRequest leaveRequest) =>
            {
                leaveRequests.Add(leaveRequest);
                return leaveRequest;
            });
            mockRepo.Setup(m => m.Update(It.IsAny<LeaveRequest>()));

            return mockRepo;
        }
    }
}
