namespace InvoiceGeneratorTool.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Credit { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
