using BlazorEcommerce.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly DataContext _dataContext;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        public DataContext _context { get; }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProduct() 
        { 
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
    }
}
