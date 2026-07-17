namespace InventorySystem.Data.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTimeOffset SaleDate { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public List<Product> Products { get; set; }
    }
}
