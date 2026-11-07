using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;

var data = new Database();
var re = new ProductRepository(data);
var ca = new CategoryRepository(data);

while (true)
{
    Console.WriteLine("======================================");
    Console.WriteLine(@"
    Table Product!
    1. Show all products.
    2. Show product by id.
    3. Add new product.
    4. Update product.
    5. Delete product.

    Table Category!
    6. Show all categories.
    7. Show category by id.
    8. Add new category.
    9. Update category.
    10. Delete category.
    0. Exit.");

    var a = Console.ReadLine();
    Console.WriteLine("======================================");

        switch (a)
    {
        case "1":
            var products = await re.GetProducts();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Price} | {item.categoryId}");
            }
            break;

        case "2":
            Console.Write("Enter product id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var product = await re.GetProduct(id);
            Console.WriteLine($"{product.Id} | {product.Name} | {product.Price} | {product.categoryId}");
            break;

        case "3":
            Console.Write("Enter name: ");
            var name = Console.ReadLine()!;
            Console.Write("Enter price: ");
            var price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter category id: ");
            var categoryId = Convert.ToInt32(Console.ReadLine());
            var product1 = new Product()
            {
                Name = name,
                Price = price,
                categoryId = categoryId
            };
            await re.AddProduct(product1);
            break;

        case "4":
            Console.Write("Enter product id: ");
            var idd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name: ");
            var namee = Console.ReadLine()!;
            Console.Write("Enter price: ");
            var pricee = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter category id: ");
            var categoryIdd = Convert.ToInt32(Console.ReadLine());
            var product2 = new Product()
            {
                Id = idd,
                Name = namee,
                Price = pricee,
                categoryId = categoryIdd
            };
            await re.UpdateProduct(product2);
            break;

        case "5":
            Console.Write("Enter product id: ");
            var i = Convert.ToInt32(Console.ReadLine());
            await re.DeleteProduct(i);
            break;

        case "6":
            var categories = await ca.GetCategories();
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} | {item.Name}");
            }
            break;

        case "7":
            Console.Write("Enter category id: ");
            var idi = Convert.ToInt32(Console.ReadLine());
            var category = await ca.GetCategory(idi);
            Console.WriteLine($"{category.Id} | {category.Name}");
            break;

        case "8":
            Console.Write("Enter category name: ");
            var categoryName1 = Console.ReadLine()!;
            var category1 = new Category()
            {
                Name = categoryName1
            };
            await ca.AddCategory(category1);
            break;

        case "9":
            Console.Write("Enter category id: ");
            var idii = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter category name: ");
            var categoryName2 = Console.ReadLine()!;
            var category2 = new Category()
            {
                Id = idii,
                Name = categoryName2
            };
            await ca.UpdateCategory(category2);
            break;

        case "10":
            Console.Write("Enter category id: ");
            var idiii = Convert.ToInt32(Console.ReadLine());
            await ca.DeleteCategory(idiii);
            break;

        case "0":
            Console.WriteLine("Exit...");
            return;
    }
}