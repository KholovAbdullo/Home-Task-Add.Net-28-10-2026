using Application.DTOs;
using Application.DTOs.Product;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService,ILogger<IProductService> logger) : ControllerBase
{
    private IProductService product = productService;

    private ILogger<IProductService> loggerservic = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(CreateProductDto productDto)
    {
        loggerservic.LogInformation("Added new Product!");
        var res = await product.AddProduct(productDto);
        loggerservic.LogInformation("Product added successfully!");
        return res;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(UpdateProductDto productDto)
    {
        loggerservic.LogInformation("Updating product!");
        var res = await product.UpdateProduct(productDto);
        loggerservic.LogInformation("Product updated successfully!");
        return res;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        loggerservic.LogInformation("Delete product ID: {id}",id);
        var res = await product.DeleteProduct(id);
        loggerservic.LogInformation("Product ID:{id} delete successfully!",id);
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ProductDto>> GetProduct(int id)
    {
        loggerservic.LogInformation("Getting product for ID: {Id}",id);
        return await product.GetProduct(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<ProductDto>>> GetProducts()
    {
        loggerservic.LogInformation("Retrieving all products!");
        return await product.GetProducts();
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ApiResponse<List<ProductDto>>> GetProductsByCategory(int categoryId)
    {
        loggerservic.LogInformation("Retrieving products for category ID: {CategoryId}", categoryId);
        return await product.GetProductsByCategory(categoryId);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<ProductStatisticDto>> GetAmountOfProducts()
    {
        loggerservic.LogInformation("Retrieving total amount of products!");
        return await product.GetAmountOfProducts();
    }

    [HttpGet("amount/category/{categoryId}")]
    public async Task<ApiResponse<ProductStatisticDto>> GetAmountOfProductsByCategory(int categoryId)
    {
        loggerservic.LogInformation("Retrieving total amount of products for category ID: {CategoryId}", categoryId);
        return await product.GetAmountOfProductsByCategory(categoryId);
    }

    [HttpGet("min-price/category/{categoryId}")]
    public async Task<ApiResponse<ProductStatisticDto>> GetMinPriceOfProductByCategory(int categoryId)
    {
        loggerservic.LogInformation("Retrieving min product price for category ID: {CategoryId}", categoryId);
        return await product.GetMinPriceOfProductByCategory(categoryId);
    }

    [HttpGet("max-price/category/{categoryId}")]
    public async Task<ApiResponse<ProductStatisticDto>> GetMaxPriceOfProductByCategory(int categoryId)
    {
        loggerservic.LogInformation("Retrieving max product price for category ID: {CategoryId}", categoryId);
        return await product.GetMaxPriceOfProductByCategory(categoryId);
    }

    [HttpGet("avg-price/category/{categoryId}")]
    public async Task<ApiResponse<ProductStatisticDto>> GetAveragePriceOfProductByCategory(int categoryId)
    {
        loggerservic.LogInformation("Retrieving avg product price for category ID: {CategoryId}", categoryId);
        return await product.GetAveragePriceOfProductByCategory(categoryId);
    }

    [HttpGet("totalprice")]
    public async Task<ApiResponse<ProductStatisticDto>> GetTotalPriceOfProducts()
    {
        loggerservic.LogInformation("Retrieving total price of all products!");
        return await product.GetTotalPriceOfProducts();
    }
}
