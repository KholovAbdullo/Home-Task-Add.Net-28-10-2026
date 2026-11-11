using Application.DTOs;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<bool>> AddCategory(CreateCategoryDto categoryDto);
    Task<ApiResponse<bool>> UpdateCategory(UpdateCategoryDto categoryDto);
    Task<ApiResponse<bool>> DeleteCategory(int id);
    Task<ApiResponse<CategoryDto>> GetCategory(int id);
    Task<ApiResponse<List<CategoryDto>>> GetCategories();
    Task<ApiResponse<CategoryStatisticDto>> GetAmountOfCategories();
}
