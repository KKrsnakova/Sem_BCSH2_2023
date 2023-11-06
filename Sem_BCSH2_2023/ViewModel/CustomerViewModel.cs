using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.ViewModel
{
    public class CustomerViewModel:BaseViewModel
    {
        public static ObservableCollection<Customer> customersList = new ObservableCollection<Customer>();

        public CustomerViewModel()
        {
            //customersList.Add(new Customer(1, "adam", "novák", "adresa 123", "city", 789456123, "asdasd@xd.cz"));
            //customersList.Add(new Customer(2, "das", "sssss", "adresa 1883", "city", 155456789, "asdasd@xd.cz"));
            //customersList.Add(new Customer(3, "jan", "novák", "asd 123", "ssss", 123456789, "asdasd@xd.cz"));
        }
    }
}
