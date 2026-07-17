using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchTool.Data;

namespace SearchTool.Extensions
{
    public static class SearchToolExtension
    {
        public static IServiceCollection AddSearchToolExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SearchToolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SearchTool")));

            return services;
        }
    }
}
