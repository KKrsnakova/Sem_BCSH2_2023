using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.ViewModel
{
    public class OrderViewModel: BaseViewModel
    {

        public static ObservableCollection<Order> OrderList= new();

        //public OrderViewModel()
        //{
        //    OrderList.Add(new Order(10, 1, DateTime.Now));
        //    OrderList.Add(new Order(120, 2, DateTime.Now));
        //}

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
    }
}
