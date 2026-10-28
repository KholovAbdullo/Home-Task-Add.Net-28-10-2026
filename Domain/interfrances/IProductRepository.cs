using Domain.Models;

namespace Domain.interfrances;

public interface IProductRepository
{
    void AddProduct(Product products);
    void UpdateProduct(Product products);
    void DeleteProduct(int id);
    Product GetProduct(int id);
    List<Product> GetProducts();
    List<Product> GetProductsByCategory(string name);
    List<Product> GetProductsByCategory(int categoryId);
    int GetAmountOfProducts();
    int GetAmountOfProductsByCategory(int categoryId);
    decimal GetMinPriceOfProductByCategory(int categoryId);
    decimal GetMaxPriceOfProductByCategory(int categoryId);
    decimal GetAveragePriceOfProductByCategory(int categoryId);
    decimal GetTotalPriceOfProducts();
}
