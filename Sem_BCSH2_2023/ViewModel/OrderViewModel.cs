using Sem_BCSH2_2023.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sem_BCSH2_2023.ViewModel
{
    public class OrderViewModel: BaseViewModel
    {

        public static ObservableCollection<Order> OrderList= new();

      

        public static void AddOrder(int customerIdAdd)
        {
           OrderList.Add(new Order(IdGenerator(), customerIdAdd, DateTime.Now));
        }

        public static Order NewOrder(int customerIdAdd)
        {
            Order order = new Order(IdGenerator(), customerIdAdd, DateTime.Now);
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


    }
}
