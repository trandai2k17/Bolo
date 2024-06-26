using Bolo.Application.Interfaces;
using Bolo.Infrastructure.Auth.DbContext;
using Bolo.Infrastructure.Auth.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Bolo.Infrastructure.Auth
{
    public static class ServiceRegistration
    {
        public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbcontext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyDB1021Conn")));
        }
        public static void AddIdentityAuth(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            })
                    .AddEntityFrameworkStores<AppIdentityDbcontext>()
                    .AddDefaultTokenProviders();
        }
        public static void AddInfrastructureIdentity(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
