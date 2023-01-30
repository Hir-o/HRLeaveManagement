using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public UpdateLeaveRequestDtoValidator()
        {
            Include(new ILeaveRequestDtoValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");
        }
    }
}
