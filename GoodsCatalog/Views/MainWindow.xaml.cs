using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GoodsCatalog.Models;
using GoodsCatalog.ViewModel;

namespace GoodsCatalog.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppViewModel _appViewModel;
        public MainWindow()
        {
            _appViewModel = new AppViewModel();
            InitializeComponent();
            this.DataContext = _appViewModel;
        }
        private void CategoriesList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Category selectedCategory = e.NewValue as Category;
            if (selectedCategory != null)
            {
                SelectedItemHelperCategory.Content = selectedCategory;
                Brand selectedBrand = _appViewModel.BrandsVM.SelectedBrand;
                if (selectedBrand != null)
                    _appViewModel.ProductsVM.LoadProductsByBrandAndCategory(selectedBrand.Id, selectedCategory.Id);
                else
                    _appViewModel.ProductsVM.LoadProductsByCategory(selectedCategory.Id);
            }
        }

        private void BrandsList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Brand selectedBrand = e.NewValue as Brand;
            if (selectedBrand != null)
            {
                SelectedItemHelperBrand.Content = selectedBrand;
                Category selectedCategory =_appViewModel.CategoriesVM.SelectedCategory;
                if (selectedCategory != null)
                    _appViewModel.ProductsVM.LoadProductsByBrandAndCategory(selectedBrand.Id, selectedCategory.Id);
                else
                    _appViewModel.ProductsVM.LoadProductsByBrand(selectedBrand.Id);
            }
        }

        private void ProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BrandsViewModel brandsVM = _appViewModel.BrandsVM;
            Product selectedProduct = _appViewModel.ProductsVM.SelectedProduct;
            CategoriesViewModel categoriesVM = _appViewModel.CategoriesVM;
            brandsVM.BrandOfSelectedProduct = brandsVM.FindBrandOfSelectedProduct(selectedProduct);
            categoriesVM.CategoryOfSelectedProduct = categoriesVM.FindCategoryOfSelectedProduct(selectedProduct);
        }

        private void AddNewCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoriesViewModel categoriesVM = _appViewModel.CategoriesVM;
            CategoryEditor categoryEditor = new CategoryEditor(categoriesVM);
            categoryEditor.ActCategoryBtn.Content = "Додати категорію";
            categoryEditor.ActCategoryBtn.Command = categoriesVM.AddCategory;
            categoriesVM.SelectedCategory = new Category();
            categoryEditor.ShowDialog();
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoriesViewModel categoriesVM = _appViewModel.CategoriesVM;
            if (categoriesVM.SelectedCategory != null)
            {
                CategoryEditor categoryEditor = new CategoryEditor(categoriesVM);
                categoryEditor.ActCategoryBtn.Content = "Редагувати категорію";
                categoryEditor.ActCategoryBtn.Command = categoriesVM.EditCategory;
                categoryEditor.ShowDialog();
            }
            else
                System.Windows.Forms.MessageBox.Show("Оберіть категорію, яку потрібно відредагувати!");
        }

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductsViewModels productsVM = _appViewModel.ProductsVM;
            ProductEditor productEditor = new ProductEditor(_appViewModel);
            productEditor.ActBtn.Content = "Додати товар";
            productEditor.ActBtn.Command =  productsVM.AddProduct;
            productsVM.SelectedProduct = new Product();
            productEditor.ShowDialog();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductsViewModels productsVM = _appViewModel.ProductsVM;
            if (productsVM.SelectedProduct != null)
            {
                ProductEditor productEditor = new ProductEditor(_appViewModel);
                productEditor.ActBtn.Content = "Редагувати товар";
                productEditor.ActBtn.Command = productsVM.EditProduct;
                productEditor.ShowDialog();

            }
            else
                System.Windows.Forms.MessageBox.Show("Оберіть товар, який потрібно відредагувати!");
        }
    }
}
