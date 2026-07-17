using InventorySystem.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventorySystem.Extensions
{
    public static class InventorySystemExtensions
    {
        public static IServiceCollection AddInventorySystemExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventorySystemDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("InventorySystem")));

            return services;
        }
    }
}
