using FontAwesome.Sharp;
using Sem_BCSH2_2023.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
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
        public MainViewModel()
        {

            //Initialize commands
            ShowHomeViewCommand = new CommandViewModel(ExecuteShowHomeViewCommand);
            ShowFlowerViewCommand = new CommandViewModel(ExecuteShowFlowerViewCommand);
            ShowGoodsViewCommand = new CommandViewModel(ExecuteShowGoodsViewCommand);
            ShowCustomersViewCommand = new CommandViewModel(ExecuteShowCustomersViewCommand);
            ShowOrdersViewCommand = new CommandViewModel(ExecuteShowOrdersViewCommand);

            //Default view
            //ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
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