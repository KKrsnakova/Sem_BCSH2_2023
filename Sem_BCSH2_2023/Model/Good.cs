using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Model
{
    public class Good : BaseViewModel
    {
        private int _id;
        private string _name;
        private double _price;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value, nameof(Id));
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }
        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value, nameof(Price));
        }

        public Good(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
