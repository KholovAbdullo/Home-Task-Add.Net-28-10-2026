using Dapper;
using Domain.interfrances;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public void AddProduct(Product products)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="insert into Product(categor_id,name,price) values(@categor_id,@name,@price)";
        conn.Execute(query,products);
    }

    public void DeleteProduct(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="delete from Product where id=@id";
        conn.Execute(query,new{id});
    }

    public int GetAmountOfProducts()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Product";
        var amount=conn.QuerySingle<int>(query);
        return amount;
        
    }

    public int GetAmountOfProductsByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select count(*) from Product where categor_id=@categoryId";
        var amount=conn.QuerySingle<int>(query,new{categoryId});
        return amount;
    }

    public decimal GetAveragePriceOfProductByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select avg(price) from Product where categor_id=@categoryId";
        var avg=conn.QuerySingle<decimal>(query,new{categoryId});
        return avg;
    }

    public decimal GetMaxPriceOfProductByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select max(price) from Product where categor_id=@categoryId";
        var max=conn.QuerySingle<decimal>(query,new{categoryId});
        return max;
    }

    public decimal GetMinPriceOfProductByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select min(price) from Product where categor_id=@categoryId";
        var min=conn.QuerySingle<decimal>(query,new{categoryId});
        return min;
    }

    public Product GetProduct(int id)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Product where id=@id";
        var products=conn.QuerySingle<Product>(query,new{id});
        return products;
    }

    public List<Product> GetProducts()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query=conn.Query<Product>("select * from Product");
        return query.ToList();
    }

    public List<Product> GetProductsByCategory(string name)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query="select * from Product p join Category c on p.categor_id=c.id where c.name=@name";
        var products=conn.Query<Product>(query,new{name});
        return products.ToList();
    }

    public List<Product> GetProductsByCategory(int categoryId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from Product where categor_id=@categoryId";
        var products=conn.Query<Product>(query,new{categoryId});
        return products.ToList();
    }

    public decimal GetTotalPriceOfProducts()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select sum(price) from Product";
        var sum=conn.QuerySingle<decimal>(query);
        return sum;
    }

    public void UpdateProduct(Product products)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="update Product set categor_id=@categor_id,name=@name,price=@price where id=@id";
        conn.Execute(query,products);
    }

}
