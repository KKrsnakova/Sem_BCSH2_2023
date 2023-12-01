using CommunityToolkit.Mvvm.Input;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using Sem_BCSH2_2023.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Sem_BCSH2_2023.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public static ObservableCollection<UserLogins> Users { get; set; } = new ObservableCollection<UserLogins>();
        public UsersLoginMng UserLoginMng { get; set; }



        private bool isLoggedIn;

        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set
            {
                isLoggedIn = value;
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public LoginViewModel()
        {

                //Users.Add(new UserLogins("admin", "admin", "add add", "admin@admin.cz"));
                //Users.Add(new UserLogins("pepa", "12", "Pepa Pepaaa", "pepa@admin.cz"));
 
            LoginCommand = new RelayCommand(OnLogin);
        }

        private string _username;
        private string _password;

       
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

        public RelayCommand LoginCommand { get; }

        public UserLogins LoggedInUser { get; set; }

        private void OnLogin()
        {
            try
            {
                using (var repoLogin = new RepoLogin())
                {
                    UserLoginMng = new UsersLoginMng(repoLogin);

                    Users = UserLoginMng.GetAllUserLogins();
                    LoggedInUser = Users.FirstOrDefault(user => user.Username == Username && user.Password == Password);

                    if (LoggedInUser != null)
                    {
                        MainView mainView = new MainView(LoggedInUser);
                        mainView.Show();
                        App.Current.Windows[0].Close();
                    }
                    else
                    {
                        MessageBox.Show("Špatné přihlašovací údaje", "Chyba");
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
