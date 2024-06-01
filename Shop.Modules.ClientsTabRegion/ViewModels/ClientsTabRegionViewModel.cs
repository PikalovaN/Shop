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
        public Client client { get; set; }

        public ClientsTabRegionViewModel(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
            Clients = new ObservableCollection<Client>();
            LoadClients();
            LoadClientsCommand = new DelegateCommand(LoadClients);

            RemoveClientsCommand = new DelegateCommand(RemoveClients);
            UpdateClientsCommand = new DelegateCommand(UpdateClients);
            AddClientsCommand = new DelegateCommand(AddClients);
            client =new Client();
        }


        public ICommand LoadClientsCommand { get; set; }
        public ICommand AddClientsCommand { get; set; }
        public ICommand RemoveClientsCommand { get; set; }
        public ICommand UpdateClientsCommand { get; set; }

        private async void LoadClients()
        {
            Clients.Clear();
            List<Client> c = await _databaseHelper.GetClients();
            foreach (Client clients in c)
            {
                Clients.Add(clients);
            }
        }

        async void AddClients()//метод добавления записи
        {
            await _databaseHelper.AddClients(client);
        }


        async void RemoveClients()// метод изменения записи
        {
           await _databaseHelper.RemoveClients(client);
        }
        async void UpdateClients()//метод удаления записи
        {
            await _databaseHelper.UpdateClients(client);
        }

    }
}
