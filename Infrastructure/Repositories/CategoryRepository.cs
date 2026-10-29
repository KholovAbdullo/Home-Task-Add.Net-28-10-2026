using Dapper;
using Domain.interfrances;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public async Task AddCategory(Category category)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="insert into Category(name) values(@name)";
        await conn.ExecuteAsync(query,new{category.Name});
    }

    public async Task DeleteCategory(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="delete from Category where id=@id";
        await conn.ExecuteAsync(query,new{id});
    }

    public async Task<int> GetAmountOfCategories()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Category";
        var amount=await conn.ExecuteScalarAsync<int>(query);
        return amount;
    }

    public async Task<List<Category>> GetCategories()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=await conn.QueryAsync<Category>("select * from Category");
        return query.ToList();
    }

    public async Task<Category> GetCategory(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Category where id=@id";
        var category=await conn.QuerySingleAsync<Category>(query,new{id});
        return category;
    }

    public async Task UpdateCategory(Category category)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="update Category set name=@name where id=@id";
        await conn.ExecuteAsync(query,category);
    }

}
