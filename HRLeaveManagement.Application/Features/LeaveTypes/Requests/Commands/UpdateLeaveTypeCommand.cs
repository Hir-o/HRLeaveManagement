using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public UpdateLeaveTypeDto UpdateLeaveTypeDto { get; set; }
    }
}
