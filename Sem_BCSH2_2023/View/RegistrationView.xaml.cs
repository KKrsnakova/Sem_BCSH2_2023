using Microsoft.VisualBasic.ApplicationServices;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        private ObservableCollection<UserLogins> users;
        private UsersLoginMng UserLoginMng { get; set; }

        public RegistrationView()
        {
            InitializeComponent();
            users = new ObservableCollection<UserLogins>();

        }


        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs())
            {
                try
                {
                    using (var repoLogin = new RepoLogin())
                    {
                        UserLoginMng = new UsersLoginMng(repoLogin);
                        users.Clear();
                        users = UserLoginMng.GetAllUserLogins();

                        string name = tbFullName.Text;
                        string username = tbLogin.Text;
                        string email = tbEmail.Text;
                        string password = tbPasswordFirst.Password;

                        UserLogins newUser = RegistrationViewModel.RegisterUser(users.Count, username, password, name, email);
                        users.Add(newUser);


                        UserLoginMng.RemoveAllUserLogins();
                        UserLoginMng.AddAllUserLogins(users);

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba při registraci: {ex.Message}");
                }
            }
        }

        private bool CheckInputs()
        {
            string name = tbFullName.Text;
            string username = tbLogin.Text;
            string email = tbEmail.Text;
            string password = tbPasswordFirst.Password;
            string passwordChecked = tbPasswordCheck.Password;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordChecked))
            {
                MessageBox.Show("Všechna pole musí být vyplněna.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (password != passwordChecked)
            {
                MessageBox.Show("Hesla se neshodují.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            string emailform = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, emailform))
            {
                MessageBox.Show("Nesprávný formát e-mailu.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMaximal_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }


        private void BtnMinimal_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void NavBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }



        private void NavBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

    }
}
