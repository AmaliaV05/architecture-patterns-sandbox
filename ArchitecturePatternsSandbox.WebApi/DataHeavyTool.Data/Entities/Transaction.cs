using DataHeavyTool.Data.Enums;

namespace DataHeavyTool.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public string AssetTicker { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public decimal Fee { get; set; }
    }
}
