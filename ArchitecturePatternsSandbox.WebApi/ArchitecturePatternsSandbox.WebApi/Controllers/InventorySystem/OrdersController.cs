using AutoMapper;
using InventorySystem.BusinessLogic.Interfaces;
using InventorySystem.Data.Entities;
using InventorySystem.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.InventorySystem
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Inventory System")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Place-Order")]
        public async Task<IActionResult> PlaceOrderAsync([FromBody] List<OrderDto> items)
        {
            var saleItems = _mapper.Map<List<SaleItem>>(items);
            await _orderService.PlaceOrderAsync(saleItems);

            return Ok(new { Message = "Order placed successfully" });
        }
    }
}
