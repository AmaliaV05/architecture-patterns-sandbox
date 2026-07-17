using Microsoft.EntityFrameworkCore;
using SearchTool.Data;
using SearchTool.Data.Entities;

namespace SearchTool.Features.SearchProducts
{
    public class SearchProductsQuery
    {
        private readonly SearchToolDbContext _context;

        public SearchProductsQuery(SearchToolDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> GetProductsAsync(string productName, CancellationToken cancellationToken)
        {
            IQueryable<Product> query = _context.Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(productName))
            {
                string searchPattern = $"%{productName}%";
                query = query.Where(p => EF.Functions.Like(p.Name, searchPattern));
            }

            return await query.Take(10).ToListAsync(cancellationToken);
        }
    }
}
