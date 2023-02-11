using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ChangeLeaveRequestApprovalValidator : AbstractValidator<ChangeLeaveRequestApprovalDto>
    {
        private ILeaveRequestRepository _leaveRequestRepository;

        public ChangeLeaveRequestApprovalValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");
        }
    }
}
