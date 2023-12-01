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

        private string _username;
        private string _password;
        private string _fullname;

        public string FullN
        {
            get => _fullname;
            //set => SetProperty(ref _fullname, value, nameof(FullName));
            set => OnPropertyChanged(nameof(FullN));
        }

        public string Usern
        {
            get => _username;
            set => SetProperty(ref _username, value, nameof(Usern));
        }

        public string Passw
        {
            get => _password;
            set => SetProperty(ref _password, value, nameof(Passw));
        }

    }
}
