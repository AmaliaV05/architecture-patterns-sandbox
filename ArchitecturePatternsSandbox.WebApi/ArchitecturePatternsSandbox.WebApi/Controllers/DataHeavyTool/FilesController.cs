using DataHeavyTool.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.DataHeavyTool
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("DataHeavy Tool")]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadCsvAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            await _fileService.ProcessLargeCsvAsync(file);

            return Ok("File uploaded and processed successfully.");
        }
    }
}
