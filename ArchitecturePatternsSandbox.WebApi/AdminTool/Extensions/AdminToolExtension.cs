using AdminTool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminTool.Extensions
{
    public static class AdminToolExtension
    {
        public static IServiceCollection AddAdminToolExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdminToolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AdminTool")));

            return services;
        }
    }
}
