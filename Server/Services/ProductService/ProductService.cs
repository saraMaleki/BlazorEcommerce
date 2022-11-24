using BlazorEcommerce.Server.Data;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _datacontext;

        public ProductService(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _datacontext.Products.FindAsync(productId);
            if (product == null)
            {
                response.message = "Sorry, this product does not exist";
                response.success = false;
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductListAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _datacontext.Products.ToListAsync()

            };
            return response;
        }
    }
}
