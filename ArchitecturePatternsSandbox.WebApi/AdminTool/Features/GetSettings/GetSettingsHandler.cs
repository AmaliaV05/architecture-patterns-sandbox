using AdminTool.Configuration;
using Microsoft.Extensions.Options;

namespace AdminTool.Features.GetSettings
{
    public class GetSettingsHandler
    {
        private readonly IOptionsMonitor<VisualSettings> _options;

        public GetSettingsHandler(IOptionsMonitor<VisualSettings> options)
        {
            _options = options;
        }

        public VisualSettings GetCurrentSettings()
        {
            return _options.CurrentValue;
        }
    }
}
