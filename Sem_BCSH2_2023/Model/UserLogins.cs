using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;

namespace Sem_BCSH2_2023.Model
{
    public class UserLogins : BaseViewModel
    {
        private int _id;
        private string _username;
        private string _password;
        private string _fullname;
        private string _email;


        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value, nameof(Id));
        }
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value, nameof(Username));
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value, nameof(Password));
        }
        public string FullName
        {
            get => _fullname;
            set => SetProperty(ref _fullname, value, nameof(FullName));
        }
        public string Email {
            get => _email;
            set => SetProperty(ref _email, value, nameof(Email));
        }


        public UserLogins(int id, string username, string password, string fullName, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
        }

        public override string? ToString()
        {
            return FullName;
        }
    }
}
