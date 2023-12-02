using Microsoft.VisualBasic.ApplicationServices;
using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sem_BCSH2_2023.ViewModel
{
    public class RegistrationViewModel
    {

        public RegistrationViewModel( )
        {
            
        }

        public static UserLogins RegisterUser(int countID, string username, string password, string fullname, string email)
        {
            int count = countID + 1;
            UserLogins newUser =  new UserLogins(count, username, password, fullname, email);
            
            return newUser;

        }

        
    }
}
