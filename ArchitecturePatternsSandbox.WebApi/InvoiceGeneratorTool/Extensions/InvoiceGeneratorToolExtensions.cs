using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InvoiceGeneratorTool.Data.Data;

namespace InvoiceGeneratorTool.Extensions
{
    public static class InvoiceGeneratorToolExtensions
    {
        public static IServiceCollection AddInvoiceGeneratorToolExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvoiceGeneratorToolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("InvoiceGeneratorTool")));

            return services;
        }
    }
}
