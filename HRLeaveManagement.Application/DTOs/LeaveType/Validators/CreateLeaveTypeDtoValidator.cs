using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            RuleFor(x => x.LeaveName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} must not be null.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(x => x.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be minimum {ComparisonValue} day.")
                .LessThan(30).WithMessage("{PropertyName} must be less than {ComparisonValue} days.");
        }
    }
}
