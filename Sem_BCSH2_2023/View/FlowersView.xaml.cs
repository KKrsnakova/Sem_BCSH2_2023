using CommunityToolkit.Mvvm.ComponentModel;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Sem_BCSH2_2023.View
{
    public partial class FlowersView : UserControl
    {
        public static Flower? flower;
        SortData sortData;
        public FlowersView()
        {
            InitializeComponent();

            lvFlowers.ItemsSource = ((CollectionViewSource)Resources["FilteredFlowers"]).View;
            sortData = new SortData();
        }

        private void FlowerFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is Flower)
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
                AddGoods windowAddGoods = Dispatcher.Invoke(() => new AddGoods(null, true));
                Dispatcher.Invoke(() => windowAddGoods.Show());
            });
            threadOpen.Start();
        }

        private void BtnDeleteRow_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            if (button.DataContext is Flower item)
            {
                GoodViewModel.RemoveFlower(item);
            }

        }

        private void LvFlowers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btnEdit.Visibility = Visibility.Visible;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            if (button.DataContext is Flower item)
            {
                flower = item;
                int selectedId = flower.Id;
                AddGoods windowEditGoods = new(selectedId, true);
                windowEditGoods.ShowDialog();

            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (GridViewColumnHeader)e.OriginalSource;
            string header = (string)column.Content;

            if (header == "ID")
            {
                sortData.SortDataMethod("Id", lvFlowers);
            }
            else if (header == "Název")
            {
                sortData.SortDataMethod("Name", lvFlowers);
            }
            else if (header == "Cena")
            {
                sortData.SortDataMethod("Price", lvFlowers);
            }
        }

        private void BtnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete odstranit všechny položky?", "Potvrzení odstranění", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                GoodViewModel.RemoveAllFlower();
            }
        }
    }
}
