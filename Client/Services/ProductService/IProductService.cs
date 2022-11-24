namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        public List<Product> products { get; set; }

        Task GetProducts();

        Task<ServiceResponse<Product>> GetProductAsync(int productId);
    }
}
