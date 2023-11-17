using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Manager
{
    public class OrderMng
    {

        public Repo2<Order> OrderRepo { get; set; }
        public OrderMng(Repo orderRepo)
        {
            OrderRepo = new Repo2<Order>();
            OrderRepo.Collection = orderRepo.GetInstance().GetCollection<Order>("Order");
        }

        public Order GetByIdOrder(int id)
        {
            return OrderRepo.GetById(id);
        }

        public ObservableCollection<Order> GetAllOrder()
        {
            return OrderRepo.GetAll();
        }

        public void AddAllOrder(ObservableCollection<Order> list)
        {
            OrderRepo.AddAll(list);
        }

        public void RemoveAllOrder()
        {
            OrderRepo.RemoveAll();
        }

    }
}
