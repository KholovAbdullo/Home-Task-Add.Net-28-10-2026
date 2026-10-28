using Dapper;
using Domain.interfrances;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public void AddCategory(Category category)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="insert into Category(name) values(@name)";
        conn.Execute(query,new{category.Name});
    }

    public void DeleteCategory(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="delete from Category where id=@id";
        conn.Execute(query,new{id});
    }

    public int GetAmountOfCategories()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Category";
        var amount=conn.QuerySingle<int>(query);
        return amount;
    }

    public List<Category> GetCategories()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=conn.Query<Category>("select * from Category");
        return query.ToList();
    }

    public Category GetCategory(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Category where id=@id";
        var category=conn.QuerySingle<Category>(query,new{id});
        return category;
    }

    public void UpdateCategory(Category category)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="update Category set name=@name where id=@id";
        conn.Execute(query,category);
    }

}
