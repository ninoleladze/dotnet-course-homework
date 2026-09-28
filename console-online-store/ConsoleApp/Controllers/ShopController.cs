using System;
using System.Globalization;
using System.Linq;
using ConsoleApp.Controllers;
using ConsoleApp.Handlers.ContextMenuHandlers;
using ConsoleApp.Helpers;
using ConsoleApp1;
using ConsoleMenu;
using StoreBLL.Services;
using StoreDAL.Data;

namespace ConsoleApp.Services
{
    /// <summary>
    /// Presentation-layer actions for browsing products, placing orders and managing their status.
    /// </summary>
    public static class ShopController
    {
        private static StoreDbContext context = UserMenuController.Context;

        /// <summary>
        /// Lets the signed-in customer browse products and place an order.
        /// </summary>
        public static void CreateOrder()
        {
            var productService = new ProductService(context);
            var orderService = new CustomerOrderService(context);
            var handler = new ShoppingContextMenuHandler(productService, InputHelper.ReadProductModel, orderService, () => UserMenuController.CurrentUserId);
            var menu = new ContextMenu(handler.GenerateMenuItems, productService.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Shows the order history and delivery status for the signed-in customer.
        /// </summary>
        public static void ShowMyOrders()
        {
            var orderService = new CustomerOrderService(context);
            var orders = orderService.GetOrderHistory(UserMenuController.CurrentUserId).ToList();
            if (orders.Count == 0)
            {
                Console.WriteLine("You have no orders yet.");
                return;
            }

            Console.WriteLine("======= My Orders ==========");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("=============================");
        }

        /// <summary>
        /// Lets the signed-in customer cancel one of their own orders, if its current status allows it.
        /// </summary>
        public static void CancelMyOrder()
        {
            Console.WriteLine("Input the Id of the order to cancel");
            var orderId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
            var orderService = new CustomerOrderService(context);
            var success = orderService.CancelByUser(orderId, UserMenuController.CurrentUserId);
            Console.WriteLine(success ? "Order cancelled." : "Order could not be cancelled (not yours, not found, or its current status doesn't allow it).");
        }

        /// <summary>
        /// Lets the signed-in customer confirm they received a delivered order.
        /// </summary>
        public static void ConfirmMyOrderDelivery()
        {
            Console.WriteLine("Input the Id of the order to confirm as received");
            var orderId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
            var orderService = new CustomerOrderService(context);
            var success = orderService.ConfirmDeliveryReceived(orderId, UserMenuController.CurrentUserId);
            Console.WriteLine(success ? "Delivery confirmed. Thanks for your order!" : "Could not confirm delivery (not yours, not found, or it hasn't been delivered yet).");
        }

        /// <summary>
        /// Opens the full add/remove/edit/view menu for order states. Administrator-only.
        /// </summary>
        public static void ShowAllOrderStates()
        {
            var service = new OrderStateService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadOrderStateModel), service.GetAll);
            menu.Run();
        }

        /// <summary>
        /// Shows every order placed by every customer, including who placed it. Administrator-only.
        /// </summary>
        public static void ShowAllOrders()
        {
            var orderService = new CustomerOrderService(context);
            var orders = orderService.GetAll().ToList();
            if (orders.Count == 0)
            {
                Console.WriteLine("There are no orders yet.");
                return;
            }

            Console.WriteLine("======= All Orders ==========");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("==============================");
        }

        /// <summary>
        /// Lets an administrator change an order's status, showing the statuses currently reachable
        /// from its state and rejecting anything else so the order keeps its last valid status.
        /// Administrator-only.
        /// </summary>
        public static void ChangeOrderStatus()
        {
            var orderService = new CustomerOrderService(context);
            var stateService = new OrderStateService(context);

            Console.WriteLine("Input the Id of the order to update");
            var orderId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
            var order = orderService.GetById(orderId) as StoreBLL.Models.CustomerOrderModel;
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            var allowedNextStates = OrderStateTransitionValidator.GetAllowedNextStates(order.OrderStateId);
            if (allowedNextStates.Count == 0)
            {
                Console.WriteLine($"Order {orderId} is in a terminal status ({order.OrderStateName}); no further status changes are allowed.");
                return;
            }

            Console.WriteLine($"Current status: {order.OrderStateName}. Allowed next statuses:");
            foreach (var stateId in allowedNextStates)
            {
                var state = stateService.GetById(stateId) as StoreBLL.Models.OrderStateModel;
                Console.WriteLine($"  {stateId}: {state?.StateName}");
            }

            Console.WriteLine("Input new status Id");
            var newStateId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
            var success = orderService.ChangeStatus(orderId, newStateId);
            Console.WriteLine(success ? "Order status updated." : "That status change is not allowed; the order's status was left unchanged.");
        }
    }
}
