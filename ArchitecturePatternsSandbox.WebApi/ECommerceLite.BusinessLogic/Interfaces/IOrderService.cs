using ECommerceLite.Data.Entities;

namespace ECommerceLite.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        public bool PlaceOrder(Order order, string promoCode);
    }
}
