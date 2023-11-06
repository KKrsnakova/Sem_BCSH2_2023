using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Model
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Goods(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
