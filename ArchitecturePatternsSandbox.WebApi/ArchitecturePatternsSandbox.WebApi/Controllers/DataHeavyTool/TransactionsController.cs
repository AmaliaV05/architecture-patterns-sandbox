using DataHeavyTool.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.DataHeavyTool
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("DataHeavy Tool")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet("Page/{page}/PageSize/{pageSize}")]
        public async Task<IActionResult> Get(int page, int pageSize)
        {
            var result = await _transactionsService.GetPagedTransactionsAsync(page, pageSize);

            return Ok(result);
        }
    }
}
