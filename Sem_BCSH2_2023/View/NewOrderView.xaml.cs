using Sem_BCSH2_2023.Model;
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

        private readonly NewOrderViewModel newOrderVM;

        public NewOrderView(Order ord, int? customerID)
        {

            order = ord;
            InitializeComponent();
            newOrderVM = new NewOrderViewModel(ord, customerID);
            DataContext = newOrderVM;



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
