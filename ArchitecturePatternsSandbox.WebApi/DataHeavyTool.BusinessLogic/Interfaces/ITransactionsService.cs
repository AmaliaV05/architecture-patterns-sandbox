using DataHeavyTool.BusinessLogic.Helpers.Pagination;
using DataHeavyTool.Data.Entities;

namespace DataHeavyTool.BusinessLogic.Interfaces
{
    public interface ITransactionsService
    {
        Task<PagedResult<Transaction>> GetPagedTransactionsAsync(int page, int pageSize);
    }
}
