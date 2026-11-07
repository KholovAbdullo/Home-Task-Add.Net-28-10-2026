using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProduct(Product products);
    Task<ApiResponse<bool>> UpdateProduct(Product products);
    Task<ApiResponse<bool>> DeleteProduct(int id);
    Task<ApiResponse<Product>> GetProduct(int id);
    Task<ApiResponse<List<Product>>> GetProducts();
}
