using CsvHelper.Configuration;
using DataHeavyTool.Data.Entities;

namespace DataHeavyTool.BusinessLogic.Helpers
{
    public class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.UserGuid).Name("UserGuid");
            Map(m => m.AssetTicker).Name("AssetTicker");
            Map(m => m.TransactionType).Name("TransactionType");
            Map(m => m.Quantity).Name("Quantity");
            Map(m => m.PricePerUnit).Name("PricePerUnit");
            Map(m => m.TransactionDate).Name("TransactionDate");
            Map(m => m.Fee).Name("Fee");
        }
    }
}
