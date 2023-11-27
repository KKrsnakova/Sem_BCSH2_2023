using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        public static Order? order;

        public OrdersView()
        {
            InitializeComponent();

            lvOrders.ItemsSource = OrderViewModel.OrderList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Thread threadOpen = new(() =>
            {
                NewOrderView windowNewOrder = Dispatcher.Invoke(() => new NewOrderView(null, null));
                Dispatcher.Invoke(() => windowNewOrder.Show());
            });
            threadOpen.Start();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is Order item)
            {
                OrderViewModel.RemoveOrder(item);
            }

        }

        private void LvOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is Order item)
            {
                order = (Order)item;
                NewOrderView windowEditGoods = new(order, order.CustomerId);
                windowEditGoods.ShowDialog();
               
            }
            lvOrders.ItemsSource = OrderViewModel.OrderList;
        }

        private void CbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (button.DataContext is Order item)
            {
                order = (Order)item;
                order.Done = !order.Done;
                order.DateCompletion = DateTime.Now;

                // Získání ListViewItem z položky Order
                ListViewItem? lvi = lvOrders.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;

                if (lvi != null)
                {
                    lvi.IsEnabled = false;
                    lvi.IsHitTestVisible = false;
                }
            }
        }

    }
}
