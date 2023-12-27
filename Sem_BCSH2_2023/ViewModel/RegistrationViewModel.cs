using CommunityToolkit.Mvvm.Input;
using FontAwesome.Sharp;
using Microsoft.VisualBasic.ApplicationServices;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Sem_BCSH2_2023.ViewModel
{
    public class RegistrationViewModel : BaseViewModel
    {
        private UserLogins editedUser;
        private UserLogins newUser;
        private int _id;
        private string _username;
        private string _password;
        private string _password2;
        private string _fullname;
        private string _email;

        private string _tbRegistrationToSystem;
        private string _btnDoneText;

        private int? idOfEditedUser;


        private static ObservableCollection<UserLogins> users;
        private UsersLoginMng UserLoginMng { get; set; }


        public ICommand RegistrationDoneCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand MaximizeCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }


        public RegistrationViewModel(int? id)
        {
            idOfEditedUser = id;
            editedUser = null;
            TBRegistratinToSystem = "Registrace do systému";
            BtnDoneText = "Registrovat se";

            if (newUser != null)
            {
                Id = newUser.Id;
                Username = newUser.Username;
                Password = newUser.Password;
                FullName = newUser.FullName;
                Email = newUser.Email;
            }
            else if (id != null)
            {
                TBRegistratinToSystem = "Editace uživatele";
                BtnDoneText = "Dokončit úpravy";
                editedUser = UsersViewModel.UsersList.FirstOrDefault(customer => customer.Id == id);
                FullName = editedUser.FullName;
                Username = editedUser.Username;
                Email = editedUser.Email;
                Password = editedUser.Password;
            }


            RegistrationDoneCommand = new CommandViewModel(_ => RegistrationDone());
            CloseCommand = new CommandViewModel(_ => Close());
            MaximizeCommand = new CommandViewModel(_ => Maximize());
            MinimizeCommand = new CommandViewModel(_ => Minimize());
            users = new ObservableCollection<UserLogins>();
        }



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
        public string Password2
        {
            get => _password2;
            set => SetProperty(ref _password2, value, nameof(Password2));
        }
        public string FullName
        {
            get => _fullname;
            set => SetProperty(ref _fullname, value, nameof(FullName));
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value, nameof(Email));
        } 
        
        public string TBRegistratinToSystem
        {
            get => _tbRegistrationToSystem;
            set => SetProperty(ref _tbRegistrationToSystem, value, nameof(TBRegistratinToSystem));
        }
        
        public string BtnDoneText
        {
            get => _btnDoneText;
            set => SetProperty(ref _btnDoneText, value, nameof(BtnDoneText));
        }

       
        private void RegistrationDone()
        {
            if (idOfEditedUser != null && editedUser != null)
            {
                editedUser = UsersViewModel.UsersList.FirstOrDefault(user => user.Id == idOfEditedUser);
                MessageBox.Show(editedUser.Id + " " + editedUser.FullName + " " + editedUser.Username);
               
                editedUser.FullName = FullName;
                editedUser.Username = Username;
                editedUser.Email = Email;
                editedUser.Password = Password;

                var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                window?.Close();
            }
            else
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

                            string name = FullName;
                            string username = Username;
                            string email = Email;
                            string password = Password;

                            UserLogins newUser = RegisterUser(IdGenerator(), username, password, name, email);
                            users.Add(newUser);

                            UserLoginMng.RemoveAllUserLogins();
                            UserLoginMng.AddAllUserLogins(users);


                            MessageBox.Show("Registrováno");

                            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                            window?.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Chyba při registraci: {ex.Message}");
                    }
                }

            }
        }


        private UserLogins RegisterUser(int countID, string username, string password, string fullname, string email)
        {
           
            UserLogins newUser = new UserLogins(IdGenerator(), username, password, fullname, email);

            return newUser;

        }


        private bool CheckInputs()
        {
            string name = FullName;
            string username = Username;
            string email = Email;
            string password = Password;
            string passwordChecked = Password2;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Všechna pole musí být vyplněna. Chybí jmeno", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Všechna pole musí být vyplněna. Chybí Username", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Všechna pole musí být vyplněna. Chybí email", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Všechna pole musí být vyplněna. Chybí heslo" + Password, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(passwordChecked))
            {
                MessageBox.Show("Všechna pole musí být vyplněna. Chybí heslo2", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private static int IdGenerator()
        {
            int pocet;
            if (users.Count == 0)
            {
                pocet = 1;
            }
            else
            {
                pocet = users.Last().Id;
                pocet++;
            }
            return pocet;
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
