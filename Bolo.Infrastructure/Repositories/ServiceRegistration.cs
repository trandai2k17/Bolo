using Bolo.Application.Interfaces;
using Bolo.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bolo.Infrastructure.Repositories
{ 
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            //services.AddScoped<DapperDBContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDapperHelper, DapperHelper>();
            //services.AddScoped<IProductionLine, ProductionLineRepository>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
