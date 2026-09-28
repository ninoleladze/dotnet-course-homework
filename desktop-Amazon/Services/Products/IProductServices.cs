namespace Amazon.Services.Products
{
    internal interface IProductServices
    {
        // Admin functions
        void CreateProduct();
        void DeleteProduct();
        void EditProduct();

        // User funcations
        void ShowProducts();
        void SearchProducts();
    }
}
