using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {

        public static Customer? customer;
        private ObservableCollection<Customer> _customerListShow;

        public ICommand AddCustomers { get; }
        public ICommand DeleteAllCustomer { get; }


        public ICommand DeleteCustomerCom { get; }
        public ICommand EditCustomerCom { get; }



        public static ObservableCollection<Customer> CustomersList = new ObservableCollection<Customer>();

        public CustomerViewModel()
        {
            CustomerListShow = CustomersList;

            AddCustomers = new CommandViewModel(AddCustomer);
            DeleteAllCustomer = new CommandViewModel(DeleteAllCustomerCom);


            DeleteCustomerCom = new CommandViewModel(DeleteCustomer);
            EditCustomerCom = new CommandViewModel(EditCustomer);
        }

        private void EditCustomer(object obj)
        {
           
            if (obj is Customer item)
            {
                customer = item;
                int selectedId = customer.Id;


                AddEditCustomer windowEditCustomer = new(selectedId);
                windowEditCustomer.ShowDialog();

            }
        }

        private void DeleteCustomer(object obj)
        {
           
            if (obj is Customer item)
            {
                RemoveCustomer(item);
            }
        }

        private void DeleteAllCustomerCom(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete odstranit všechny položky? \n Spolu se Zákazniky budou odstraněny i všenchy objednávky",
                                                      "Potvrzení odstranění", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                CustomersList.Clear();
                OrderViewModel.RemoveAllOrder();
            }
        }

        private void AddCustomer(object obj)
        {
            AddEditCustomer windowAddCustomer = new AddEditCustomer(null);
            windowAddCustomer.Show();
        }

        public static void AddCustomer(string nameAdd, string surnameAdd,
                                        string addressAdd, string cityAdd,
                                        long phoneAdd, string emailAdd)
        {
            CustomersList.Add(new Customer(id: IdGenerator(),
                nameAdd, surnameAdd, addressAdd, cityAdd, phoneAdd, emailAdd));
        }

        public static void RemoveCustomer(Customer selectedCustomer)
        {
            CustomersList.Remove(selectedCustomer);

            List<Order> ordersToRemove = OrderViewModel.OrderList.Where(order => order.CustomerId == selectedCustomer.Id).ToList();

            foreach (Order order in ordersToRemove)
            {
                OrderViewModel.OrderList.Remove(order);
            }

        }



        public static Customer GetCustomerById(int customerId)
        {
            Customer selectedCustomer = CustomersList.FirstOrDefault(customer => customer.Id == customerId);
            if (selectedCustomer != null)
            {
                return selectedCustomer;
            }
            else
            {
                MessageBox.Show("Chyba, zakázník není v seznamu  " + selectedCustomer.ToString(), "Chyba", MessageBoxButton.OK);
                return null;
            }

        }



        private static int IdGenerator()
        {
            int pocet;
            if (CustomersList.Count == 0)
            {
                pocet = 1;
            }
            else
            {
                pocet = CustomersList.Last().Id;
                pocet++;
            }
            return pocet;
        }

        public ObservableCollection<Customer> CustomerListShow
        {
            get => _customerListShow;
            set => SetProperty(ref _customerListShow, value, nameof(CustomerListShow));
        }





        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    ApplyFilters();
                }
            }
        }

        private void ApplyFilters()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(CustomersList);
            if (view != null)
            {
                view.Filter = CustomerFilter;
            }
        }

        private bool CustomerFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                return true;
            }

            if (item is Customer customer)
            {
                return customer.Name.ToLower().Contains(SearchText.ToLower()) ||
                         customer.Surname.ToLower().Contains(SearchText.ToLower()) ||
                         customer.Address.ToLower().Contains(SearchText.ToLower()) ||
                         customer.City.ToLower().Contains(SearchText.ToLower()) ||
                         customer.PhoneNumber.ToString().ToLower().Contains(SearchText.ToLower()) ||
                       customer.Email.ToString().ToLower().Contains(SearchText.ToLower());
            }

            return false;
        }


    }
}
