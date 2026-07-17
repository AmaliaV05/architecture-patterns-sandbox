namespace InventorySystem.Data.Entities
{
    public class SaleItem
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}
