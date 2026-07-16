using AdminTool.Infrastructure.Data.Entities;
using AdminTool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdminTool.Features.UpdateSettings
{
    public class UpdateSettingsHandler
    {
        private readonly AdminToolDbContext _context;

        public UpdateSettingsHandler(AdminToolDbContext context)
        {
            _context = context;
        }

        public async Task UpdateSettingsAsync(IList<Setting> settings)
        {
            if (settings == null || !settings.Any())
            {
                throw new ArgumentException("Settings list cannot be null or empty.");
            }

            foreach (var setting in settings)
            {
                await _context.Settings
                    .Where(x => x.Key == setting.Key)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(u => u.Value, setting.Value));
            }
        }
    }
}
