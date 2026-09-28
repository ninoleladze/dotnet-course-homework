using Amazon.Services.Products;
using Amazon.Services.Users;

namespace Amazon.Menus
{
    internal class ProductMenu
    {
        private static IProductServices _services = new ProductServices();

        public static void Start()
        {
            while (true)
            {
                try
                {
                    if (UserServices.LoggedInUser!.IsAdmin())
                    {
                        Console.WriteLine("1. create product");
                        Console.WriteLine("2. delete product");
                        Console.WriteLine("3. edit product");
                    }

                    Console.WriteLine("4. show products");
                    Console.WriteLine("5. search products");
                    Console.WriteLine("x. exit");

                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();

                    if (key == "1")
                    {
                        Console.Clear();

                        if (UserServices.LoggedInUser!.IsAdmin())
                        {
                            _services.CreateProduct();
                        }
                        else
                        {
                            Console.WriteLine("User is not admin!");
                        }
                    }
                    else if (key == "2")
                    {
                        Console.Clear();

                        if (UserServices.LoggedInUser!.IsAdmin())
                        {
                            _services.DeleteProduct();
                        }
                        else
                        {
                            Console.WriteLine("User is not admin!");
                        }
                    }
                    else if (key == "3")
                    {
                        Console.Clear();

                        if (UserServices.LoggedInUser!.IsAdmin())
                        {
                            _services.EditProduct();
                        }
                        else
                        {
                            Console.WriteLine("User is not admin!");
                        }
                    }
                    else if (key == "4")
                    {
                        Console.Clear();
                        _services.ShowProducts();
                    }
                    else if (key == "5")
                    {
                        Console.Clear();
                        _services.SearchProducts();
                    }
                    else if (key == "x")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid key!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
