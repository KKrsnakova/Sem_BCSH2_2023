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
        public ObservableCollection<UserLogins> Users { get; } = new ObservableCollection<UserLogins>();

        public LoginViewModel()
        {
            Users.Add(new UserLogins("admin", "admin"));
            Users.Add(new UserLogins("pepa", "12"));
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

        private void OnLogin()
        {
            bool isValidCredentials = Users.Any(user => user.Username == Username && user.Password == Password);

            if (isValidCredentials)
            {
                MainView mainView = new MainView();
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
