﻿using System;
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
            BrandsViewModel brandVM = _appViewModel.BrandsVM;
            brandVM.BrandOfSelectedProduct = brandVM.FindBrandOfSelectedProduct(_appViewModel.ProductsVM.SelectedProduct);
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

    }
}
