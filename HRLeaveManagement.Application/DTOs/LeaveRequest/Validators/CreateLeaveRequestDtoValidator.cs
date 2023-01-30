using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.StartDate)
                .NotNull()
                .LessThan(x => x.EndDate).WithMessage("{PropertyName} must be less than the {ComparisonValue}.");
            RuleFor(x => x.EndDate)
                .NotNull()
                .GreaterThan(x => x.EndDate).WithMessage("{PropertyName} must be greater than the {ComparisonValue}.");

            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return !leaveTypeExists;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(x => x.RequestComments)
                .NotNull()
                .MaximumLength(256).WithMessage("{PropertyName} must not exceed 256 characters.");
        }
    }
}
