using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.interfrances;
using Domain.Models;

namespace Application.Service;

public class CategoryService(ICategoryRepository categoryRepository):ICategoryService
{
    private ICategoryRepository categoryRepository1 = categoryRepository;

    public async Task<ApiResponse<bool>> AddCategory(Category category)
    {
        var res = await categoryRepository1.AddCategory(category);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Not added!",res);
    }

    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        var res = await categoryRepository1.DeleteCategory(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Not Delete!",res);
    }

    public async Task<ApiResponse<List<Category>>> GetCategories()
    {
        var res = await categoryRepository1.GetCategories();
        return new ApiResponse<List<Category>>(HttpStatusCode.OK, "Book id.",res);
    }

    public async Task<ApiResponse<Category>> GetCategory(int id)
    {
        var res = await categoryRepository1.GetCategory(id);
        return res !=null
        ? new ApiResponse<Category>(HttpStatusCode.OK, "Category id!",res)
        : new ApiResponse<Category>(HttpStatusCode.NotFound, "Not Category id!",res!);
    }

    public async Task<ApiResponse<bool>> UpdateCategory(Category category)
    {
        var res = await categoryRepository1.UpdateCategory(category);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Not Update!",res);
    }

}
