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
    public async Task<ApiResponse<bool>> AddProduct(Product products)
    {
        return await product.AddProduct(products);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(Product products)
    {
        return await product.UpdateProduct(products);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        return await product.DeleteProduct(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Product>> GetProduct(int id)
    {
        return await product.GetProduct(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Product>>> GetProducts()
    {
        return await product.GetProducts();
    }
}
