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
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId) //same name as above
        {
            var result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }
        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductByCategory(string categoryUrl) //same name as above
        {
            var result = await _productService.GetProductByCategoryAsync(categoryUrl);
            return Ok(result);
        }

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProduct(string searchText, int page=1) //same name as above
        {
            var result = await _productService.SearchProducts(searchText,page);
            return Ok(result);
        }
        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText) //same name as above
        {
            var result = await _productService.GetProductSearchSuggestions(searchText);
            return Ok(result);
        }
        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
        {
            var result = await _productService.GetFeaturedProducts();
            return Ok(result);
        }
    }
}
