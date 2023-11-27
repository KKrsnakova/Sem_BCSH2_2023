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
        private Order order;
        private bool edit;
        // public NewOrderView(Order ord, Customer customer)
        public NewOrderView(Order ord, int? customerID)
        {

            InitializeComponent();
            cbCustomer.ItemsSource = CustomerViewModel.CustomersList;
            cbCustomer.SelectedIndex = 0;


            if (customerID != null && ord != null)
            {
                edit = true;
                order = ord;
                MessageBox.Show("Customer id" + customerID, "Uloženo do DB", MessageBoxButton.OK);
                selectedCustomer = CustomerViewModel.CustomersList.First(x => x.Id == customerID);
                cbCustomer.SelectedValue = selectedCustomer;
                lvOrder.ItemsSource = ord.ListOfGoods;
            }
            else
            {
                edit = false;
                selectedCustomer = (Customer)cbCustomer.SelectedItem;
                order = OrderViewModel.NewOrder(selectedCustomer.Id);
            }

            //if(ord.ListOfGoods.Count!= null) { 
            //lvOrder.ItemsSource = ord.ListOfGoods;
            //    }
            //new order



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
            //lvOrder.Items.Refresh();
            MessageBox.Show(order.ListOfGoods.Count() + " = count", "Uloženo do DB", MessageBoxButton.OK);
            lvOrder.ItemsSource = order.ListOfGoods;


        }

        private void BtnDeleteGood_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is Flower flw)
            {
                order.ListOfGoods.Remove(flw);
                GoodViewModel.AddFlower(flw);
            }
            else if (button.DataContext is OtherItems otitem)
            {
                order.ListOfGoods.Remove(otitem);
                GoodViewModel.AddOtherItems(otitem);
            }
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
            if (edit)
            {
                order.OrderPrice = (float)OrderViewModel.OrderPrice(order);
                this.Close();

            } else
            {
                order.OrderPrice = (float)OrderViewModel.OrderPrice(order);
                // order.CustomerId = selectedCustomer.Id;
                OrderViewModel.AddOrder(order);

            }


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
