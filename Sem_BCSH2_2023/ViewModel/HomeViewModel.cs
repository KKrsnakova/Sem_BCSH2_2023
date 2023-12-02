using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.ViewModel
{
    public class HomeViewModel: BaseViewModel
    {
        public UserLogins ActualUser { get; set; }
        public HomeViewModel(UserLogins user)
        {
            ActualUser = user;
        }

       
    }
}
