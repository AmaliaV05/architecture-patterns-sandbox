using ECommerceLite.BusinessLogic.Interfaces;
using ECommerceLite.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.ECommerceLite
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("ECommerce Lite")]
    public class ECommerceLiteController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public ECommerceLiteController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Promo/{promoCode}")]
        public IActionResult PlaceOrder([FromBody] Order order, string promoCode)
        {
            var isOrderPlaced = _orderService.PlaceOrder(order, promoCode);

            if (isOrderPlaced)
            {
                return Ok(new { message = "Order placed successfully." });
            }

            return BadRequest(new { message = "Order could not be placed." });
        }
    }
}
