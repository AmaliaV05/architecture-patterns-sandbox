using AdminTool.Features.Common;
using AdminTool.Features.GetSettings;
using AdminTool.Features.UpdateSettings;
using AdminTool.Infrastructure.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.AdminTool
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Admin Tool")]
    public class SettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public SettingsController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet("Current-Settings")]
        public IActionResult GetSettings([FromServices] GetSettingsHandler handler)
        {
            var settings = handler.GetCurrentSettings();
            return Ok(settings);
        }

        [HttpPut("Update-Settings")]
        public async Task<IActionResult> UpdateSetting([FromBody] IList<SettingDto> settingDtos, [FromServices] UpdateSettingsHandler handler)
        {
            var settings = _mapper.Map<IList<Setting>>(settingDtos);
            await handler.UpdateSettingsAsync(settings);

            return NoContent();
        }

        [HttpPost("Refresh-Settings")]
        public IActionResult RefreshSettings([FromServices] GetSettingsHandler handler)
        {
            var root = (IConfigurationRoot)_configuration;
            root.Reload();

            var settings = handler.GetCurrentSettings();
            return Ok(settings);
        }
    }
}
