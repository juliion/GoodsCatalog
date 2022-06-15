using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsCatalog.Models;

namespace GoodsCatalog.Repos.Interfaces
{
    public interface IProductsRepo
    {
        List<Product> GetAllProducts();
        void AddNewProduct(Product newProduct);
        void DelProduct(int productId);
        void EditProduct(int productId, Product newProduct);
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsByBrand(int brandId);
        List<Product> GetProductsByBrandAndCategory(int brandId, int categoryId);
    }
}
