using Application.DTOs;
using Application.DTOs.Category;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService,ILogger<ICategoryService> logger) : ControllerBase
{
    private ICategoryService categoryService1 = categoryService;

    private ILogger<ICategoryService> loggerservic = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(CreateCategoryDto categoryDto)
    {
        loggerservic.LogInformation("Added new Category!");
        var res = await categoryService1.AddCategory(categoryDto);
        loggerservic.LogInformation("Category added successfully!");
        return res;
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        loggerservic.LogInformation("Updating category!");
        var res = await categoryService1.UpdateCategory(categoryDto);
        loggerservic.LogInformation("Category updated successfully!");
        return res;
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        loggerservic.LogInformation("Delete category ID: {id}",id);
        var res = await categoryService1.DeleteCategory(id);
        loggerservic.LogInformation("Category ID:{id} delete successfully!",id);
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CategoryDto>> GetCategory(int id)
    {
        loggerservic.LogInformation("Getting category for ID: {Id}",id);
        return await categoryService1.GetCategory(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<CategoryDto>>> GetCategories()
    {
        loggerservic.LogInformation("Retrieving all categorys!");
        return await categoryService1.GetCategories();
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<CategoryStatisticDto>> GetAmountOfCategories()
    {
        loggerservic.LogInformation("Retrieving total amount of categories!");
        return await categoryService1.GetAmountOfCategories();
    }
}
