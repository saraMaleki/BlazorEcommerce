using BlazorEcommerce.Server.Data;

namespace BlazorEcommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _datacontext;
        public CategoryService(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var response = new ServiceResponse<List<Category>>()
            {
                Data = await _datacontext.Categories.ToListAsync()

            };
            return response;
        }
    }
}
