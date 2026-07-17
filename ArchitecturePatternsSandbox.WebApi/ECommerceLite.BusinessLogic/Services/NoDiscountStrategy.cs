using ECommerceLite.BusinessLogic.Interfaces;

namespace ECommerceLite.BusinessLogic.Services
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount;
        }
    }
}
