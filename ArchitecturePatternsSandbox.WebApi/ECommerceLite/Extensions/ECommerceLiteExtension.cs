using ECommerceLite.BusinessLogic.Interfaces;
using ECommerceLite.BusinessLogic.Services;
using ECommerceLite.BusinessLogic.Validators;
using ECommerceLite.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceLite.Extensions
{
    public static class ECommerceLiteExtension
    {
        public static IServiceCollection AddECommerceLite(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IValidator<Order>, OrderValidator>();
            services.AddScoped<IFileOrderRepository>(sp => new FileOrderRepository("order-logs.txt"));
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
