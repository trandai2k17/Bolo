using Bolo.Application.Interfaces;
using Bolo.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Bolo.Infrastructure.Repositories
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(db => new SqlConnection(
                configuration.GetConnectionString("MyDB1021Conn")));
            
            services.AddTransient<IDbConnection>(db => new SqlConnection(
                configuration.GetConnectionString("AW2019Conn")));

            //services.AddScoped<DapperDBContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDapperHelper, DapperHelper>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IProductionLine, ProductionLineRepository>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
