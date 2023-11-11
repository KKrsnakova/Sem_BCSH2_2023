using CommunityToolkit.Mvvm.ComponentModel;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;
using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for FlowersView.xaml
    /// </summary>
    public partial class FlowersView : UserControl
    {
        public static Flower? flower;

        public FlowersView()
        {
            
            InitializeComponent();
            btnEdit.Visibility = Visibility.Hidden;
            lvFlowers.ItemsSource = FlowerViewModel.FlowersList;
        }

       
        private void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Thread threadOpen = new(() =>
            {
                AddGoods windowAddGoods = Dispatcher.Invoke(() => new AddGoods(null, true));
                Dispatcher.Invoke(() => windowAddGoods.Show());
            });
            threadOpen.Start();
            
        }

        private void BtnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //FlowerViewModel.FlowersList.Remove((Flower)lvFlowers.SelectedItem);
            FlowerViewModel.RemoveFlower((Flower)lvFlowers.SelectedItem);
        }

        private void LvFlowers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Visible;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvFlowers.SelectedItem != null)
            {
                flower = (Flower)lvFlowers.SelectedItem;
                int selectedId = flower.Id;
                AddGoods windowEditGoods = new(selectedId, true);
                windowEditGoods.ShowDialog();
                lvFlowers.ItemsSource = FlowerViewModel.FlowersList;
                lvFlowers.Items.Refresh();
            }
        }
    }
}
