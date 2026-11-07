using Domain.Models;

namespace Domain.interfrances;

public interface IProductRepository
{
    Task<bool> AddProduct(Product products);
    Task<bool> UpdateProduct(Product products);
    Task<bool> DeleteProduct(int id);
    Task<Product> GetProduct(int id);
    Task<List<Product>> GetProducts();
}
