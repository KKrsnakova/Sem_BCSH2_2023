using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        public static ObservableCollection<Customer> CustomersList = new ObservableCollection<Customer>();

        public CustomerViewModel()
        {
        }

        public static void AddCustomer(string nameAdd, string surnameAdd,
                                        string addressAdd, string cityAdd,
                                        long phoneAdd, string emailAdd)
        {
            CustomersList.Add(new Customer(id: IdGenerator(),
                nameAdd, surnameAdd, addressAdd, cityAdd, phoneAdd, emailAdd));
        }

        public static void RemoveCustomer(Customer selectedCustomer)
        {
            CustomersList.Remove(selectedCustomer);
        }

        private static int IdGenerator()
        {
            int pocet;
            if (CustomersList.Count() == 0)
            {
                pocet = 1;
            }
            else
            {
                pocet = CustomersList.Last().Id;
                pocet++;
            }
            return pocet;
        }

    }
}
