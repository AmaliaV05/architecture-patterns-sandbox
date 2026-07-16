using AdminTool.Features.GetSettings;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.AdminTool
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Admin Tool")]
    public class SettingsController : ControllerBase
    {
        [HttpGet("Current-Settings")]
        public IActionResult GetSettings([FromServices] GetSettingsHandler handler)
        {
            var settings = handler.GetCurrentSettings();
            return Ok(settings);
        }        
    }
}
