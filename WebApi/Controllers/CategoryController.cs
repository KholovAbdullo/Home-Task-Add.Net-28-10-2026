using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private ICategoryService categoryService1 = categoryService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(Category category)
    {
        return await categoryService1.AddCategory(category);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCategory(Category category)
    {
        return await categoryService1.UpdateCategory(category);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        return await categoryService1.DeleteCategory(id);
        
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Category>> GetCategory(int id)
    {
        var res = await categoryService1.GetCategory(id);

        if (res == null)
        {
            return null!;
        }

        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<Category>>> GetCategories()
    {
        return await categoryService1.GetCategories();
    }
}
