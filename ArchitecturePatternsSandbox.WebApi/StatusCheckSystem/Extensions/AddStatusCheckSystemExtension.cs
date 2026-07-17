using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StatusCheckSystem.Data.Data;

namespace StatusCheckSystem.Extensions
{
    public static class StatusCheckSystemExtension
    {
        public static IServiceCollection AddStatusCheckSystemExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StatusCheckSystemDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StatusCheckSystem")));

            return services;
        }
    }
}
