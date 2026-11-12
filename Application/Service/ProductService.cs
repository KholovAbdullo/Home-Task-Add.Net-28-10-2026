using System.Net;
using Application.DTOs.Product;
using Application.Interfaces;
using Application.Responses;
using Domain.interfrances;
using Domain.Models;

namespace Application.Service;

public class ProductService(IProductRepository productRepository):IProductService
{
    private IProductRepository productRepository1 = productRepository;

    public async Task<ApiResponse<bool>> AddProduct(CreateProductDto productDto)
    {
        var produc = new Product()
        {
            Name=productDto.Name,
            Price=productDto.Price,
            categoryId=productDto.CategoryId
        };

        var res = await productRepository1.AddProduct(produc);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        var res = await productRepository1.DeleteProduct(id);

        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!", res);
    }

    public async Task<ApiResponse<ProductStatisticDto>> GetAmountOfProducts()
    {
        var amount = await productRepository1.GetAmountOfProducts();
        var res = new ProductStatisticDto()
        {
            AmountOfProducts=amount
        };

        return new ApiResponse<ProductStatisticDto>(HttpStatusCode.OK, "product Amount!",res);
    }

    public async Task<ApiResponse<ProductStatisticDto>> GetAmountOfProductsByCategory(int categoryId)
    {
        var amount = await productRepository1.GetAmountOfProductsByCategory(categoryId);
        var res = new ProductStatisticDto()
        {
            AmountOfProductsByCategory=amount
        };

        return new ApiResponse<ProductStatisticDto>(HttpStatusCode.OK, "AmountOfProductByCategory!",res);
    }

    public async Task<ApiResponse<ProductStatisticDto>> GetAveragePriceOfProductByCategory(int categoryId)
    {
        var amount = await productRepository1.GetAveragePriceOfProductByCategory(categoryId);
        var res = new ProductStatisticDto()
        {
            AveragePriceOfProduct=amount
        };

        return new ApiResponse<ProductStatisticDto>(HttpStatusCode.OK, "Average price!", res);
    }

    public async Task<ApiResponse<ProductStatisticDto>> GetMaxPriceOfProductByCategory(int categoryId)
    {
        var max = await productRepository1.GetMaxPriceOfProductByCategory(categoryId);
        var res = new ProductStatisticDto()
        {
            MaxPriceOfProduct=max
        };
        return new ApiResponse<ProductStatisticDto>(HttpStatusCode.OK, "Max Price!", res);
    }

    public async Task<ApiResponse<ProductStatisticDto>> GetMinPriceOfProductByCategory(int categoryId)
    {
        var min = await productRepository1.GetMinPriceOfProductByCategory(categoryId);
        var res = new ProductStatisticDto()
        {
            MinPriceOfProduct=min
        };
        return new ApiResponse<ProductStatisticDto>(HttpStatusCode.OK, "Min Price!", res);
    }

    public async Task<ApiResponse<ProductDto>> GetProduct(int id)
    {
        var res = await productRepository1.GetProduct(id);
        if (res == null)
        {
            return new ApiResponse<ProductDto>(HttpStatusCode.NotFound, "Product not faund!", null!);
        }

        var produc = new ProductDto()
        {
            Id=res.Id,
            Name=res.Name,
            Price=res.Price,
            CategoryId=res.categoryId
        };

        return new ApiResponse<ProductDto>(HttpStatusCode.OK, "Product!", produc);
    }

    public async Task<ApiResponse<List<ProductDto>>> GetProducts()
    {
        var res = await productRepository1.GetProducts();
        var products = res.Select(p => new ProductDto()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            CategoryId = p.categoryId
        }).ToList();
        return new ApiResponse<List<ProductDto>>(HttpStatusCode.OK, "List Products!", products);
    }

    public async Task<ApiResponse<List<ProductDto>>> GetProductsByCategory(int categoryId)
    {
        var res = await productRepository1.GetProductsByCategory(categoryId);
        var produc = res.Select(p=>new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            CategoryId = p.categoryId
        }).ToList();

        return new ApiResponse<List<ProductDto>>(HttpStatusCode.OK, "Products By Category!", produc);
    }

    public async Task<ApiResponse<ProductStatisticDto>> GetTotalPriceOfProducts()
    {
        var res = await productRepository1.GetTotalPriceOfProducts();

        var product = new ProductStatisticDto()
        {
            TotalPriceOfProducts=res
        };

        return new ApiResponse<ProductStatisticDto>(HttpStatusCode.OK, "Total Product!", product);
    }

    public async Task<ApiResponse<bool>> UpdateProduct(int id,UpdateProductDto productDto)
    {
        var produc = new Product()
        {
            Name=productDto.Name,
            Price=productDto.Price,
            categoryId=productDto.CategoryId
        };

        var res = await productRepository1.UpdateProduct(id,produc);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!", res);
    }

}
