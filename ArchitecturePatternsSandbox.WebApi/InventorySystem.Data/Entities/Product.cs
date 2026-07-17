namespace InventorySystem.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        public byte[] RowVersion { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
