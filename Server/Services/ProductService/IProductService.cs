

namespace BlazorEcommerce.Server.Services.ProductService
{
    public interface IProductService
    {
       Task<ServiceResponse<List<Product>>> GetProductListAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductByCategoryAsync(string categoryUrl);
        Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);

        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();


    }
}
