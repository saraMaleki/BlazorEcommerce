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

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>{ 
            Data = await _datacontext.Products
            .Where(p=>p.Featured==true)
            .Include(p=>p.Variants)
            .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _datacontext.Products
                .Include(p=>p.Variants)
                .ThenInclude(v=>v.ProductType)
                .FirstOrDefaultAsync(p=>p.Id==productId);
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

        public async Task<ServiceResponse<List<Product>>> GetProductByCategoryAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>() {
                Data = await _datacontext.Products
            .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
            .Include(p => p.Variants)
            .ToListAsync()
            };
            return response; 

        }

        public async Task<ServiceResponse<List<Product>>> GetProductListAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _datacontext.Products
                .Include(p=>p.Variants).ToListAsync()

            };
            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductBySearch(searchText);
            List<string> suggestions = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                { 
                suggestions.Add(product.Title);
                }
                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !suggestions.Contains(word))
                        {
                            suggestions.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>>
            {
                Data = suggestions
            };
        }

        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductBySearch(searchText)).Count / pageResults);
            var products = await _datacontext.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                                    p.Description.ToLower().Contains(searchText.ToLower()))
                                .Include(p => p.Variants)
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };
            return response;

        }

        private async Task<List<Product>> FindProductBySearch(string searchText)
        {
            return await _datacontext.Products
                            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            || p.Description.ToLower().Contains(searchText.ToLower()))
                            .Include(v => v.Variants).ToListAsync();
        }
    }
}
