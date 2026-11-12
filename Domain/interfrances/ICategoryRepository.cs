using Domain.Models;

namespace Domain.interfrances;

public interface ICategoryRepository
{
    Task<bool> AddCategory(Category category);
    Task<bool> UpdateCategory(int id,Category category);
    Task<bool> DeleteCategory(int id);
    Task<Category> GetCategory(int id);
    Task<List<Category>> GetCategories();
    Task<int> GetAmountOfCategories();
}
