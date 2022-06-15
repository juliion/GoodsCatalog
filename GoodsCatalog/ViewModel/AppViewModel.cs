using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsCatalog.Repos.Implements;

namespace GoodsCatalog.ViewModel
{
    public class AppViewModel
    {
        public BrandsViewModel BrandsVM { get; set; } = new BrandsViewModel(new BrandsRepo());
        public CategoriesViewModel CategoriesVM { get; set; } = new CategoriesViewModel(new CategoriesRepo());
        public ProductsViewModels ProductsVM { get; set; } = new ProductsViewModels(new ProductsRepo());
    }
}
