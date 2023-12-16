using Microsoft.VisualBasic.ApplicationServices;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    public class OrderViewModel : BaseViewModel
    {

        public static ObservableCollection<Order> OrderList = new();
        public  static ObservableCollection<User> UserList = new();


        private ObservableCollection<Customer> _customerListShow;
        private ObservableCollection<Order> _orderListShow;

        public ICommand AddNewCommand { get; private set; }
        public ICommand DeleteAllCommand { get; private set; }

        public OrderViewModel()
        {
            CustomerListShow = CustomerViewModel.CustomersList;
            OrderListShow = OrderList;

            AddNewCommand = new CommandViewModel(_ => AddNewOrder());
            DeleteAllCommand = new CommandViewModel(_ => DeleteAllOrders());
        }

        private void DeleteAllOrders()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete odstranit všechny položky?", "Potvrzení odstranění", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                OrderViewModel.RemoveAllOrder();
            }
        }

        private void AddNewOrder()
        {
                NewOrderView windowNewOrder = new NewOrderView(null, null);
                windowNewOrder.Show();
            
        }

        public static Order NewOrder()
        {
            Order order = new(IdGenerator(), 1, "", "", DateTime.Now);
            return order;
        }

        public static void AddOrder(Order order)
        {
            OrderList.Add(order);
        }


        public static void RemoveOrder(Order selectedOrder)
        {
            OrderList.Remove(selectedOrder);
        }

        public static void RemoveAllOrder()
        {
            OrderList.Clear();
        }

        public  void OrderDone(Order selectedOrder)
        {

            selectedOrder.Done = !selectedOrder.Done;

        }
        public  void OrderDateCompletion(Order selectedOrder)
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
            get => _orderListShow;
            set => SetProperty(ref _orderListShow, value, nameof(OrderListShow));
        }


    }
}
