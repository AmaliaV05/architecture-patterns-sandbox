using AutoMapper;
using InventorySystem.BusinessLogic.Interfaces;
using InventorySystem.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.InventorySystem
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Inventory System")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Get-All-Products")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productsService.GetProductsAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return Ok(productsDto);
        }

        [HttpGet]
        [Route("Get-Low-Stock-Products")]
        public async Task<IActionResult> GetLowStockProductsAsync()
        {
            var products = await _productsService.GetLowStockProductsAsync();

            var productsDto = products.Select(p => new LowStockProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                MinStock = p.MinStock,
            }).ToList();

            return Ok(productsDto);
        }
    }
}
