using System.Reflection;
using Application.Interfaces;
using Infrastructure.Database;
using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("AppDBContext")));

            services.AddScoped<IReadCSVService, ReadCsvService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}