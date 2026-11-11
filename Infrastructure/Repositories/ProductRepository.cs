using Dapper;
using Domain.interfrances;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ProductRepository(Database database) : IProductRepository
{
    private Database database1 = database;
    public async Task<bool> AddProduct(Product products)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query = "insert into Product(categor_id,name,price) values(@categoryId,@Name,@Price)";
        var res = await conn.ExecuteAsync(query, products);
        return res>0;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="delete from Product where id=@id";
        var res = await conn.ExecuteAsync(query,new{id});
        return res>0;
    }

    public async Task<int> GetAmountOfProducts()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select count(*) from Product";
        var res = await conn.ExecuteScalarAsync<int>(query);
        return res;
    }

    public async Task<int> GetAmountOfProductsByCategory(int categoryId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select count(*) from Product where categor_id=@categoryId";
        var res = await conn.ExecuteScalarAsync<int>(query, new{categoryId});
        return res;
    }

    public async Task<decimal> GetAveragePriceOfProductByCategory(int categoryId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select avg(price) from Product where categor_id=@categoryId";
        var res = await conn.ExecuteScalarAsync<decimal>(query, new{categoryId});
        return res;
    }

    public async Task<decimal> GetMaxPriceOfProductByCategory(int categoryId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select max(price) from Product where categor_id=@categoryId";
        var res = await conn.ExecuteScalarAsync<decimal>(query, new{categoryId});
        return res;
    }

    public async Task<decimal> GetMinPriceOfProductByCategory(int categoryId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select min(price) from Product where categor_id=@categoryId";
        var res = await conn.ExecuteScalarAsync<decimal>(query, new{categoryId});
        return res;
    }

    public async Task<Product> GetProduct(int id)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Product where id=@id";
        var products=await conn.QuerySingleOrDefaultAsync<Product>(query,new{id});
        return products!;
    }

    public async Task<List<Product>> GetProducts()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query=await conn.QueryAsync<Product>("select * from Product");
        return query.ToList();
    }

    public async Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select * from Product where categor_id=@categoryId";
        var res = await conn.QueryAsync<Product>(query,new{categoryId});
        return res.ToList();
    }

    public async Task<decimal> GetTotalPriceOfProducts()
    {
        using var conn=database1.Connection();
        conn.Open();
        var query="select sum(price) from Product";
        var res = await conn.ExecuteScalarAsync<decimal>(query);
        return res;
    }


    public async Task<bool> UpdateProduct(Product products)
    {
        using var conn=database1.Connection();
        conn.Open();
        var query = "update Product set categor_id=@categoryId,name=@Name,price=@Price where id=@Id";
        var res = await conn.ExecuteAsync(query, products);
        return res>0;
    }
}
