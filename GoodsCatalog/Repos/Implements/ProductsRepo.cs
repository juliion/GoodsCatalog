using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GoodsCatalog.Models;
using GoodsCatalog.Repos.Interfaces;
using GoodsCatalog.Dapper;

namespace GoodsCatalog.Repos.Implements
{
    public class ProductsRepo : IProductsRepo
    {
        public void AddNewProduct(Product newProduct)
        {
            DynamicParameters paramList = new DynamicParameters();
            paramList.Add("@productName", newProduct.Name);
            paramList.Add("@size", newProduct.Size);
            paramList.Add("@color", newProduct.Color);
            paramList.Add("@price", newProduct.Price);
            paramList.Add("@material", newProduct.Material);
            paramList.Add("@categoryId", newProduct.CategoryId);
            paramList.Add("@brandId", newProduct.BrandId);
            paramList.Add("@description", newProduct.Description);
            paramList.Add("@photo", newProduct.Photo);
            QueryManager.ExecuteDml("AddNewProduct", paramList);
        }

        public void DelProduct(int productId)
        {
            DynamicParameters paramList = new DynamicParameters();
            paramList.Add("@productId", productId);
            QueryManager.ExecuteDml("DelProduct", paramList);
        }

        public void EditProduct(int productId, Product newProduct)
        {
            DynamicParameters paramList = new DynamicParameters();
            paramList.Add("@productId", productId);
            paramList.Add("@newProductName", newProduct.Name);
            paramList.Add("@newSize", newProduct.Size);
            paramList.Add("@newColor", newProduct.Color);
            paramList.Add("@newPrice", newProduct.Price);
            paramList.Add("@newMaterial", newProduct.Material);
            paramList.Add("@newCategoryId", newProduct.CategoryId);
            paramList.Add("@newBrandId", newProduct.BrandId);
            paramList.Add("@newDescription", newProduct.Description);
            paramList.Add("@newPhoto", newProduct.Photo);
            QueryManager.ExecuteDml("EditProduct", paramList);
        }

        public List<Product> GetAllProducts()
        {
            return QueryManager.ExecuteSelect<Product>("GetAllProducts").ToList();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            DynamicParameters paramList = new DynamicParameters();
            paramList.Add("@categoryId", categoryId);
            return QueryManager.ExecuteSelect<Product>("GetAllProducts", paramList).ToList();
        }
    }
}
