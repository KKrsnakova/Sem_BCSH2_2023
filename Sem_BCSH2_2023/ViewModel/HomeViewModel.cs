using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic.ApplicationServices;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using Sem_BCSH2_2023.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sem_BCSH2_2023.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private string _fullName;
        private string _username;
        private string _password;
        private string _email;
        private int _id;


        public ObservableCollection<UserLogins> Users { get; set; } = new ObservableCollection<UserLogins>();
        public UsersLoginMng UserLoginMng { get; set; }


        public UserLogins User { get; set; }
        public UserLogins userToEdit { get; set; }
        public MainViewModel MainVM { get; set; }
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public RelayCommand EditCommand { get; }


        public HomeViewModel(UserLogins user)
        {
            User = user;

            // Přiřazení hodnot z User do vlastností pro binding
            FullName = User.FullName;
            Username = User.Username;
            Password = User.Password;
            Email = User.Email;
            Id = User.Id;

            EditCommand = new RelayCommand(OnEdit);
        }

        private void OnEdit()
        {

            EditUser();
        }

        private void EditUser()
        {
            User.FullName = FullName;
            User.Username = Username;
            User.Password = Password;
            User.Email = Email;

            try
            {
                using (var repoLogin = new RepoLogin())
                {
                    UserLoginMng = new UsersLoginMng(repoLogin);
                    Users = UserLoginMng.GetAllUserLogins();
                    userToEdit = Users.FirstOrDefault(user => user.Id == User.Id);

                    userToEdit.FullName = FullName;
                    userToEdit.Username = Username;
                    userToEdit.Password = Password;
                    userToEdit.Email = Email;

                    if (userToEdit != null)
                    {
                        UserLoginMng.RemoveAllUserLogins();
                        UserLoginMng.AddAllUserLogins(Users);

                        MessageBox.Show("Upraveno");
                    }
                    else
                    {
                        MessageBox.Show("Chyba", "Chyba");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při přihlašování: {ex.Message}");
            }
        }



    }
}
