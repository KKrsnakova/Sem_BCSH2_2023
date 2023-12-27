using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    public class UsersViewModel : BaseViewModel
    {
        private ObservableCollection<UserLogins> _usersListShow;

        public static ObservableCollection<UserLogins> UsersList = new ObservableCollection<UserLogins>();
        public static UserLogins? userLoginStat;

        public ICommand DeleteUserCom { get; }
        public ICommand AddNewUserCom { get; }
        public ICommand EditUserCom { get; }
        public ICommand AdminOrUserCom { get; }


        public UsersViewModel()
        {

            UsersListShow = UsersList;


            AddNewUserCom = new CommandViewModel(AddUser);
            DeleteUserCom = new CommandViewModel(DeleteUser);
            EditUserCom = new CommandViewModel(EditUser);
            AdminOrUserCom = new CommandViewModel(AdminOrUser);
        }

        private void AdminOrUser(object obj)
        {
            if (obj is UserLogins item)
            {
                item.IsAdmin = !item.IsAdmin;

            }
        }

        private void AddUser(object obj)
        {
            RegistrationView windowEditUser = new(null);
            windowEditUser.ShowDialog();

        }

        private void EditUser(object obj)
        {
            if (obj is UserLogins item)
            {
                userLoginStat = item;
                int selectedId = userLoginStat.Id;

                RegistrationView windowEditUser = new(selectedId);
                windowEditUser.ShowDialog();

            }
        }

        private void DeleteUser(object obj)
        {
            if (obj is UserLogins user)
            {
                RemoveUser(user);
            }
        }


        public static void RemoveUser(UserLogins selectedUser)
        {

            UsersList.Remove(selectedUser);
        }

        public ObservableCollection<UserLogins> UsersListShow
        {
            get => _usersListShow;
            set => SetProperty(ref _usersListShow, value, nameof(UsersListShow));
        }




        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    ApplyFilters();
                }
            }
        }

        private void ApplyFilters()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(UsersList);
            if (view != null)
            {
                view.Filter = UserFilter;
            }
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                return true;
            }

            if (item is UserLogins user)
            {
                return user.FullName.ToLower().Contains(SearchText.ToLower()) ||
                       user.Email.ToString().ToLower().Contains(SearchText.ToLower());
            }

            return false;
        }


    }
}