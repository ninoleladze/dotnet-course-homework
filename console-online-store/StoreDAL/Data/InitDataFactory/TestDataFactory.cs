namespace StoreDAL.Data.InitDataFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDAL.Entities;
using StoreDAL.Security;

public class TestDataFactory : AbstractDataFactory
{
    public override Category[] GetCategoryData()
    {
        return new[]
        {
            new Category(1, "fruits"),
            new Category(2, "water"),
            new Category(3, "vegetables"),
            new Category(4, "seafood"),
            new Category(5, "meet"),
            new Category(6, "grocery"),
            new Category(7, "milk food"),
            new Category(8, "smartphones"),
            new Category(9, "laptop"),
            new Category(10, "photocameras"),
            new Category(11, "kitchen accesories"),
            new Category(12, "spices"),
            new Category(13, "Juice"),
            new Category(14, "alcohol drinks"),
        };
    }

    public override CustomerOrder[] GetCustomerOrderData()
    {
        return new[]
        {
            new CustomerOrder(1, "2026-07-10 10:15:00", 2, 1),
            new CustomerOrder(2, "2026-07-12 14:30:00", 2, 7),
        };
    }

    public override Manufacturer[] GetManufacturerData()
    {
        return new[]
        {
            new Manufacturer(1, "Local Farm"),
            new Manufacturer(2, "Apple"),
            new Manufacturer(3, "Samsung"),
            new Manufacturer(4, "Nestle"),
            new Manufacturer(5, "Absolut"),
            new Manufacturer(6, "Canon"),
        };
    }

    public override OrderDetail[] GetOrderDetailData()
    {
        return new[]
        {
            new OrderDetail(1, 1, 1, 1.20m, 3),
            new OrderDetail(2, 1, 9, 999.00m, 1),
            new OrderDetail(3, 2, 16, 15.00m, 2),
        };
    }

    public override OrderState[] GetOrderStateData()
    {
        return new[]
        {
            new OrderState(1, "New Order"),
            new OrderState(2, "Cancelled by user"),
            new OrderState(3, "Cancelled by administrator"),
            new OrderState(4, "Confirmed"),
            new OrderState(5, "Moved to delivery company"),
            new OrderState(6, "In delivery"),
            new OrderState(7, "Delivered to client"),
            new OrderState(8, "Delivery confirmed by client"),
        };
    }

    public override Product[] GetProductData()
    {
        return new[]
        {
            new Product(1, 1, 1, "Fresh yellow bananas", 1.20m),
            new Product(2, 2, 1, "Red apples", 1.50m),
            new Product(3, 3, 4, "1.5L bottle", 0.99m),
            new Product(4, 4, 1, "Fresh tomatoes", 2.10m),
            new Product(5, 5, 1, "Frozen shrimp 500g", 9.99m),
            new Product(6, 6, 1, "Beef steak 1kg", 12.50m),
            new Product(7, 7, 4, "Long grain rice 1kg", 3.30m),
            new Product(8, 8, 4, "Hard cheese 300g", 5.75m),
            new Product(9, 9, 2, "128GB, Black", 999.00m),
            new Product(10, 10, 3, "256GB, Silver", 899.00m),
            new Product(11, 11, 2, "14-inch, M3", 1999.00m),
            new Product(12, 12, 6, "24MP DSLR", 749.00m),
            new Product(13, 13, 4, "Non-stick 28cm", 24.99m),
            new Product(14, 14, 4, "Ground pepper 100g", 3.20m),
            new Product(15, 15, 4, "1L carton", 2.40m),
            new Product(16, 16, 5, "0.7L bottle 40%", 15.00m),
        };
    }

    public override ProductTitle[] GetProductTitleData()
    {
        return new[]
        {
            new ProductTitle(1, "Banana", 1),
            new ProductTitle(2, "Apple", 1),
            new ProductTitle(3, "Mineral Water", 2),
            new ProductTitle(4, "Tomato", 3),
            new ProductTitle(5, "Shrimp", 4),
            new ProductTitle(6, "Beef", 5),
            new ProductTitle(7, "Rice", 6),
            new ProductTitle(8, "Cheese", 7),
            new ProductTitle(9, "iPhone 15", 8),
            new ProductTitle(10, "Galaxy S24", 8),
            new ProductTitle(11, "MacBook Pro", 9),
            new ProductTitle(12, "Canon EOS", 10),
            new ProductTitle(13, "Frying Pan", 11),
            new ProductTitle(14, "Black Pepper", 12),
            new ProductTitle(15, "Orange Juice", 13),
            new ProductTitle(16, "Vodka", 14),
        };
    }

    public override User[] GetUserData()
    {
        var blankPasswordHash = PasswordHasher.Hash(string.Empty);
        return new[]
        {
            new User(1, "Admin", "Adminov", "admin", blankPasswordHash, 1),
            new User(2, "John", "Doe", "user", blankPasswordHash, 2),
        };
    }

    public override UserRole[] GetUserRoleData()
    {
        return new[]
        {
            new UserRole(1, "Admin"),
            new UserRole(2, "Registered"),
            new UserRole(3, "Guest"),
        };
    }
}
