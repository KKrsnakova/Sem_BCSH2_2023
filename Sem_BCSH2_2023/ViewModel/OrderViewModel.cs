using Microsoft.VisualBasic.ApplicationServices;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;



namespace Sem_BCSH2_2023.ViewModel
{

    public class OrderViewModel : BaseViewModel
    {
        public OtherItems? otherItem;

        public static ObservableCollection<Order> OrderList = new();
        public static ObservableCollection<User> UserList = new();


        private ObservableCollection<Customer> _customerListShow;
        private string _fullNameCustomer;
        private bool _showCompletedOrders;


        public ICommand AddNewCommand { get; private set; }
        public ICommand DeleteAllCommand { get; private set; }
        public ICommand AddNewCustomerCommand { get; private set; }


        public ICommand DeleteOrderCom { get; }
        public ICommand EditOrderCom { get; }
        public ICommand MakeOrderDoneCom { get; }

        public OrderViewModel()
        {
            CustomerListShow = CustomerViewModel.CustomersList;
         //   OrderListShow = OrderList;

            AddNewCommand = new CommandViewModel(_ => AddNewOrder());
            DeleteAllCommand = new CommandViewModel(_ => DeleteAllOrders());
            AddNewCustomerCommand = new CommandViewModel(_ => AddNewCustomer());


            DeleteOrderCom = new CommandViewModel(DeleteOrder);
            EditOrderCom = new CommandViewModel(EditOrder);
            MakeOrderDoneCom = new CommandViewModel(MakeOrderDone);

        }

      

        private void AddNewCustomer()
        {
            AddEditCustomer windowAddCustomer = new AddEditCustomer(null);
            windowAddCustomer.Show();
        }

        private void MakeOrderDone(object obj)
        {
            if (obj is Order order)
            {
                OrderDone(order);
                OrderDateCompletion(order);
            }
        }

        private void EditOrder(object obj)
        {

            if (obj is Order order)
            {

                if (CustomerViewModel.CustomersList.Any(customer => customer.Id == order.CustomerId))
                {
                    NewOrderView windowEditGoods = new(order, order.CustomerId);
                    windowEditGoods.Show();
                }
                else
                {
                    MessageBox.Show("Zákazník byl smazán");
                }
            }
        }

        private void DeleteOrder(object obj)
        {

            if (obj is Order order)
            {
                RemoveOrder(order);
            }
        }

        private void DeleteAllOrders()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete odstranit všechny položky?", 
                "Potvrzení odstranění", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                RemoveAllOrder();
            }
        }

        private async void AddNewOrder()
        {
            if (CustomerViewModel.CustomersList == null || !CustomerViewModel.CustomersList.Any())
            {
                MessageBox.Show("Neexistuje žádný zákazník.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                await Task.Run(() =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        NewOrderView windowNewOrder = new NewOrderView(null, null);
                        windowNewOrder.Show();
                    });
                });
            }
        }

        public static Order NewOrder()
        {
            Order order = new(IdGenerator(), 1, "", "", DateTime.Now);
            return order;
        }



        public static void RemoveOrder(Order selectedOrder)
        {
            OrderList.Remove(selectedOrder);
        }

        public static void RemoveAllOrder()
        {
            OrderList.Clear();
        }

        public void OrderDone(Order selectedOrder)
        {

            selectedOrder.Done = !selectedOrder.Done;

        }
        public void OrderDateCompletion(Order selectedOrder)
        {
            selectedOrder.DateCompletion = DateTime.Now;
        }



        private static int IdGenerator()
        {
            int pocet;
            if (OrderList.Count == 0)
            {
                pocet = 1;
            }
            else
            {
                pocet = OrderList.Last().Id;
                pocet++;
            }
            return pocet;
        }

        public static double OrderPrice(Order order)
        {
            double price = 0;
            foreach (var item in order.ListOfGoods)
            {
                price += item.Price;
            }
            return price;
        }


        public static string GetCustomerNameById(int customerId)
        {
            var customer = CustomerViewModel.CustomersList.FirstOrDefault(c => c.Id == customerId);
            return customer != null ? $"{customer.Name} {customer.Surname}" : $"Customer {customerId} Not Found";
        }


        public ObservableCollection<Customer> CustomerListShow
        {
            get => _customerListShow;
            set => SetProperty(ref _customerListShow, value, nameof(CustomerListShow));
        }

        public ObservableCollection<Order> OrderListShow
        {
            get => OrderList;
            set => SetProperty(ref OrderList, value, nameof(OrderList));
        }

        public string FullNameCustomer
        {
            get => _fullNameCustomer;
            set => SetProperty(ref _fullNameCustomer, value, nameof(FullNameCustomer));
        }

        public bool ShowCompletedOrders
        {
            get => _showCompletedOrders;
            set
            {
                SetProperty(ref _showCompletedOrders, value, nameof(ShowCompletedOrders));
                ApplyFilters();
            }

        }

        //private void ApplyFilters()
        //{
        //    OnPropertyChanged(nameof(OrderListShow));
        //}




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
            ICollectionView view = CollectionViewSource.GetDefaultView(OrderList);
            if (view != null)
            {
                view.Filter = OrderFilter;
            }
        }

        private bool OrderFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                return true;
            }

            if (item is Order order)
            {
                return order.FullName.ToLower().Contains(SearchText.ToLower()) ||
                       order.DateOfCreation.ToString().ToLower().Contains(SearchText.ToLower());
            }

            return false;
        }




    }
}
