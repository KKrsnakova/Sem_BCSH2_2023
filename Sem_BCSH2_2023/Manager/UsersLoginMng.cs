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
    public class UsersLoginMng
    {

        public Repo2<UserLogins> UserLoginsRepo { get; set; }

        public UsersLoginMng(Repo customersRepo)
        {
            UserLoginsRepo = new Repo2<UserLogins>
            {
                Collection = customersRepo.GetInstance().GetCollection<UserLogins>("UserLogins")
            };
        }

        public UserLogins GetByIdUserLogins(int id)
        {
            return UserLoginsRepo.GetById(id);
        }

        public ObservableCollection<UserLogins> GetAllUserLogins()
        {
            return UserLoginsRepo.GetAll();
        }

        public void AddAllUserLogins(ObservableCollection<UserLogins> list)
        {
            UserLoginsRepo.AddAll(list);
        }

        public void RemoveAllUserLogins()
        {
            UserLoginsRepo.RemoveAll();
        }
    }
}
