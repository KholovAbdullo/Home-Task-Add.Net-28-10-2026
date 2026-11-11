using Application.DTOs;
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
    public async Task<ApiResponse<bool>> AddCategory(CreateCategoryDto categoryDto)
    {
        return await categoryService1.AddCategory(categoryDto);  
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        return await categoryService1.UpdateCategory(categoryDto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        return await categoryService1.DeleteCategory(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CategoryDto>> GetCategory(int id)
    {
        return await categoryService1.GetCategory(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<CategoryDto>>> GetCategories()
    {
        return await categoryService1.GetCategories();
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<CategoryStatisticDto>> GetAmountOfCategories()
    {
        return await categoryService1.GetAmountOfCategories();
    }
}
