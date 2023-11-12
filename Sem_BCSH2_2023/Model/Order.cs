using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public float OrderPrice { get; set; }
        public DateTime DateOfCreation { get; set; }
        public ObservableCollection<Good> ListOfGoods { get; set; }
        public bool Done { get; set; }
        public DateTime? DateCompletion { get; set; }

        public Order(int id, int customerId, DateTime dateOfCreation)
        {
            Id = id;
            CustomerId = customerId;
            OrderPrice = 0;
            DateOfCreation = dateOfCreation;
            ListOfGoods = new ObservableCollection<Good>();
            Done = false;
            DateCompletion = null;
        }

        public void SellGoods(Good goods)
        {
            ListOfGoods.Add(goods);
        }

        public void RemoveGoods(int index)
        {
            ListOfGoods.Remove(ListOfGoods[index]);
        }
    }
}
