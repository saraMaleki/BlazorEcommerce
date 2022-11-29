﻿namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action  ProductChanged;
        public List<Product> products { get; set; }

        string Message { get; set; }
        string LastSearchText { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }

        Task GetProducts(string? categoryUrl=null);

        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task SearchProducts(string searchText,int page);

        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
