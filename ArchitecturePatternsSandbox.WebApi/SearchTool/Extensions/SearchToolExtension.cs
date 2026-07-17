using AdminTool.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchTool.Features.SearchProducts;
using SearchTool.Infrastructure.Data;

namespace SearchTool.Extensions
{
    public static class SearchToolExtension
    {
        public static IServiceCollection AddSearchToolExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<SearchToolMappingProfile>();
            });

            services.AddDbContext<SearchToolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SearchTool")));

            services.AddTransient<SearchProductsQuery>();

            return services;
        }
    }
}
