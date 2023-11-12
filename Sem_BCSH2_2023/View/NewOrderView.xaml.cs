using Sem_BCSH2_2023.Model;
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
    /// Interaction logic for NewOrderView.xaml
    /// </summary>
    public partial class NewOrderView : Window
    {

        Customer? selectedCustomer;
        Order newOrder;
        int orderPrice = 0;
        public NewOrderView(Order? order)
        {

            InitializeComponent();
            cbCustomer.ItemsSource = CustomerViewModel.CustomersList;
            selectedCustomer = cbCustomer.SelectedItem as Customer;

            if (order == null && selectedCustomer != null)
            {
                newOrder = OrderViewModel.NewOrder(selectedCustomer.Id);
            } else if (order != null) 
            {
                newOrder = order;
            }
        }



        //Add or Delete Goods from order list
        private void BtnAddGood_Click(object sender, RoutedEventArgs e)
        {
            AllGoodsView windowAllGoods = new AllGoodsView(newOrder);
            windowAllGoods.Show();
        }

        private void BtnDeleteGood_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void CbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void LvOtherItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        //Window operations

        private void BtnMinimal_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnMaximal_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }


        private void NavBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void NavBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

       
    }
}
