using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Repository;
using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public FlowersMng FlowersMng { get; set; }
        public CustomerMng CustomerMng { get; set; }
        public OtherItemsMng OtherItemsMng { get; set; }

        public MainView()
        {
            Repo repo = new();
            InitializeComponent();
            FlowersMng = new FlowersMng(repo);
            CustomerMng = new CustomerMng(repo);
            OtherItemsMng = new OtherItemsMng(repo);

            FlowerViewModel.FlowersList = FlowersMng.GetAllFlowers();
            CustomerViewModel.CustomersList = CustomerMng.GetAllCustomers();
            OtherItemsViewModel.OtherItemsList = OtherItemsMng.GetAllOtherItems();



        }

        private void NavBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void NavBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void BtnMinimal_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximal_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }



        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            FlowersMng.RemoveAllFlowers();
            FlowersMng.AddAllFlowers(FlowerViewModel.FlowersList);

            CustomerMng.RemoveAllCustomers();
            CustomerMng.AddAllCustomers(CustomerViewModel.CustomersList);

            OtherItemsMng.RemoveAllOtherItems();
            OtherItemsMng.AddAllOtherIrems(OtherItemsViewModel.OtherItemsList);

            MessageBox.Show("Data uložena do databáze", "Uloženo do DB", MessageBoxButton.OK);

        }

    }
}
