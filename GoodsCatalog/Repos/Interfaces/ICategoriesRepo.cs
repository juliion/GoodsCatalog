using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsCatalog.Models;

namespace GoodsCatalog.Repos.Interfaces
{
    public interface ICategoriesRepo
    {
        List<Category> GetAllCategories();
        void AddNewCategory(Category newCategory);
        void DelCategory(int categoryId);
        void EditCategory(int categoryId, Category newCategory);
    }
}
