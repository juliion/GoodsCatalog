using System;
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
using System.Windows.Shapes;
using GoodsCatalog.ViewModel;

namespace GoodsCatalog.Views
{
    /// <summary>
    /// Interaction logic for ProductEditor.xaml
    /// </summary>
    public partial class ProductEditor : Window
    {
        private readonly AppViewModel _appVM;
        public ProductEditor(AppViewModel appVM)
        {
            _appVM = appVM;
            InitializeComponent();
            this.DataContext = _appVM;
        }

        private void ActBtn_Click(object sender, RoutedEventArgs e)
        {
            _appVM.ProductsVM.SelectedProduct.CategoryId = _appVM.CategoriesVM.CategoryOfSelectedProduct.Id;
            _appVM.ProductsVM.SelectedProduct.BrandId = _appVM.BrandsVM.BrandOfSelectedProduct.Id;
            DialogResult = true;
        }
    }
}
