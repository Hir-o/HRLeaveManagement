using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    LeaveName = "Annual Leave",
                    CreatedBy = "Seed User",
                    LastModifiedBy = "Seed User",
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 5,
                    LeaveName = "Sick Leave",
                    CreatedBy = "Seed User",
                    LastModifiedBy = "Seed User",
                }
             );
        }
    }
}
