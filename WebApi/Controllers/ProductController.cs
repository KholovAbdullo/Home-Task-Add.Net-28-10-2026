using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    private IProductService product = productService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(CreateProductDto productDto)
    {
        return await product.AddProduct(productDto);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(UpdateProductDto productDto)
    {
        return await product.UpdateProduct(productDto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        return await product.DeleteProduct(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ProductDto>> GetProduct(int id)
    {
        return await product.GetProduct(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<ProductDto>>> GetProducts()
    {
        return await product.GetProducts();
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ApiResponse<List<ProductDto>>> GetProductsByCategory(int categoryId)
    {
        return await product.GetProductsByCategory(categoryId);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<ProductStatisticDto>> GetAmountOfProducts()
    {
        return await product.GetAmountOfProducts();
    }

    [HttpGet("amount/category/{categoryId}")]
    public async Task<ApiResponse<ProductStatisticDto>> GetAmountOfProductsByCategory(int categoryId)
    {
        return await product.GetAmountOfProductsByCategory(categoryId);
    }

    [HttpGet("min-price/category/{categoryId}")]
    public async Task<ApiResponse<ProductStatisticDto>> GetMinPriceOfProductByCategory(int categoryId)
    {
        return await product.GetMinPriceOfProductByCategory(categoryId);
    }

    [HttpGet("max-price/category/{categoryId}")]
    public async Task<ApiResponse<ProductStatisticDto>> GetMaxPriceOfProductByCategory(int categoryId)
    {
        return await product.GetMaxPriceOfProductByCategory(categoryId);
    }

    [HttpGet("avg-price/category/{categoryId}")]
    public async Task<ApiResponse<ProductStatisticDto>> GetAveragePriceOfProductByCategory(int categoryId)
    {
        return await product.GetAveragePriceOfProductByCategory(categoryId);
    }

    [HttpGet("totalprice")]
    public async Task<ApiResponse<ProductStatisticDto>> GetTotalPriceOfProducts()
    {
        return await product.GetTotalPriceOfProducts();
    }
}
