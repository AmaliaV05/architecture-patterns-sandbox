using DataHeavyTool.BusinessLogic.Interfaces;
using DataHeavyTool.BusinessLogic.Services;
using DataHeavyTool.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataHeavyTool.Extensions
{
    public static class DataHeavyToolExtensions
    {
        public static IServiceCollection AddDataHeavyToolExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataHeavyToolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DataHeavyTool")));

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITransactionsService, TransactionsService>();

            return services;
        }
    }
}
