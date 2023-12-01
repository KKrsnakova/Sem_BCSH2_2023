using CommunityToolkit.Mvvm.Input;
using FontAwesome.Sharp;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using Sem_BCSH2_2023.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        //repos
        public GoodsMng GoodsMng { get; set; }
        public CustomerMng CustomerMng { get; set; }
        public OrderMng OrderMng { get; set; }
        public Repo Repo { get; set; }







        private BaseViewModel currentChildView;
        private string description;
        private IconChar icon;

        public BaseViewModel CurrentChildView
        {
            get
            {
                return currentChildView;
            }
            set
            {
                currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public IconChar Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowFlowerViewCommand { get; }
        public ICommand ShowGoodsViewCommand { get; }
        public ICommand ShowCustomersViewCommand { get; }
        public ICommand ShowOrdersViewCommand { get; }
        public ICommand LogOut { get; }
        public ICommand SaveData { get; }




        public MainViewModel()
        {

            //Initialize commands
            ShowHomeViewCommand = new CommandViewModel(ExecuteShowHomeViewCommand);
            ShowFlowerViewCommand = new CommandViewModel(ExecuteShowFlowerViewCommand);
            ShowGoodsViewCommand = new CommandViewModel(ExecuteShowGoodsViewCommand);
            ShowCustomersViewCommand = new CommandViewModel(ExecuteShowCustomersViewCommand);
            ShowOrdersViewCommand = new CommandViewModel(ExecuteShowOrdersViewCommand);
            LogOut = new CommandViewModel(LogOutCom);
            SaveData = new CommandViewModel(SaveDataCom);



            Repo = new();
            GoodsMng = new GoodsMng(Repo);
            CustomerMng = new CustomerMng(Repo);
            OrderMng = new OrderMng(Repo);

            GoodViewModel.GoodsList = GoodsMng.GetAllGoods();
            CustomerViewModel.CustomersList = CustomerMng.GetAllCustomers();
            OrderViewModel.OrderList = OrderMng.GetAllOrder();

        }

        private void SaveDataCom(object obj)
        {
            GoodsMng.RemoveAllGoods();
            GoodsMng.AddAllGoods(GoodViewModel.GoodsList);

            CustomerMng.RemoveAllCustomers();
            CustomerMng.AddAllCustomers(CustomerViewModel.CustomersList);

            OrderMng.RemoveAllOrder();
            OrderMng.AddAllOrder(OrderViewModel.OrderList);

            MessageBox.Show("Data SNAD uložena do databáze", "Uloženo do DB", MessageBoxButton.OK);

        }

        private void LogOutCom(object obj)
        {
            MessageBox.Show("Odhlášeno");
            //Repo.Dispose();
            // Uzavřít aktuální okno
            Window currentWindow = App.Current.Windows[0];
            LoginView loginView = new LoginView();


            // Vytvořit a zobrazit nové přihlašovací okno

            loginView.Show();
            currentWindow.Close();

        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel(MainView.GetCurrentUser());
            Description = "Přehled";
            Icon = IconChar.UserGroup;
        }
        private void ExecuteShowFlowerViewCommand(object obj)
        {
            CurrentChildView = new FlowerViewModel();
            Description = "Květiny";
            Icon = IconChar.Sun;
        }

        private void ExecuteShowGoodsViewCommand(object obj)
        {
            CurrentChildView = new GoodViewModel();
            Description = "Zboží";
            Icon = IconChar.Tree;
        }

        private void ExecuteShowCustomersViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Description = "Zákazníci";
            Icon = IconChar.UserGroup;
        }
        
               
        private void ExecuteShowOrdersViewCommand(object obj)
        {
            CurrentChildView = new OrderViewModel();
            Description = "Objednávky";
            Icon = IconChar.ShoppingBasket;
        }

       

    }

}