using Prism.Mvvm;
using System;

namespace Shop.Core.Models
{
    public class Order : BindableBase
    {
        int _id;
        int _client_id;
        DateTime _start;
        DateTime _end;
        string _service = "";
        string _payment = "";
        string _delivery = "";
        string _city = "";
        string _address = "";
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public int ClientId
        {
            get => _client_id;
            set => SetProperty(ref _client_id, value);
        }
        public DateTime Start
        {
            get => _start;
            set => SetProperty(ref _start, value);
        }
        public DateTime End
        {
            get => _end;
            set => SetProperty(ref _end, value);
        }
        public string Service
        {
            get => _service;
            set => SetProperty(ref _service, value);
        }
        public string Payment
        {
            get => _payment;
            set => SetProperty(ref _payment, value);
        }
        public string Delivery
        {
            get => _delivery;
            set => SetProperty(ref _delivery, value);
        }
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }
    }
}
