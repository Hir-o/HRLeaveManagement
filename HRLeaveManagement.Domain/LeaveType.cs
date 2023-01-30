using HRLeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string LeaveName { get; set; }
        public int DefaultDays { get; set; }
    }
}
