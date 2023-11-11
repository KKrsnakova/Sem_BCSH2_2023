using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Model
{
    public class OtherItems: Goods
    {
        public string Usage { get; set; }
        public int Count { get; set; }

        public OtherItems(int id, string name, double price, string usage, int count): base(id, name, price)
        {
            Usage = usage;
            Count = count;
        }
    }
}
