using Prism.Mvvm;

namespace Shop.Core.Models
{
    public class Product : BindableBase
    {
        int _id;
        string _name = "";
        string _age = "";
        int _year;
        string _manufacturer = "";
        decimal _price;
        int _count;
        int _in;
        int _out;
        string _subject = "";
        string _category = "";
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }
        public int Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }
        public string Manufacturer
        {
            get => _manufacturer;
            set => SetProperty(ref _manufacturer, value);
        }
        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }
        public decimal Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }
        public int In
        {
            get => _in;
            set => SetProperty(ref _in, value);
        }
        public int Out
        {
            get => _out;
            set => SetProperty(ref _out, value);
        }
        public string Subject
        {
            get => _subject;
            set => SetProperty(ref _subject, value);
        }
        public string Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }
    }
}
