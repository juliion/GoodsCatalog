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
using GoodsCatalog.Commands;

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
        private RelayCommand _addProduct;
        public RelayCommand AddProduct
        {
            get
            {
                return _addProduct ?? (_addProduct = new RelayCommand(obj =>
                {
                    Product newProduct = obj as Product;
                    Products.Add(newProduct);
                    _productsRepo.AddNewProduct(newProduct);
                }));
            }
        }
        private RelayCommand _editProduct;
        public RelayCommand EditProduct
        {
            get
            {
                return _editProduct ?? (_editProduct = new RelayCommand(obj =>
                {
                    int productId = SelectedProduct.Id;
                    Product newProduct = obj as Product;
                    _productsRepo.EditProduct(productId, newProduct);
                },
                (obj) => Products.Count > 0));
            }
        }
        private RelayCommand _delProduct;
        public RelayCommand DelProduct
        {
            get
            {
                return _delProduct ?? (_delProduct = new RelayCommand(obj =>
                {
                    if (SelectedProduct != null)
                    {
                        _productsRepo.DelProduct(SelectedProduct.Id);
                        Products.Remove(SelectedProduct);
                    }
                },
                (obj) => Products.Count > 0));
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
