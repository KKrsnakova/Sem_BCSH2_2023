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
        private SortData sortData;

        public CustomersView()
        {
            InitializeComponent();
            lvCustomers.ItemsSource = CustomerViewModel.CustomersList;
            sortData = new SortData();
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is Customer item)
            {
                CustomerViewModel.RemoveCustomer(item);
            }
        }


        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is Customer item)
            {
                customer = item;
                int selectedId = customer.Id;

                await Task.Run(() =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        AddEditCustomer windowEditCustomer = new(selectedId);
                        windowEditCustomer.ShowDialog();
                        lvCustomers.ItemsSource = CustomerViewModel.CustomersList;
                    });
                });
            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (GridViewColumnHeader)e.OriginalSource;
            string header = (string)column.Content;

            if (header == "ID")
            {
                sortData.SortDataMethod("Id", lvCustomers);
            }
            else if (header == "Jméno")
            {
                sortData.SortDataMethod("Name", lvCustomers);
            }
            else if (header == "Příjmení")
            {
                sortData.SortDataMethod("Surname", lvCustomers);
            }
        }
       
    }
}
