using Prism.Commands;
using Shop.Core.Models;
using Shop.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Shop.Modules.OrdersTabRegion.ViewModels
{
    public class OrdersTabRegionViewModel
    {
        private readonly DatabaseHelper _databaseHelper;
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public OrdersTabRegionViewModel(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
            Orders = new ObservableCollection<Order>();
            Products = new ObservableCollection<Product>();
            LoadOrders();
            LoadOrdersCommand = new DelegateCommand(LoadOrders);
            LoadProductsByOrderCommand = new DelegateCommand(LoadProductsByOrder);
        }
        public ICommand LoadOrdersCommand { get; set; }
        public ICommand LoadProductsByOrderCommand { get; set; }
        public int OrderNumber { get; set; }
        private async void LoadOrders()
        {
            Orders.Clear();
            List<Order> o = await _databaseHelper.GetOrders();
            foreach (Order order in o)
            {
                Orders.Add(order);
            }
        }
        private async void LoadProductsByOrder()
        {
            Products.Clear();
            List<Product> p = await _databaseHelper.GetProducts(OrderNumber);
            foreach (Product product in p)
            {
                Products.Add(product);
            }
        }
    }
}
