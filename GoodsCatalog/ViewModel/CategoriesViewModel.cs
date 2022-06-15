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
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        private readonly ICategoriesRepo _categoriesRepo;
        private Category _selectedCategory;

        public ObservableCollection<Category> Categories { get; set; }
        public Category SelectedCategory
        {
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
            get
            {
                return _selectedCategory;
            }
        }
        public CategoriesViewModel(ICategoriesRepo categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
            Categories = new ObservableCollection<Category>();
            foreach (var category in _categoriesRepo.GetAllCategories())
            {
                Categories.Add(category);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
