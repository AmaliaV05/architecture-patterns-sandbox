namespace InvoiceGeneratorTool.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
