using AdminTool.Configuration;
using AdminTool.Features.GetSettings;
using AdminTool.Features.UpdateSettings;
using AdminTool.Infrastructure.Data;
using AdminTool.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminTool.Extensions
{
    public static class AdminToolExtension
    {
        public static IServiceCollection AddAdminToolExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AdminToolMappingProfile>();
            });

            services.AddDbContext<AdminToolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AdminTool")));

            services.Configure<VisualSettings>(configuration.GetSection("VisualSettings"));

            services.AddSingleton<GetSettingsHandler>();
            services.AddTransient<UpdateSettingsHandler>();

            return services;
        }

        public static IConfigurationBuilder AddSqlConfiguration(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> optionsAction)
        {
            return builder.Add(new SqlConfigurationSource(optionsAction));
        }
    }
}
