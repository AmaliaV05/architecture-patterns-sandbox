using InventorySystem.Data.Entities;

namespace InventorySystem.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(List<SaleItem> items);
    }
}
