using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString"))
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<LeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            return services;
        }
    }

    public class LeaveManagementDbContextFactory : IDesignTimeDbContextFactory<LeaveManagementDbContext>
    {
        public LeaveManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LeaveManagementDbContext>();
            var connectionString = configuration.GetConnectionString("LeaveManagementConnectionString");
            builder.UseSqlServer(connectionString);
            return new LeaveManagementDbContext(builder.Options);
        }
    }
}
