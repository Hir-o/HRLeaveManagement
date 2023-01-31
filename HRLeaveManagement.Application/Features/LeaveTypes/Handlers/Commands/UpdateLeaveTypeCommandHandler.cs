using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveType.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveTypeDto);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "LeaveType update failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(validationResult);
            }

            var leaveType = await _leaveTypeRepository.Get(request.UpdateLeaveTypeDto.Id);
            _mapper.Map(request.UpdateLeaveTypeDto, leaveType);
            await _leaveTypeRepository.Update(leaveType);
            response.Message = "LeaveType updated successfully.";
            return response;
        }
    }
}
