using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class LeaveAllocationDtoValidator : AbstractValidator<LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public LeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;

            RuleFor(x => x.Id)
             .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");

            RuleFor(x => x.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than {ComparisonValue}");

            RuleFor(x => x.Period)
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than {ComparisonValue}");

            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
            .MustAsync(async (id, token) =>
            {
                    var leaveTypeExists = await _leaveAllocationRepository.Exists(id);
                    return !leaveTypeExists;
                }).WithMessage("{PropertyNAme} does not exist.");
        }
    }
}
}
