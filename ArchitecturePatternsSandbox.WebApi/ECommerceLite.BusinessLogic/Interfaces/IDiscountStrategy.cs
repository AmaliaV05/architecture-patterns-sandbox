namespace ECommerceLite.BusinessLogic.Interfaces
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal totalAmount);
    }
}
