using Sem_BCSH2_2023.Model;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Sem_BCSH2_2023.ViewModel
{
    public class AddEditCustomerViewModel : BaseViewModel
    {
        private Customer? editedCustomer;


        private int _id;
        private string _name;
        private string _surname;
        private string _address;
        private string _city;
        private long _phone;
        private string _email;

        private string _btnText;
        private string _windowName;


        public ICommand AddEditCustomerCom { get; private set; }


        public ICommand CloseCommand { get; private set; }
        public ICommand MaximizeCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }

        public AddEditCustomerViewModel(int? id)
        {
            editedCustomer = null;
            BtnText = "Přidat";
            WindowName = "Přidat nového zákazníka";

            if (id != null)
            {

                editedCustomer = CustomerViewModel.CustomersList.FirstOrDefault(customer => customer.Id == id);
                BtnText = "Editovat";
                WindowName = "Editace údajů o zákazníkovi";
                Name = editedCustomer.Name;
                Surname = editedCustomer.Surname;
                Address = editedCustomer.Address;
                City = editedCustomer.City;
                PhoneNumber= editedCustomer.PhoneNumber;
                Email = editedCustomer.Email;

            }

            AddEditCustomerCom = new CommandViewModel(_ => AddEditCustommer());
            CloseCommand = new CommandViewModel(_ => Close());
            MaximizeCommand = new CommandViewModel(_ => Maximize());
            MinimizeCommand = new CommandViewModel(_ => Minimize());
        }

        


        private void AddEditCustommer()
        {
            if (editedCustomer == null)
            {
                if (CheckInputs())
                {
                    _ = long.TryParse(PhoneNumber.ToString(), out long phone);
                    CustomerViewModel.AddCustomer(Name, Surname, Address, City, phone, Email);


                    var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                    window?.Close();
                }
            }
            else
            {
                if (CheckInputs())
                {
                    _ = long.TryParse(PhoneNumber.ToString(), out long phone);
                    editedCustomer.Name = Name;
                    editedCustomer.Surname = Surname;
                    editedCustomer.Address = Address;
                    editedCustomer.City = City;
                    editedCustomer.PhoneNumber = phone;
                    editedCustomer.Email = Email;

                    var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                    window?.Close();
                }
            }
        }

        private bool CheckInputs()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname) ||
                string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(City) ||
                string.IsNullOrEmpty(PhoneNumber.ToString()) || string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Všechna pole musí být vyplněna.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!long.TryParse(PhoneNumber.ToString(), out _))
            {
                MessageBox.Show("Telefonní číslo musí být číslo.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            string emailRegex = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(Email, emailRegex))
            {
                MessageBox.Show("Nesprávný formát e-mailu.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;

        }


        private static void Close()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window?.Close();
        }

        private static void Maximize()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            if (window != null)
            {
                if (window.WindowState == WindowState.Normal)
                {
                    window.WindowState = WindowState.Maximized;
                }
                else
                {
                    window.WindowState = WindowState.Normal;
                }
            }
        }

        private static void Minimize()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

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


        public string BtnText
        {
            get => _btnText;
            set => SetProperty(ref _btnText, value, nameof(BtnText));
        } 
        public string WindowName
        {
            get => _windowName;
            set => SetProperty(ref _windowName, value, nameof(WindowName));
        }
    }
}
