using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStockSync.Api.Data;
using TechStockSync.Api.DTOs;

namespace TechStockSync.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly TechStockDbContext _context;

        public ProductsController(TechStockDbContext context)
        {
            _context = context;
        }

        //

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductDto 
                {
                    Sku = p.Sku,
                    Name = p.Name,
                    CategoryName = p.Category.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity
                })
                .ToListAsync();

            return Ok(products);
        }
    }
}
