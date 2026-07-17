using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StatusCheckSystem.BusinessLayer.Interfaces;
using StatusCheckSystem.BusinessLayer.Services;
using StatusCheckSystem.Data.Data;
using StatusCheckSystem.Helpers;

namespace StatusCheckSystem.Extensions
{
    public static class StatusCheckSystemExtension
    {
        public static IServiceCollection AddStatusCheckSystemExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<StatusCheckSystemMappingProfile>();
            });

            services.AddDbContext<StatusCheckSystemDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StatusCheckSystem")));

            services.AddHttpClient();

            services.AddTransient<IVerificationService, VerificationService>();

            return services;
        }
    }
}
