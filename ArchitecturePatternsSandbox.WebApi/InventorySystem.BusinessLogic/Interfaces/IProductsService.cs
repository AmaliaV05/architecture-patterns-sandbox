using InventorySystem.Data.Entities;
using InventorySystem.Data.View;

namespace InventorySystem.BusinessLogic.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<LowStockProductView>> GetLowStockProductsAsync();
    }
}
