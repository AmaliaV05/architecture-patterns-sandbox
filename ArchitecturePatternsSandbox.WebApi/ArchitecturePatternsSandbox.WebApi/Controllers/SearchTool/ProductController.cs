using Microsoft.AspNetCore.Mvc;
using SearchTool.Features.SearchProducts;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.SearchTool
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Search Tool")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync(
            [FromQuery] string productName, 
            [FromServices] SearchProductsQuery query, 
            CancellationToken cancellationToken)
        {
            var products = await query.GetProductsAsync(productName, cancellationToken);

            return Ok(products);
        }
    }
}
