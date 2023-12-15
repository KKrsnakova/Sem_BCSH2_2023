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
        private string _packageType;

        public string Usage
        {
            get => _usage;
            set => SetProperty(ref _usage, value, nameof(Usage));
        }
        public string PackageType
        {
            get => _packageType;
            set => SetProperty(ref _packageType, value, nameof(PackageType));
        }

        public OtherItems(int id, string name, double price, string usage, string packageType) : base(id, name, price)
        {
            Usage = usage;
            PackageType = packageType;
        }
    }
}
