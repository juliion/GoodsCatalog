using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsCatalog.Models;
using GoodsCatalog.Repos.Interfaces;

namespace GoodsCatalog.Repos.Implements
{
    public class CategoriesRepos : ICategoriesRepo
    {
        public void AddNewCategory(Category newCategory)
        {
            throw new NotImplementedException();
        }

        public void DelCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void EditCategory(int categoryId, Category newCategory)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }
    }
}
