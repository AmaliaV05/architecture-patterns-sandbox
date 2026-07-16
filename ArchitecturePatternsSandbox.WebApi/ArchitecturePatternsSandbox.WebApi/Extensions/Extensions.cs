using AdminTool.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ArchitecturePatternsSandbox.WebApi.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAdminToolExtension(configuration);

            return services;
        }

        public static IConfigurationBuilder AddConfigurationExtensions(this IConfigurationBuilder builder, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AdminTool");
            builder.AddSqlConfiguration(
                opt => opt.UseSqlServer(connectionString));

            return builder;
        }
    }
}
