using Dapper;
using Domain.interfrances;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CategoryRepository(Database database) : ICategoryRepository
{
    private Database dabase = database;
    public async Task<bool> AddCategory(Category category)
    {
        using var conn=dabase.Connection();
        conn.Open();
        var query="insert into Category(name) values(@name)";
        var res = await conn.ExecuteAsync(query,new{category.Name});
        return res>0;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        using var conn=dabase.Connection();
        conn.Open();
        var query="delete from Category where id=@id";
        var res = await conn.ExecuteAsync(query,new{id});
        return res>0;
    }

    public async Task<int> GetAmountOfCategories()
    {
        using var conn = dabase.Connection();
        conn.Open();
        var query="select count(*) from Category";
        var res = await conn.ExecuteScalarAsync<int>(query);
        return res;
    }


    public async Task<List<Category>> GetCategories()
    {
        using var conn=dabase.Connection();
        conn.Open();
        var query=await conn.QueryAsync<Category>("select * from Category");
        return query.ToList();
    }

    public async Task<Category> GetCategory(int id)
    {
        using var conn=dabase.Connection();
        conn.Open();
        var query="select * from Category where id=@id";
        var category=await conn.QuerySingleOrDefaultAsync<Category>(query,new{id});
        return category!;
    }

    public async Task<bool> UpdateCategory(Category category)
    {
        using var conn=dabase.Connection();
        conn.Open();
        var query="update Category set name=@name where id=@id";
        var res = await conn.ExecuteAsync(query,category);
        return res>0;
    }
}
