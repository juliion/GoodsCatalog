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
using GoodsCatalog.Views;

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
        private RelayCommand _addCategory;
        public RelayCommand AddCategory
        {
            get
            {
                return _addCategory ?? (_addCategory = new RelayCommand(obj =>
                {
                    Category newCategory = obj as Category;
                    Categories.Add(newCategory);
                    _categoriesRepo.AddNewCategory(newCategory);
                }));
            }
        }
        private RelayCommand _editCategory;
        public RelayCommand EditCategory
        {
            get
            {
                return _editCategory ?? (_editCategory = new RelayCommand(obj =>
                {
                    int categoryId = SelectedCategory.Id;
                    Category newCategory = obj as Category;
                    _categoriesRepo.EditCategory(categoryId, newCategory);
                },
                (obj) => Categories.Count > 0));
            }
        }
        private RelayCommand _delCategory;
        public RelayCommand  DelCategory
        {
            get
            {
                return _delCategory ?? (_delCategory = new RelayCommand(obj =>
                {
                    if(SelectedCategory != null)
                        Categories.Remove(SelectedCategory);
                },
                (obj) => Categories.Count > 0));
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
