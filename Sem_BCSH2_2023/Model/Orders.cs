using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Model
{
    public class Orders
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public float OrderPrice { get; set; }
        public DateTime DateOfCreation { get; set; }
        public ObservableCollection<Goods> ListOfGoods { get; set; }
        public bool Done { get; set; }
        public DateTime? DateCompletion { get; set; }

        public Orders(int id, int customerId, DateTime dateOfCreation)
        {
            Id = id;
            CustomerId = customerId;
            OrderPrice = 0;
            DateOfCreation = dateOfCreation;
            ListOfGoods = new ObservableCollection<Goods>();
            Done = false;
            DateCompletion = null;
        }

        public void SellGoods(Goods goods)
        {
            ListOfGoods.Add(goods);
        }

        public void RemoveGoods(int index)
        {
            ListOfGoods.Remove(ListOfGoods[index]);
        }
    }
}
