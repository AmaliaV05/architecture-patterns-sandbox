using DataHeavyTool.BusinessLogic.Helpers.Pagination;
using DataHeavyTool.BusinessLogic.Interfaces;
using DataHeavyTool.Data.Data;
using DataHeavyTool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace DataHeavyTool.BusinessLogic.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly DataHeavyToolDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public TransactionsService(DataHeavyToolDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<PagedResult<Transaction>> GetPagedTransactionsAsync(int page, int pageSize)
        {
            string cacheKey = $"transactions_p{page}_s{pageSize}";

            if (!_memoryCache.TryGetValue(cacheKey, out PagedResult<Transaction> cachedResult))
            {
                var query = _context.Transactions.AsNoTracking();

                var totalCount = await query.CountAsync();
                var data = await query
                    .OrderByDescending(t => t.TransactionDate)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                cachedResult = new PagedResult<Transaction>
                {
                    Data = data,
                    TotalCount = totalCount,
                    CurrentPage = page,
                    PageSize = pageSize
                };

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                _memoryCache.Set(cacheKey, cachedResult, cacheOptions);
            }

            return cachedResult;
        }
    }
}
