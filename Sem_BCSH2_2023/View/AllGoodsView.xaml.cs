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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for AllGoodsView.xaml
    /// </summary>
    public partial class AllGoodsView : Window
    {
        Order actualOrder;
        public AllGoodsView(Order order)
        {
            InitializeComponent();
            lvItemsForOrder.ItemsSource = GoodViewModel.GoodsList;
            actualOrder = order;

        }

        private void LvItemsForOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvItemsForOrder.SelectedItem != null)
            {
                Good selectedGood = (Good)lvItemsForOrder.SelectedItem;
                int selectedID = selectedGood.Id;

              
                    actualOrder.SellGoods(selectedGood);
                    GoodViewModel.GoodsList.Remove(selectedGood);


                Close();

            }
        }






        //Window operations
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NavBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void NavBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

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
    }
}
