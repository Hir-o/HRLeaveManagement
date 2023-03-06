using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "b60350e5-4590-46a0-bc73-ac0622701602",
                        UserId = "267ba041-9df4-420f-9a79-28adb4c3b623"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "f9ee0337-c75d-4c66-ac4a-569d00252d80",
                        UserId = "82530e3e-9c1c-4a57-b150-fb8c5288afd8"
                    }
                );
        }
    }
}
