using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Manager
{
   public class CustomerMng
    {

        public Repo2<Customer> CustomersRepo { get; set; }

        public CustomerMng(Repo customersRepo)
        {
            CustomersRepo = new Repo2<Customer>();
            CustomersRepo.Collection = customersRepo.GetInstance().GetCollection<Customer>("Customer");
        }

        public Customer GetByIdCustomers(int id)
        {
            return CustomersRepo.GetById(id);
        }

        public ObservableCollection<Customer> GetAllCustomers()
        {
            return CustomersRepo.GetAll();
        }

        public void AddAllCustomers(ObservableCollection<Customer> list)
        {
            CustomersRepo.AddAll(list);
        }

        public void RemoveAllCustomers()
        {
            CustomersRepo.RemoveAll();
        }
    }
}
