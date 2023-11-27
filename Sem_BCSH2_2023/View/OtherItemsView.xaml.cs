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
    /// Interaction logic for OtherItemsView.xaml
    /// </summary>
    public partial class OtherItemsView : UserControl
    {
        public  OtherItems? otherItem;
        public OtherItemsView()
        {
            InitializeComponent();
            btnEdit.Visibility = Visibility.Hidden;
            lvOtherItems.ItemsSource = ((CollectionViewSource)Resources["FilteredGoods"]).View;
        }

        private void GoodsFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is OtherItems)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Thread threadOpen = new(() =>
            {
                AddGoods windowAddGoods = Dispatcher.Invoke(() => new AddGoods(null, false));
                Dispatcher.Invoke(() => windowAddGoods.Show());
            });
            threadOpen.Start();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is OtherItems item)
            {
                otherItem = item;
                int selectedId = otherItem.Id;
                AddGoods windowEditGoods = new(selectedId, false);
                windowEditGoods.ShowDialog();
               //((CollectionViewSource)Resources["FilteredGoods"]).View.Refresh();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is OtherItems item)
            {
                GoodViewModel.RemoveOtherItem((item));
            }
        }

        private void LvOtherItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Visible;
        }

      
    }
}
