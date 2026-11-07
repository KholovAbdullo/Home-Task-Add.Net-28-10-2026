using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.interfrances;
using Domain.Models;

namespace Application.Service;

public class ProductService(IProductRepository productRepository):IProductService
{
    private IProductRepository productRepository1 = productRepository;

    public async Task<ApiResponse<bool>> AddProduct(Product products)
    {
        var res = await productRepository1.AddProduct(products);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        var res = await productRepository1.DeleteProduct(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Delete!", res);
    }

    public async Task<ApiResponse<Product>> GetProduct(int id)
    {
        var res = await productRepository1.GetProduct(id);
        return res!=null
        ? new ApiResponse<Product>(HttpStatusCode.OK,"Product id!",res)
        : new ApiResponse<Product>(HttpStatusCode.NotFound, "Not Product id!",res!);
    }

    public async Task<ApiResponse<List<Product>>> GetProducts()
    {
        var res = await productRepository1.GetProducts();
        return new ApiResponse<List<Product>>(HttpStatusCode.OK, "List Product!",res);
    }

    public async Task<ApiResponse<bool>> UpdateProduct(Product products)
    {
        var res = await productRepository1.UpdateProduct(products);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Update!", res);
    }

}
