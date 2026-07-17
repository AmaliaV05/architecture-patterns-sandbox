using DataHeavyTool.Data.Enums;

namespace DataHeavyTool.BusinessLogic.Helpers.Pagination
{
    public class TransactionParams : QueryStringParameters
    {
        public TransactionType TransactionType { get; set; }
    }
}
