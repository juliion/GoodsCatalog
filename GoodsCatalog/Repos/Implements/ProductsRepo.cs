using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsCatalog.Models;
using GoodsCatalog.Repos.Interfaces;

namespace GoodsCatalog.Repos.Implements
{
    public class ProductsRepo : IProductsRepo
    {
        public void AddNewProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public void DelProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(int productId, Product newProduct)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
