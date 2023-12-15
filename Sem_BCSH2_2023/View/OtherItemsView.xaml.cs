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
        public static OtherItems? otherItem;
        public OtherItemsView()
        {
            InitializeComponent();
            btnEdit.Visibility = Visibility.Hidden;
            lvOtherItems.ItemsSource = OtherItemsViewModel.OtherItemsList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Thread threadOpen = new Thread(() =>
            {
                AddGoods windowAddGoods = Dispatcher.Invoke(() => new AddGoods(null, false));
                Dispatcher.Invoke(() => windowAddGoods.Show());
            });
            threadOpen.Start();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvOtherItems.SelectedItem != null)
            {
                otherItem = (OtherItems)lvOtherItems.SelectedItem;
                int selectedId = otherItem.Id;
                AddGoods windowEditGoods = new AddGoods(selectedId, false);
                windowEditGoods.ShowDialog();
                lvOtherItems.ItemsSource = OtherItemsViewModel.OtherItemsList;
                lvOtherItems.Items.Refresh();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            OtherItemsViewModel.RemoveOtherItem((OtherItems)lvOtherItems.SelectedItem);
        }

        private void LvOtherItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Visible;

        }
    }
}
