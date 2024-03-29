﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GoodsCatalog.Models;
using GoodsCatalog.Repos.Interfaces;
using GoodsCatalog.Dapper;
using System.Data;

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
            paramList.Add("@material", newProduct.Material);
            paramList.Add("@price", newProduct.Price);
            paramList.Add("@categoryId", newProduct.CategoryId);
            paramList.Add("@brandId", newProduct.BrandId);
            paramList.Add("@description", newProduct.Description);
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
            return QueryManager.ExecuteSelect<Product>("GetProductsByCategory", paramList).ToList();
        }
        public List<Product> GetProductsByBrand(int brandId)
        {
            DynamicParameters paramList = new DynamicParameters();
            paramList.Add("@brandId", brandId);
            return QueryManager.ExecuteSelect<Product>("GetProductsByBrand", paramList).ToList();
        }
        public List<Product> GetProductsByBrandAndCategory(int brandId, int categoryId)
        {
            DynamicParameters paramList = new DynamicParameters();
            paramList.Add("@brandId", brandId);
            paramList.Add("@categoryId", categoryId);
            return QueryManager.ExecuteSelect<Product>("GetProductsByBrandAndCategory", paramList).ToList();
        }
    }
}
