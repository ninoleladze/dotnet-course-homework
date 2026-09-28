using ConsoleApp.Handlers.ContextMenuHandlers;
using ConsoleApp.Helpers;
using ConsoleApp1;
using ConsoleMenu;
using StoreBLL.Services;
using StoreDAL.Data;

namespace ConsoleApp.Controllers
{
    /// <summary>
    /// Presentation-layer actions for browsing and (for administrators) managing the product catalog:
    /// products, categories, product titles and manufacturers.
    /// </summary>
    public static class ProductController
    {
        private static StoreDbContext context = UserMenuController.Context;

        /// <summary>
        /// Shows a read-only listing of every product. Available to guests, registered users and admins alike.
        /// </summary>
        public static void ShowAllProducts()
        {
            var service = new ProductService(context);
            var handler = new GuestContextMenuHandler(service, InputHelper.ReadProductModel);
            var menu = new ContextMenu(handler.GenerateMenuItems, service.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Opens the full add/remove/edit/view menu for products. Administrator-only.
        /// </summary>
        public static void ManageProducts()
        {
            var service = new ProductService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadProductModel), service.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Opens the full add/remove/edit/view menu for categories. Administrator-only.
        /// </summary>
        public static void ManageCategories()
        {
            var service = new CategoryService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadCategoryModel), service.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Opens the full add/remove/edit/view menu for product titles. Administrator-only.
        /// </summary>
        public static void ManageProductTitles()
        {
            var service = new ProductTitleService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadProductTitleModel), service.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Opens the full add/remove/edit/view menu for manufacturers. Administrator-only.
        /// </summary>
        public static void ManageManufacturers()
        {
            var service = new ManufacturerService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadManufacturerModel), service.GetAll);
            menu.Run();
        }
    }
}
