using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        Customer selectedCustomer;
        readonly Order order;
        int orderPrice = 0;
        public NewOrderView(Order ord)
        {
            
            InitializeComponent();
            cbCustomer.ItemsSource = CustomerViewModel.CustomersList;
            cbCustomer.SelectedIndex = 0;
            selectedCustomer = (Customer)cbCustomer.SelectedItem;
            //if(ord.ListOfGoods.Count!= null) { 
            //lvOrder.ItemsSource = ord.ListOfGoods;
            //    }
            //new order
            order = OrderViewModel.NewOrder(selectedCustomer.Id);


            //if (order == null && selectedCustomer != null)
            //{
            //    OrderNew = OrderViewModel.NewOrder(selectedCustomer.Id);
            //} else if (order != null) 
            //{
            //    OrderNew = order;
            //}
        }



        //Add or Delete Goods from order list
        private void BtnAddGood_Click(object sender, RoutedEventArgs e)
        {
            AllGoodsView windowAllGoods = new(order);
            windowAllGoods.ShowDialog();
            lvOrder.Items.Refresh();
            MessageBox.Show(order.ListOfGoods.Count()+" = count", "Uloženo do DB", MessageBoxButton.OK);
            lvOrder.ItemsSource = order.ListOfGoods;


        }

        private void BtnDeleteGood_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void LvOtherItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCustomer = (Customer)cbCustomer.SelectedItem;
        }



        //Confirm / Close Order
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            order.OrderPrice = (float)OrderViewModel.OrderPrice(order);
            order.CustomerId = selectedCustomer.Id;
            OrderViewModel.AddOrder(order);
            this.Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

       


        private void NavBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void NavBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void lvOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
