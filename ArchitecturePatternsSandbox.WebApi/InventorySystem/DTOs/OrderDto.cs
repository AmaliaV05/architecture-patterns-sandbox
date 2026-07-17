namespace InventorySystem.DTOs
{
    public class OrderDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderProductDto Product { get; set; }
    }
}
