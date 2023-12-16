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
        private readonly FlowerViewModel flowerVM;

        public  Flower? flower;
        SortData sortData;
        public FlowersView()
        {
            InitializeComponent();
            flowerVM = new FlowerViewModel();
            DataContext = flowerVM;
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


        private void BtnDeleteRow_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            if (button.DataContext is Flower item)
            {
                GoodViewModel.RemoveFlower(item);
            }

        }




        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            if (button.DataContext is Flower item)
            {
                flower = item;
                int selectedId = flower.Id;
                AddEditGoods windowEditGoods = new(selectedId, true);
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

     
    }
}
