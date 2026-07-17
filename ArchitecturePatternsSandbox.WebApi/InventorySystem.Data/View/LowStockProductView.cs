namespace InventorySystem.Data.View
{
    public class LowStockProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
    }
}
