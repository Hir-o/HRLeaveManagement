using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDto
    {
        public string LeaveName { get; set; }
        public int DefaultDays { get; set; }
    }
}
