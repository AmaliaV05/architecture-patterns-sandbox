using ECommerceLite.BusinessLogic.Interfaces;

namespace ECommerceLite.BusinessLogic.Services
{
    public class BlackFridayStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount *= 0.5m;
        }
    }
}
