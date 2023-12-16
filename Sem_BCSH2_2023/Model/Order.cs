using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sem_BCSH2_2023.Model
{
    public class Order : BaseViewModel
    {
        private int _id;
        private int _customerId;
        private double _orderPrice;
        private DateTime _orderDate;
        private bool _done;
        private DateTime? _doneDate;
        private ObservableCollection<Good> _listOfGoods;
        private string _fullname;

      

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value, nameof(Id));
        }
        public int CustomerId
        {
            get => _customerId;
            set => SetProperty(ref _customerId, value, nameof(CustomerId));
        }
        public double OrderPrice
        {
            get => _orderPrice;
            set => SetProperty(ref _orderPrice, value, nameof(OrderPrice));
        }
        public DateTime DateOfCreation
        {
            get => _orderDate;
            set => SetProperty(ref _orderDate, value, nameof(DateOfCreation));
        }
        public ObservableCollection<Good> ListOfGoods
        {
            get => _listOfGoods;
            set => SetProperty(ref _listOfGoods, value, nameof(ListOfGoods));
        }
        public bool Done
        {
            get => _done;
            set => SetProperty(ref _done, value, nameof(Done));
        }
        public DateTime? DateCompletion
        {
            get => _doneDate;
            set => SetProperty(ref _doneDate, value, nameof(DateCompletion));
        }

        public string FullName
        {
            get => _fullname;
            set => SetProperty(ref _fullname, value, nameof(FullName));
        }


        public Order(int id, int customerId, string name, string surname, DateTime dateOfCreation)
        {
            Id = id;
            FullName = name + " " + surname;
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
