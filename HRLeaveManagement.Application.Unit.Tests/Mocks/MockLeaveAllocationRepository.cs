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
    public static class MockLeaveAllocationRepository
    {
        public static Mock<ILeaveAllocationRepository> GetLeaveAllocationRepository()
        {
            var leaveAllocations = new List<LeaveAllocation>()
            {
                new LeaveAllocation
                {
                    Id = 1,
                    NumberOfDays = 5,
                    LeaveType = new LeaveType
                    {
                        Id = 3,
                        LeaveName = "Personal Leave Test",
                        DefaultDays = 1
                    },
                    LeaveTypeId = 3,
                    Period = 2024,
                    CreatedBy = "Seed User",
                    LastModifiedBy = "Seed User"
                },
                 new LeaveAllocation
                {
                    Id = 2,
                    NumberOfDays = 10,
                    LeaveType = new LeaveType
                    {
                        Id = 4,
                        LeaveName = "Unpaid Leave Test",
                        DefaultDays = 10
                    },
                    LeaveTypeId = 4,
                    Period = 2025,
                    CreatedBy = "Seed User",
                    LastModifiedBy = "Seed User"
                },
            };

            var mockRepo = new Mock<ILeaveAllocationRepository>();
            mockRepo.Setup(m => m.GetLeaveAllocationsWithDetails()).ReturnsAsync(leaveAllocations);
            mockRepo.Setup(m => m.GetLeaveAllocationWithDetails(It.IsAny<int>())).ReturnsAsync((int id) => {
                foreach (var leaveAllocation in leaveAllocations)
                {
                    if (leaveAllocation.Id == id)
                        return leaveAllocation;
                }
                return null;
            });
            mockRepo.Setup(m => m.Update(It.IsAny<LeaveAllocation>()));
            mockRepo.Setup(m => m.Add(It.IsAny<LeaveAllocation>())).ReturnsAsync((LeaveAllocation leaveAllocation) =>
            {
                leaveAllocations.Add(leaveAllocation);
                return leaveAllocation;
            });

            return mockRepo;
        }
    }
}
