using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Model
{
    public class OtherItems : Good
    {
        private string _usage;
        private int _count;

        public string Usage
        {
            get => _usage;
            set => SetProperty(ref _usage, value, nameof(Usage));
        }
        public int CountInPackage
        {
            get => _count;
            set => SetProperty(ref _count, value, nameof(CountInPackage));
        }

        public OtherItems(int id, string name, double price, string usage, int count) : base(id, name, price)
        {
            Usage = usage;
            CountInPackage = count;
        }
    }
}
