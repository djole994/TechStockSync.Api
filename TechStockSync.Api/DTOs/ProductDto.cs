namespace TechStockSync.Api.DTOs
{
    public class ProductDto
    {
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty; 
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
