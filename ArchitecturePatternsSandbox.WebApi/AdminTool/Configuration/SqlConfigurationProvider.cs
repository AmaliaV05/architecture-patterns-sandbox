using AdminTool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AdminTool.Configuration
{
    public class SqlConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction) : ConfigurationProvider
    {
        public override void Load()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdminToolDbContext>();
            optionsAction(optionsBuilder);

            using (var context = new AdminToolDbContext(optionsBuilder.Options))
            {
                var pendingMigrations = context.Database.GetPendingMigrations();
                if (pendingMigrations.Any())
                {
                    context.Database.Migrate();
                }

                Data = context.Settings.ToDictionary(
                    s => s.Key,
                    s => s.Value,
                    StringComparer.OrdinalIgnoreCase);
            }

            OnReload();
        }
    }
}
