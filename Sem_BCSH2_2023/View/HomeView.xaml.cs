﻿using Microsoft.VisualBasic.ApplicationServices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private UserLogins _loggedInUser;
        private ObservableCollection<UserLogins> users;

        private UsersLoginMng UserLoginMng { get; set; }
        private readonly HomeViewModel homeViewModel;


        public HomeView()
        {
            InitializeComponent();
             homeViewModel = new HomeViewModel(MainView.GetCurrentUser());
            _loggedInUser = homeViewModel.ActualUser;
            users = new ObservableCollection<UserLogins>();
            tbPassword.IsReadOnly = true;
            SetBoxes();

        }
       

        private void SetBoxes( )
        {
            tbFullName.Text = _loggedInUser.FullName;
            tbEmail.Text = _loggedInUser.Email;
            tbUserLogin.Text = _loggedInUser.Username;
            tbPassword.Text = _loggedInUser.Password;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
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
                        string username = tbUserLogin.Text;
                        string email = tbEmail.Text;

                        var userToUpdate = users.FirstOrDefault(u => u.FullName == _loggedInUser.FullName);

                        if (userToUpdate != null)
                        {
                            // Aktualizuj údaje
                            userToUpdate.FullName = name;
                            userToUpdate.Username = username;
                            userToUpdate.Email = email;

                            _loggedInUser = userToUpdate;
                            // Aktualizuj seznam uživatelů
                            UserLoginMng.RemoveAllUserLogins();
                            UserLoginMng.AddAllUserLogins(users);

                            MessageBox.Show("Upraveno");
                            SetBoxes();
                        }
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
            string username = tbUserLogin.Text;
            string email = tbEmail.Text;
           

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Všechna pole musí být vyplněna.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
