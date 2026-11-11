using Application.DTOs;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProduct(CreateProductDto productDto);
    Task<ApiResponse<bool>> UpdateProduct(UpdateProductDto productDto);
    Task<ApiResponse<bool>> DeleteProduct(int id);
    Task<ApiResponse<ProductDto>> GetProduct(int id);
    Task<ApiResponse<List<ProductDto>>> GetProducts();
    Task<ApiResponse<List<ProductDto>>> GetProductsByCategory(int categoryId);
    Task<ApiResponse<ProductStatisticDto>> GetAmountOfProducts();
    Task<ApiResponse<ProductStatisticDto>> GetAmountOfProductsByCategory(int categoryId);
    Task<ApiResponse<ProductStatisticDto>> GetMinPriceOfProductByCategory(int categoryId);
    Task<ApiResponse<ProductStatisticDto>> GetMaxPriceOfProductByCategory(int categoryId);
    Task<ApiResponse<ProductStatisticDto>> GetAveragePriceOfProductByCategory(int categoryId);
    Task<ApiResponse<ProductStatisticDto>> GetTotalPriceOfProducts();
}
