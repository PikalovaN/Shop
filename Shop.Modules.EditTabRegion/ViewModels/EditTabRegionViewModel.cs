using Prism.Commands;
using Prism.Mvvm;
using Shop.Core.Models;
using Shop.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;

namespace Shop.Modules.EditTabRegion.ViewModels
{
    public class EditTabRegionViewModel : BindableBase
    {
        private readonly DatabaseHelper _databaseHelper;
        public ObservableCollection<string> TableNames { get; set; } = new ObservableCollection<string> { "Товары", "Клиенты", "Заказы" };
        string _currentTable;

        public Product product { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public int productId {get;set;}
        public int productSubject { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<string> Fields { get; set; }
    public string CurrentField { get; set; }
    public string Value { get; set; }
        
            // ... другие свойства ...

            private bool _isProductsVisible = false;
            public bool IsProductsVisible
            {
                get { return _isProductsVisible; }
                set { SetProperty(ref _isProductsVisible, value); }
            }

            private bool _isClientsVisible = false;
            public bool IsClientsVisible
            {
                get { return _isClientsVisible; }
                set { SetProperty(ref _isClientsVisible, value); }
            }
            public string CurrentTable
            {
            get => _currentTable;
            set
            {
                SetProperty(ref _currentTable, value);
                    LoadTable(); // Загружаем данные из выбранной таблицы
                    Fields.Clear();
                switch (_currentTable)
                {
                    case "Товары":
                        string[] p_fields = { "BookID", "Наименование", "Возрастное ограничение", "год", "Производитель","Цена", "Тематика", "Категория" };
                        Fields.AddRange<string>(p_fields);
                    break;
                    case "Клиенты":
                        string[] c_fields = {  "Фамилия","Имя", "№кл", " Отчество", "Почта", "Телефон" };
                        Fields.AddRange<string>(c_fields);
                        break;
                    case "Заказы":
                        string[] o_fields = { "BookID", "Наименование" };
                        Fields.AddRange<string>(o_fields);
                        break;
                }
               
            }
            }

        public EditTabRegionViewModel(DatabaseHelper databaseHelper)
        {
            product = new Product();
            _databaseHelper = databaseHelper;
            QueryCommand = new DelegateCommand(Query);
            Products = new ObservableCollection<Product>();
            Clients = new ObservableCollection<Client>();
            Fields = new ObservableCollection<string>();            
            Query();
             LoadProductsCommand = new DelegateCommand(LoadProducts);
              LoadClientsCommand = new DelegateCommand(LoadClients);

        }
        public ICommand LoadProductsCommand { get; set; }
        public ICommand LoadClientsCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand RemoveProductCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand QueryCommand { get; set; }
        private async void LoadTable()
        {
            switch (CurrentTable)
            {
                case "Товары":
                    IsProductsVisible = true;
                    IsClientsVisible = false;
                    LoadProducts();
                    break;
                case "Клиенты":
                    IsProductsVisible = false;
                    IsClientsVisible = true;
                    LoadClients();
                    break;
                case "Заказы":
                    // ... Загрузка данных для Заказы
                    break;
            }
        }


        async void Query()
        {
            switch (CurrentTable)
            {
                case "Товары":
                    LoadProducts();
                    List<Product> p = await _databaseHelper.SearchProducts(CurrentField, Value);
                    foreach (Product pr in p)
                    {
                        Products.Add(pr);
                    }
                    break;
                case "Клиенты":
                    LoadClients();
                    List<Client> c = await _databaseHelper.SearchClients(CurrentField, Value);
                    foreach (Client cl in c)
                    {
                        Clients.Add(cl);
                    }

                    break;
                case "Заказы":

                    break;
            }
        }
        private async void LoadProducts()
        {
            Products.Clear();
            //List<Product> products = await _databaseHelper.GetProducts();
            //foreach (var product in products)
            //{
            //    Products.Add(product);
            //}
        }

        private async void LoadClients()
        {
            Clients.Clear();
            //List<Client> clients = await _databaseHelper.GetClients();
            //foreach (var client in clients)
            //{
            //    Clients.Add(client);
            //}
        }

    }
}
