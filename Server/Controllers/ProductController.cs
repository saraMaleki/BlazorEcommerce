using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Server.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public DataContext _context { get; }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
        {
            var result = await _productService.GetProductListAsync();
            return Ok(result);
        }

        //[HttpGet]
        //[Route("{id}")]
        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId) //same name as above
        {
            var result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }
    }
}
