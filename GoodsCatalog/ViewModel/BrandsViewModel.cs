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
    public class BrandsViewModel : INotifyPropertyChanged
    {
        private readonly IBrandsRepo _brandsRepo;
        private Brand _selectedBrand;

        public ObservableCollection<Brand> Brands { get; set; }
        public Brand SelectedBrand
        {
            set
            {
                _selectedBrand = value;
                OnPropertyChanged("SelectedBrand");
            }
            get
            {
                return _selectedBrand;
            }
        }
        public BrandsViewModel(IBrandsRepo brandsRepo)
        {
            _brandsRepo = brandsRepo;
            Brands = new ObservableCollection<Brand>();
            foreach (var brand in _brandsRepo.GetAllBrands())
            {
                Brands.Add(brand);
            }
        }
        public Brand FindBrandOfSelectedProduct(Product selectedProduct)
        {
            return Brands.FirstOrDefault(b => b.Id == selectedProduct?.BrandId);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
