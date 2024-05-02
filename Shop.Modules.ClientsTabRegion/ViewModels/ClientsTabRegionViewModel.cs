using Prism.Commands;
using Prism.Mvvm;
using Shop.Core.Models;
using Shop.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Shop.Modules.ClientsTabRegion.ViewModels
{
    public class ClientsTabRegionViewModel : BindableBase
    {
        private readonly DatabaseHelper _databaseHelper;
        public ObservableCollection<Client> Clients { get; set; }
        public ClientsTabRegionViewModel(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
            Clients = new ObservableCollection<Client>();
            LoadClients();
            LoadClientsCommand = new DelegateCommand(LoadClients);
        }
        public ICommand LoadClientsCommand { get; set; }
        private async void LoadClients()
        {
            Clients.Clear();
            List<Client> c = await _databaseHelper.GetClients();
            foreach (Client client in c)
            {
                Clients.Add(client);
            }
        }
    }
}
