using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay.Services.Products
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
