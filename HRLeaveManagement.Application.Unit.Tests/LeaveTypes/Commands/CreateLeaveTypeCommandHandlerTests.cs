using AutoMapper;
using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Application.Unit.Tests.Mocks;
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
    public class CreateLeaveTypeCommandHandlerTests
    {
        private IMapper _mapper;
        private Mock<ILeaveTypeRepository> _mockRepo;
        private readonly CreateLeaveTypeDto _leaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);
            _leaveTypeDto = new CreateLeaveTypeDto
            {
                DefaultDays = 5,
                LeaveName = "New Leave Name Test"
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            var result = await _handler.Handle(new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _leaveTypeDto }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetLeaveTypesWithDetails();
            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_LeaveType_Added()
        {
            _leaveTypeDto.DefaultDays = -1;
            ValidationException ex = await Should.ThrowAsync<ValidationException>
                (async () =>
                    await _handler.Handle(new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _leaveTypeDto }, CancellationToken.None)
                );

            var leaveTypes = await _mockRepo.Object.GetLeaveTypesWithDetails();
            leaveTypes.Count.ShouldBe(2);
        }
    }
}
