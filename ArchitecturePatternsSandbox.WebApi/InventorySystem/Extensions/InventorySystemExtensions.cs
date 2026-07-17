using InventorySystem.BusinessLogic.Interfaces;
using InventorySystem.BusinessLogic.Services;
using InventorySystem.Data.Data;
using InventorySystem.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventorySystem.Extensions
{
    public static class InventorySystemExtensions
    {
        public static IServiceCollection AddInventorySystemExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<InventorySystemMappingProfile>();
            });

            services.AddDbContext<InventorySystemDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("InventorySystem")));

            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IOrderService, OrderService>();

            return services;
        }
    }
}
