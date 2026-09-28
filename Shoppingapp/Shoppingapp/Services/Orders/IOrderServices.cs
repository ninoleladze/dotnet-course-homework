namespace ShoppingApp.Services.Orders
{
    public interface IOrderServices
    {
        void AddToCart();
        void Checkout();
        void ViewOrders();

        // testable overloads
        void AddToCart(int productId);
        void CheckoutForCurrentUser();
    }
}