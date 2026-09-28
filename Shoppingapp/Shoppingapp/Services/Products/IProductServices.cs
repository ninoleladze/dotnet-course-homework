namespace ShoppingApp.Services.Products
{
    public interface IProductServices
    {
        void CreateProduct();
        void EditProduct();
        void DeleteProduct();
        void ShowProducts();
        void SearchProducts();

        // testable overloads
        Models.Product CreateProduct(string name, string description, string category, decimal price, int stock);
    }
}