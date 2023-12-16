using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for OtherItemsView.xaml
    /// </summary>
    public partial class OtherItemsView : UserControl
    {
        public OtherItems? otherItem;
        private SortData sortData;

        private readonly OtherItemsViewModel OtherItemsVM;
        public OtherItemsView()
        {
            InitializeComponent();
            OtherItemsVM = new OtherItemsViewModel();
            DataContext = OtherItemsVM;

            lvOtherItems.ItemsSource = ((CollectionViewSource)Resources["FilteredGoods"]).View;
            sortData = new SortData();
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

      
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is OtherItems item)
            {
                otherItem = item;
                int selectedId = otherItem.Id;
                AddEditGoods windowEditGoods = new(selectedId, false);
                windowEditGoods.ShowDialog();
            }
        }

      

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (GridViewColumnHeader)e.OriginalSource;
            string header = (string)column.Content;

            switch (header)
            {
                case "ID":
                    sortData.SortDataMethod("Id", lvOtherItems);
                    break;
                case "Název":
                    sortData.SortDataMethod("Name", lvOtherItems);
                    break;
                case "Cena":
                    sortData.SortDataMethod("Price", lvOtherItems);
                    break;
            }
        }

        private void BtnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is OtherItems item)
            {
                GoodViewModel.RemoveOtherItem(item);
            }
        }
    }
}
