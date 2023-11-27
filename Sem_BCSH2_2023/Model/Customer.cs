using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sem_BCSH2_2023.Model
{
    public class Customer : BaseViewModel
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _address;
        private string _city;
        private long _phone;
        private string _email;
        public int Id
        {
            get => _id; 
            set => SetProperty(ref _id, value, nameof(Id));
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }
        public string Surname
        {
            get => _surname;
            set => SetProperty(ref _surname, value, nameof(Surname));
        }
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value, nameof(Address));
        }
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value, nameof(City));
        }
        public long PhoneNumber
        {
            get => _phone;
            set => SetProperty(ref _phone, value, nameof(PhoneNumber));
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value, nameof(Email));
        }

        public Customer(int id, string name, string surname, string address, string city, long phoneNumber, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            City = city;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string? ToString()
        {
            return Id + " , " + Name;
        }
    }
}
