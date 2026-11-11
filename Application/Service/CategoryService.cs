using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.interfrances;
using Domain.Models;

namespace Application.Service;

public class CategoryService(ICategoryRepository categoryRepository):ICategoryService
{
    private ICategoryRepository categoryRepository1 = categoryRepository;

    public async Task<ApiResponse<bool>> AddCategory(CreateCategoryDto categoryDto)
    {
        var category = new Category()
        {
            Name=categoryDto.Name
        };

        var res = await categoryRepository1.AddCategory(category);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        var res = await categoryRepository1.DeleteCategory(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Delete!", res);
    }

    public async Task<ApiResponse<CategoryStatisticDto>> GetAmountOfCategories()
    {
        var amount = await categoryRepository1.GetAmountOfCategories();
        var res = new CategoryStatisticDto()
        {
            AmountOfCategories=amount
        };

        return new ApiResponse<CategoryStatisticDto>(HttpStatusCode.OK, "Category Statistic!", res);
    }

    public async Task<ApiResponse<List<CategoryDto>>> GetCategories()
    {
        var res = await categoryRepository1.GetCategories();
        var category = res.Select(c=>new CategoryDto
        {
            Id=c.Id,
            Name=c.Name
        }).ToList();

        return new ApiResponse<List<CategoryDto>>(HttpStatusCode.OK, "List Category!", category);
    }

    public async Task<ApiResponse<CategoryDto>> GetCategory(int id)
    {
        var res = await categoryRepository1.GetCategory(id);
        if (res == null)
        {
            return new ApiResponse<CategoryDto>(HttpStatusCode.NotFound, "Category not faund!", null!);
        }

        var category = new CategoryDto()
        {
            Id=res.Id,
            Name=res.Name
        };

        return new ApiResponse<CategoryDto>(HttpStatusCode.OK, "Category!", category);
    }

    public async Task<ApiResponse<bool>> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        var category = new Category()
        {
            Id=categoryDto.Id,
            Name=categoryDto.Name
        };

        var res = await categoryRepository1.UpdateCategory(category);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!", res);
    }

}
