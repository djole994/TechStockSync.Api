namespace TechStockSync.Api.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
