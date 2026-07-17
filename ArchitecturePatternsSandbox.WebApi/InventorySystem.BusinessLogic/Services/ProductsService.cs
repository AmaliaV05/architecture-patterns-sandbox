using InventorySystem.BusinessLogic.Interfaces;
using InventorySystem.Data.Data;
using InventorySystem.Data.Entities;
using InventorySystem.Data.View;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private InventorySystemDbContext _context;

        public ProductsService(InventorySystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<LowStockProductView>> GetLowStockProductsAsync()
        {
            return await _context.LowStockProducts
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
