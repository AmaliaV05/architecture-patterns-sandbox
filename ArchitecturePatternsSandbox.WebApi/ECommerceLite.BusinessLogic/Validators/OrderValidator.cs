using ECommerceLite.BusinessLogic.Interfaces;
using ECommerceLite.Data.Entities;

namespace ECommerceLite.BusinessLogic.Validators
{
    public class OrderValidator : IValidator<Order>
    {
        public bool Validate(Order entity)
        {
            if (string.IsNullOrWhiteSpace(entity.ProductName) || string.IsNullOrWhiteSpace(entity.CustomerEmail))
            {
                return false;
            }

            return true;
        }
    }
}
