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


        public OrdersView()
        {
            InitializeComponent();
          //  lvOrders.ItemsSource = OrderViewModel.OrderList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Thread threadOpen = new(() =>
            {
                NewOrderView windowNewOrder = Dispatcher.Invoke(() => new NewOrderView(null));
                Dispatcher.Invoke(() => windowNewOrder.Show());
            });
            threadOpen.Start();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            OrderViewModel.RemoveOrder((Order)lvOrders.SelectedItem);
        }

        private void LvOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
