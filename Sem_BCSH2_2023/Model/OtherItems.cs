using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Model
{
    public class OtherItems: Goods
    {
        public string Description { get; set; }

        public OtherItems(int id, string name, double price, string description): base(id, name, price)
        {
            Description = description;
        }
    }
}
