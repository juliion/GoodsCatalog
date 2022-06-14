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
                SelectedItemHelper.Content = selectedCategory;
            }
        }
    }
}
