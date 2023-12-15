using CommunityToolkit.Mvvm.Input;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using Sem_BCSH2_2023.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public static ObservableCollection<UserLogins> Users { get; set; } = new ObservableCollection<UserLogins>();
        public UsersLoginMng UserLoginMng { get; set; }

        public ICommand CloseCommand { get; private set; }
        public ICommand MaximizeCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }



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

            LoginCommand = new CommandViewModel(_ => OnLogin());

            CloseCommand = new CommandViewModel(_ => Close());
            MaximizeCommand = new CommandViewModel(_ => Maximize());
            MinimizeCommand = new CommandViewModel(_ => Minimize());
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

        public ICommand LoginCommand { get; }

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
                        MainViewModel mainViewModel = new MainViewModel();
                        mainViewModel.ActualUser = LoggedInUser;

                        MainView mainView = new MainView
                        {
                            DataContext = mainViewModel
                        };
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


        private void Close()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window?.Close();
        }

        private static void Maximize()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            if (window != null)
            {
                if (window.WindowState == WindowState.Normal)
                {
                    window.WindowState = WindowState.Maximized;
                }
                else
                {
                    window.WindowState = WindowState.Normal;
                }
            }
        }

        private static void Minimize()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

    }
}
