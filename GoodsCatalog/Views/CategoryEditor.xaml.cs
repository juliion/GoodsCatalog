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
using GoodsCatalog.Repos.Implements;
using GoodsCatalog.Models;

namespace GoodsCatalog.Views
{
    /// <summary>
    /// Interaction logic for CategoryEditor.xaml
    /// </summary>
    public partial class CategoryEditor : Window
    {
        private readonly CategoriesViewModel _categoriesVM;
        public CategoryEditor(CategoriesViewModel categoriesVM)
        {
            _categoriesVM = categoriesVM;
            InitializeComponent();
            this.DataContext = _categoriesVM;
        }

        private void ActCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
