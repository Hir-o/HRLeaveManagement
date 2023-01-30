using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<UpdateLeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");

            RuleFor(x => x.LeaveName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} must not be null.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
