using Prism.Mvvm;

namespace Shop.Core.Models
{
    public class Client : BindableBase
    {
        int _id;
        string _lname = "";
        string _name = "";
        string _otch = "";
        string _email = "";
        string _phone = "";
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string LName
        {
            get => _lname;
            set => SetProperty(ref _lname, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Otch
        {
            get => _otch;
            set => SetProperty(ref _otch, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
    }
}
