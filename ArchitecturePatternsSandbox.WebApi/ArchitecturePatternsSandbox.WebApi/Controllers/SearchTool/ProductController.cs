using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SearchTool.Features.SearchProducts;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.SearchTool
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Search Tool")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync(
            [FromQuery] string productName, 
            [FromServices] SearchProductsQuery query, 
            CancellationToken cancellationToken)
        {
            var products = await query.GetProductsAsync(productName, cancellationToken);

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return Ok(productsDto);
        }
    }
}
