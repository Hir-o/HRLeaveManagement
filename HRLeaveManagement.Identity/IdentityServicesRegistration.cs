using HRLeaveManagement.Application.Contracts.Identity;
using HRLeaveManagement.Identity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
    }
}
