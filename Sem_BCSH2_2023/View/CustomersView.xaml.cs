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
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public static Customer? customer;

        public CustomersView()
        {
            InitializeComponent();
            //btnEdit.IsEnabled = false;
            lvCustomers.ItemsSource = CustomerViewModel.CustomersList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Thread threadOpen = new Thread(() =>
            {
                AddEditCustomer windowAddCustomer = Dispatcher.Invoke(() => new AddEditCustomer(null));
                Dispatcher.Invoke(() => windowAddCustomer.Show());
            });
            threadOpen.Start();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is Customer item)
            {
                CustomerViewModel.RemoveCustomer(item);
            }
            
        }

        private void LvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btnEdit.IsEnabled = true;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is Customer item)
            {
                customer = item;
                int selectedId = customer.Id;
                AddEditCustomer windowEditCustomer = new(selectedId);
                windowEditCustomer.ShowDialog();
                lvCustomers.ItemsSource = CustomerViewModel.CustomersList;
            }
        }


    }
}
