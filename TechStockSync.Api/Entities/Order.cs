namespace TechStockSync.Api.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int WooCommerceOrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? InvoicePath { get; set; }

        public Customer Customer { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
