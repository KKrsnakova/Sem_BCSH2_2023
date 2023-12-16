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
        public AllGoodsView(Order ord)
        {
            actualOrder = ord;
            InitializeComponent();
            lvItemsForOrder.ItemsSource = GoodViewModel.GoodsList;
           
           

        }

        private void LvItemsForOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvItemsForOrder.SelectedItems.Count > 0) 
            {
                Good selectedGood = (Good)lvItemsForOrder.SelectedItem;
                int selectedID = selectedGood.Id;
                MessageBox.Show("int selectedID = selectedGood.Id;" + selectedID , "Uloženo do DB", MessageBoxButton.OK);

                Good? good = GoodViewModel.GoodsList.FirstOrDefault(objekt => objekt.Id == selectedID);

                MessageBox.Show(good.ToString() , "Uloženo do DB", MessageBoxButton.OK);




                GoodViewModel.GoodsList.Remove(selectedGood);
                actualOrder.SellGoods(good);


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
