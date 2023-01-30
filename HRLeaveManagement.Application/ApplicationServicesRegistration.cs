using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        //dependency injection
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            //for one automapper MappingProfile object we can simply do this: services.AddAutoMapper(typeof(MappingProfile));
            //the Assembly.GetExecutingAssembly() iterates through every class that extends the Profile base class
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
