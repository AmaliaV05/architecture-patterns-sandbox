using InventorySystem.BusinessLogic.Interfaces;
using InventorySystem.Data.Data;
using InventorySystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly InventorySystemDbContext _context;
        private readonly TimeProvider _timeProvider;

        public OrderService(InventorySystemDbContext context, TimeProvider timeProvider)
        {
            _context = context;
            _timeProvider = timeProvider;
        }

        public async Task PlaceOrderAsync(List<SaleItem> items)
        {
            var productIds = items.Select(i => i.ProductId).ToList();

            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToDictionaryAsync(p => p.Id);

            foreach (var item in items)
            {
                if (products[item.ProductId].Stock >= item.Quantity)
                {
                    item.Product = products[item.ProductId];
                    products[item.ProductId].Stock -= item.Quantity;
                }
                else if (products[item.ProductId].Stock == 0)
                {
                    items.Remove(item);
                }
                else
                {
                    item.Quantity = products[item.ProductId].Stock;
                    item.Product = products[item.ProductId];
                    products[item.ProductId].Stock = 0;
                }
            }

            if (items.Count == 0)
            {
                return;
            }

            try
            {
                var sale = new Sale
                {
                    SaleDate = _timeProvider.GetUtcNow(),
                    TotalAmount = items.Sum(i => i.Quantity * i.Product.Price),
                    SaleItems = items
                };

                _context.Sales.Add(sale);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Product)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = await entry.GetDatabaseValuesAsync();

                        if (databaseValues == null)
                        {
                            Console.WriteLine("Entity was modified by another user.");
                        }
                        else
                        {
                            entry.OriginalValues.SetValues(databaseValues);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
        }
    }
}
