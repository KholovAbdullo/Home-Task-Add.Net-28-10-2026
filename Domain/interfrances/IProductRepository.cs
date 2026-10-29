using Domain.Models;

namespace Domain.interfrances;

public interface IProductRepository
{
    Task AddProduct(Product products);
    Task UpdateProduct(Product products);
    Task DeleteProduct(int id);
    Task<Product> GetProduct(int id);
    Task<List<Product>> GetProducts();
    Task<List<Product>> GetProductsByCategory(string name);
    Task<List<Product>> GetProductsByCategory(int categoryId);
    Task<int> GetAmountOfProducts();
    Task<int> GetAmountOfProductsByCategory(int categoryId);
    Task<decimal> GetMinPriceOfProductByCategory(int categoryId);
    Task<decimal> GetMaxPriceOfProductByCategory(int categoryId);
    Task<decimal> GetAveragePriceOfProductByCategory(int categoryId);
    Task<decimal> GetTotalPriceOfProducts();
}
