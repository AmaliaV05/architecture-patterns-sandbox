namespace InvoiceGeneratorTool.Data.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTimeOffset Date { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
        public Client Client { get; set; }
    }
}
