using AdminTool.Extensions;
using DataHeavyTool.Extensions;
using ECommerceLite.Extensions;
using InventorySystem.Extensions;
using InvoiceGeneratorTool.Extensions;
using Microsoft.EntityFrameworkCore;
using SearchTool.Extensions;
using StatusCheckSystem.Extensions;

namespace ArchitecturePatternsSandbox.WebApi.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAdminToolExtension(configuration);
            services.AddStatusCheckSystemExtension(configuration);
            services.AddECommerceLite(configuration);
            services.AddSearchToolExtension(configuration);
            services.AddDataHeavyToolExtension(configuration);
            services.AddInvoiceGeneratorToolExtension(configuration);
            services.AddInventorySystemExtension(configuration);

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
