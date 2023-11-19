using CommunityToolkit.Mvvm.Input;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Sem_BCSH2_2023.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public static ObservableCollection<UserLogins> Users { get; set; } = new ObservableCollection<UserLogins>();



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
            Users.Add(new UserLogins("admin", "admin", "admin admin", "admin@admin.cz"));
            Users.Add(new UserLogins("pepa", "12", "Pepa Pepa", "pepa@admin.cz"));
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

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public RelayCommand LoginCommand { get; }

        private UserLogins _loggedInUser;

        private void OnLogin()
        {
            _loggedInUser = Users.FirstOrDefault(user => user.Username == Username && user.Password == Password);

            if (_loggedInUser != null)
            {

                MainView mainView = new MainView(_loggedInUser);
                mainView.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Špatné přihlašovací údaje");
            }
        }

        

    }
}
