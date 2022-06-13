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
    public class CategoriesRepo : ICategoriesRepo
    {
        public void AddNewCategory(Category newCategory)
        {
            DynamicParameters paramList = new DynamicParameters();
            paramList.Add("@categoryName", newCategory.Name);
            QueryManager.ExecuteDml("AddNewCategory", paramList);
        }

        public void DelCategory(int categoryId)
        {
            DynamicParameters paramList = new DynamicParameters();
            paramList.Add("@categoryId", categoryId);
            QueryManager.ExecuteDml("DelCategory", paramList);
        }

        public void EditCategory(int categoryId, Category newCategory)
        {
            DynamicParameters paramList = new DynamicParameters();
            paramList.Add("@categoryId", categoryId);
            paramList.Add("@newCategoryName", newCategory.Name);
            QueryManager.ExecuteDml("EditCategory", paramList);
        }

        public List<Category> GetAllCategories()
        {
            return QueryManager.ExecuteSelect<Category>("GetAllCategories").ToList();
        }
    }
}
