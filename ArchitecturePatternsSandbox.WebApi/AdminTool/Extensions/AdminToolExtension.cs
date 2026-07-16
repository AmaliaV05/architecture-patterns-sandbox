using AdminTool.Configuration;
using AdminTool.Features.GetSettings;
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

            services.Configure<VisualSettings>(configuration.GetSection("VisualSettings"));

            services.AddTransient<GetSettingsHandler>();

            return services;
        }

        public static IConfigurationBuilder AddSqlConfiguration(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> optionsAction)
        {
            return builder.Add(new SqlConfigurationSource(optionsAction));
        }
    }
}
