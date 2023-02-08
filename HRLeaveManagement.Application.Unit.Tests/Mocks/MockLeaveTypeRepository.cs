using FluentValidation.Results;
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
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    LeaveName = "Annual Leave Test",
                    CreatedBy = "Seed User",
                    LastModifiedBy = "Seed User",
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 5,
                    LeaveName = "Sick Leave Test",
                    CreatedBy = "Seed User",
                    LastModifiedBy = "Seed User",
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(m => m.GetLeaveTypesWithDetails()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(m => m.GetLeaveTypeWithDetails(It.IsAny<int>())).ReturnsAsync((int id) => 
            {
                foreach(var leaveType in leaveTypes)
                    if (leaveType.Id == id) 
                        return leaveType;
                return null;
            });
            mockRepo.Setup(m => m.Update(It.IsAny<LeaveType>()));
            mockRepo.Setup(m => m.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) => 
            {
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            return mockRepo;
        }
    }
}
