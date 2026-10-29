using Dapper;
using Domain.interfrances;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task AddProduct(Product products)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="insert into Product(categor_id,name,price) values(@categor_id,@name,@price)";
        await conn.ExecuteAsync(query,products);
    }

    public async Task DeleteProduct(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="delete from Product where id=@id";
        await conn.ExecuteAsync(query,new{id});
    }

    public async Task<int> GetAmountOfProducts()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Product";
        var amount=await conn.ExecuteScalarAsync<int>(query);
        return amount;
        
    }

    public async Task<int> GetAmountOfProductsByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Product where categor_id=@categoryId";
        var amount=await conn.QuerySingleAsync<int>(query,new{categoryId});
        return amount;
    }

    public async Task<decimal> GetAveragePriceOfProductByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select avg(price) from Product where categor_id=@categoryId";
        var avg=await conn.QuerySingleAsync<decimal>(query,new{categoryId});
        return avg;
    }

    public async Task<decimal> GetMaxPriceOfProductByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select max(price) from Product where categor_id=@categoryId";
        var max=await conn.QuerySingleAsync<decimal>(query,new{categoryId});
        return max;
    }

    public async Task<decimal> GetMinPriceOfProductByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select min(price) from Product where categor_id=@categoryId";
        var min=await conn.QuerySingleAsync<decimal>(query,new{categoryId});
        return min;
    }

    public async Task<Product> GetProduct(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Product where id=@id";
        var products=await conn.QuerySingleAsync<Product>(query,new{id});
        return products;
    }

    public async Task<List<Product>> GetProducts()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=await conn.QueryAsync<Product>("select * from Product");
        return query.ToList();
    }

    public async Task<List<Product>> GetProductsByCategory(string name)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query="select * from Product p join Category c on p.categor_id=c.id where c.name=@name";
        var products=await conn.QueryAsync<Product>(query,new{name});
        return products.ToList();
    }

    public async Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Product where categor_id=@categoryId";
        var products=await conn.QueryAsync<Product>(query,new{categoryId});
        return products.ToList();
    }

    public async Task<decimal> GetTotalPriceOfProducts()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select sum(price) from Product";
        var sum=await conn.QuerySingleAsync<decimal>(query);
        return sum;
    }

    public async Task UpdateProduct(Product products)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="update Product set categor_id=@categor_id,name=@name,price=@price where id=@id";
        await conn.ExecuteAsync(query,products);
    }
}
