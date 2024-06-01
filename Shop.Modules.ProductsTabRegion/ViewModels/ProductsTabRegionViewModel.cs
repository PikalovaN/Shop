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
        public Product product { get; set; }
        public ObservableCollection<string> Ages { get; set; }//для списка
        public ObservableCollection<string> Manufacturers { get; set; }//для списка
        public ObservableCollection<string> Years { get; set; }//для списка
        public ObservableCollection<string> Categorys { get; set; }//для списка
        public ObservableCollection<string> Subjects { get; set; }

        public ProductsTabRegionViewModel(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
            Products = new ObservableCollection<Product>();
            LoadProducts();
            LoadProductsCommand = new DelegateCommand(LoadProducts);

            RemoveProductCommand = new DelegateCommand(RemoveProduct);
            UpdateProductCommand = new DelegateCommand(UpdateProduct);
            AddProductCommand = new DelegateCommand(AddProduct);

            Ages = new ObservableCollection<string>();//для списка
            Manufacturers = new ObservableCollection<string>();//для списка
            Years = new ObservableCollection<string>();//для списка           
            Categorys = new ObservableCollection<string>();//для списка
            Subjects = new ObservableCollection<string>();//для списка
            product = new Product();
            Init();

        }
        public ICommand LoadProductsCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand RemoveProductCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        private async void LoadProducts()//метод прогружает таблицу
        {
            Products.Clear();
            List<Product> p = await _databaseHelper.GetProducts();//метод обращается к бд
            foreach (Product product in p)
            {
                Products.Add(product);
            }
        }
        async void Init()//для прогрузки списка
        {
            List<string> categorys = await _databaseHelper.GetCategorys();
            foreach (string s in categorys)
            {
                Categorys.Add(s);
            }
            List<string> subjects = await _databaseHelper.GetSubjects();
            foreach (string s in subjects)
            {
                Subjects.Add(s);
            }

            List<string> ages = await _databaseHelper.GetAges();
            foreach (string s in ages)
            {
                Ages.Add(s);
            }
           
            List<string> years = await _databaseHelper.GetYears();
            foreach (string s in years)
            {
                Years.Add(s);
            }
            List<string> manufacturers = await _databaseHelper.GetManufacturers();
            foreach (string s in manufacturers)
            {
                Manufacturers.Add(s);
            }

           

        }

        async void AddProduct()//метод добавления записи
        {
            await _databaseHelper.AddProduct(product);
        }
        async void RemoveProduct()// метод изменения записи
        {
            await _databaseHelper.RemoveProduct(product);
        }
        async void UpdateProduct()//метод удаления записи
        {
            await _databaseHelper.UpdateProduct(product);
        }


    }
    

}
