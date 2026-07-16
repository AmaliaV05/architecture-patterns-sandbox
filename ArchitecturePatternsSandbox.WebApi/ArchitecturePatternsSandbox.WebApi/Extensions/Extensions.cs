using AdminTool.Extensions;

namespace ArchitecturePatternsSandbox.WebApi.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAdminToolExtension(configuration);

            return services;
        }
    }
}
