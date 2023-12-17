using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Customer selectedCustomer;
        


        private readonly OrderViewModel OrderVM;

        public OrdersView()
        {
            InitializeComponent();
            OrderVM = new OrderViewModel();
            DataContext = OrderVM;


        }
        private void CbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCustomer = (Customer)cbCustomer.SelectedItem;
            LvRefresh();
        }
        private void LvRefresh()
        {
            lvOrders.ItemsSource = OrderViewModel.OrderList.Where(order => order.CustomerId == selectedCustomer.Id);
        }



    }
}
