using Prism.Commands;
using Prism.Mvvm;
using Shop.Core.Models;
using Shop.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Shop.Modules.ProductsTabRegion.ViewModels
{

    public class ProductsTabRegionViewModel : BindableBase
    {
        private readonly DatabaseHelper _databaseHelper;
        public ObservableCollection<Product> Products { get; set; }
        public ProductsTabRegionViewModel(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
            Products = new ObservableCollection<Product>();
            LoadProducts();
            LoadProductsCommand = new DelegateCommand(LoadProducts);
        }
        public ICommand LoadProductsCommand { get; set; }
        private async void LoadProducts()
        {
            Products.Clear();
            List<Product> p = await _databaseHelper.GetProducts();
            foreach (Product product in p)
            {
                Products.Add(product);
            }
        }
    }
    

}
