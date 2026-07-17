namespace ECommerceLite.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerEmail { get; set; }

        public override string ToString()
        {
            return $"Order ID: {Id}, Product: {ProductName}, Total Amount: {TotalAmount}, Customer Email: {CustomerEmail}";
        }
    }
}
