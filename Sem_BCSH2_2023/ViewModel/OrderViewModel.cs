using Sem_BCSH2_2023.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sem_BCSH2_2023.ViewModel
{
    public class OrderViewModel: BaseViewModel
    {

        public static ObservableCollection<Order> OrderList= new();




        //public static void AddOrder(Customer customerAdd)
        //{
        //   OrderList.Add(new Order(IdGenerator(), customerAdd.Id, customerAdd.Name, customerAdd.Surname, DateTime.Now));
        //}

        public static Order NewOrder()
        {
            Order order = new Order(IdGenerator(), 1, "test", "test", DateTime.Now);
            return order;
        }

        public static void AddOrder(Order order)
        {
             OrderList.Add(order);
            
           // OrderList.Add(new Order(IdGenerator(), customerAdd.Id, customerAdd.Name, customerAdd.Surname, DateTime.Now));
        }


        public static void RemoveOrder(Order selectedOrder)
        {
            OrderList.Remove(selectedOrder);
        }

        public static void RemoveAllOrder()
        {
            OrderList.Clear();
        }

        public static void OrderDone(Order selectedOrder)
        {

            selectedOrder.Done = !selectedOrder.Done;
           
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

        public static double OrderPrice (Order order)
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


    }
}
