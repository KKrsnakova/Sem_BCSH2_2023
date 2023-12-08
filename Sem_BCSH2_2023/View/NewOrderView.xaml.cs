﻿using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public NewOrderView(Order ord, int? customerID)
        {
            selectedCustomer = CustomerViewModel.CustomersList.First();
            InitializeComponent();

            cbCustomer.ItemsSource = CustomerViewModel.CustomersList;
            cbCustomer.SelectedIndex = 0;

            if (customerID != null && ord != null)
            {
                btnAdd.Content = "Editovat";
                tbWindowName.Text = "Editace položek objednávky";
                tbCustomer.Visibility = Visibility.Visible;
               
                cbCustomer.Visibility = Visibility.Collapsed;
                edit = true;
                order = ord;
                selectedCustomer = CustomerViewModel.CustomersList.First(x => x.Id == customerID);
                tbCustomer.Text = selectedCustomer.ToString();
                cbCustomer.SelectedItem = selectedCustomer;
                lvOrder.ItemsSource = ord.ListOfGoods;
                cbCustomer.IsEditable = false;
            }
            else
            {
                tbCustomer.Visibility = Visibility.Collapsed;
                cbCustomer.Visibility = Visibility.Visible;
                cbCustomer.SelectedIndex = 0;
                edit = false;
                order = OrderViewModel.NewOrder();
            }

        }

        private void CbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCustomer = (Customer)cbCustomer.SelectedItem;

        }


        //Add or Delete Goods from order list
        private void BtnAddGood_Click(object sender, RoutedEventArgs e)
        {
            AllGoodsView windowAllGoods = new(order);
            windowAllGoods.ShowDialog();
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





        //Confirm / Close Order
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {  
            if (edit)
            {//Edit
                
                order.OrderPrice = (float)OrderViewModel.OrderPrice(order);
                //order.CustomerId = selectedCustomer.Id;
                this.Close();

            } else
            { //Add
                order.OrderPrice = (float)OrderViewModel.OrderPrice(order);
               
                    order.CustomerId = selectedCustomer.Id;
                    Customer customer = CustomerViewModel.GetCustomerById(selectedCustomer.Id);
                    order.FullName = OrderViewModel.GetCustomerNameById(customer.Id);

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
