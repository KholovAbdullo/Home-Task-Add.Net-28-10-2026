using Domain.Models;
using Infrastructure.Repositories;

var re = new ProductRepository();
var ca = new CategoryRepository();

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
    6. Get products by category name.
    7. Get products by category id.
    8. Get products amount.
    9. Get amount by category.
    10. Get min price by category.
    11. Get max price by category.
    12. Get average price by category.
    13. Get total price of products.

    Table Category!
    14. Show all categories.
    15. Show category by id.
    16. Add new category.
    17. Update category.
    18. Delete category.
    19. Get categories amount.
    0. Exit.");

    var a = Console.ReadLine();
    Console.WriteLine("======================================");

        switch (a)
    {
        case "1":
            var products = re.GetProducts();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Price} | {item.categoryId}");
            }
            break;

        case "2":
            Console.Write("Enter product id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var product = re.GetProduct(id);
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
                categoryId= categoryId
            };
            re.AddProduct(product1);
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
            re.UpdateProduct(product2);
            break;

        case "5":
            Console.Write("Enter product id: ");
            var i = Convert.ToInt32(Console.ReadLine());
            re.DeleteProduct(i);
            break;

        case "6":
            Console.Write("Enter category name: ");
            var categoryName = Console.ReadLine()!;
            var products1 = re.GetProductsByCategory(categoryName);
            foreach (var item in products1)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Price}");
            }
            break;

        case "7":
            Console.Write("Enter category id: ");
            var categoryId1 = Convert.ToInt32(Console.ReadLine());
            var products2 = re.GetProductsByCategory(categoryId1);
            foreach (var item in products2)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Price}");
            }
            break;

        case "8":
            var productAmount = re.GetAmountOfProducts();
            Console.WriteLine($"Products amount: {productAmount}");
            break;

        case "9":
            Console.Write("Enter category id: ");
            var categoryId2 = Convert.ToInt32(Console.ReadLine());
            var amount = re.GetAmountOfProductsByCategory(categoryId2);
            Console.WriteLine($"Products amount: {amount}");
            break;

        case "10":
            Console.Write("Enter category id: ");
            var categoryId3 = Convert.ToInt32(Console.ReadLine());
            var min = re.GetMinPriceOfProductByCategory(categoryId3);
            Console.WriteLine($"Min price: {min}");
            break;

        case "11":
            Console.Write("Enter category id: ");
            var categoryId4 = Convert.ToInt32(Console.ReadLine());
            var max = re.GetMaxPriceOfProductByCategory(categoryId4);
            Console.WriteLine($"Max price: {max}");
            break;

        case "12":
            Console.Write("Enter category id: ");
            var categoryId5 = Convert.ToInt32(Console.ReadLine());
            var avg = re.GetAveragePriceOfProductByCategory(categoryId5);
            Console.WriteLine($"Average price: {avg}");
            break;

        case "13":
            var total = re.GetTotalPriceOfProducts();
            Console.WriteLine($"Total price: {total}");
            break;

        case "14":
            var categories = ca.GetCategories();
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} | {item.Name}");
            }
            break;

        case "15":
            Console.Write("Enter category id: ");
            var idi = Convert.ToInt32(Console.ReadLine());
            var category = ca.GetCategory(idi);
            Console.WriteLine($"{category.Id} | {category.Name}");
            break;

        case "16":
            Console.Write("Enter category name: ");
            var categoryName1 = Console.ReadLine()!;
            var category1 = new Category()
            {
                Name = categoryName1
            };
            ca.AddCategory(category1);
            break;

        case "17":
            Console.Write("Enter category id: ");
            var idii = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter category name: ");
            var categoryName2 = Console.ReadLine()!;
            var category2 = new Category()
            {
                Id = idii,
                Name = categoryName2
            };
            ca.UpdateCategory(category2);
            break;

        case "18":
            Console.Write("Enter category id: ");
            var idiii = Convert.ToInt32(Console.ReadLine());
            ca.DeleteCategory(idiii);
            break;

        case "19":
            var categoriesAmount = ca.GetAmountOfCategories();
            Console.WriteLine($"Categories amount: {categoriesAmount}");
            break;

        case "0":
            Console.WriteLine("Exit...");
            return;
    }
}