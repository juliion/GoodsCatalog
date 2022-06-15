using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using GoodsCatalog.Models;
using GoodsCatalog.Repos.Interfaces;

namespace GoodsCatalog.ViewModel
{
    public class ProductsViewModels : INotifyPropertyChanged
    {
        private readonly IProductsRepo _productsRepo;
        private Product _selectedProduct;

        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct
        {
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
            get
            {
                return _selectedProduct;
            }
        }

        public ProductsViewModels(IProductsRepo productsRepo)
        {
            _productsRepo = productsRepo;
            Products = new ObservableCollection<Product>();
            foreach (var product in _productsRepo.GetAllProducts())
            {
                Products.Add(product);
            }
        }
        public void LoadProductsByCategory(int categoryId)
        {
            Products.Clear();
            foreach (var product in _productsRepo.GetProductsByCategory(categoryId))
            {
                Products.Add(product);
            }
        }
        public void LoadProductsByBrand(int brandId)
        {
            Products.Clear();
            foreach (var product in _productsRepo.GetProductsByBrand(brandId))
            {
                Products.Add(product);
            }
        }
        public void LoadProductsByBrandAndCategory(int brandId, int categoryId)
        {
            Products.Clear();
            foreach (var product in _productsRepo.GetProductsByBrandAndCategory(brandId, categoryId))
            {
                Products.Add(product);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
