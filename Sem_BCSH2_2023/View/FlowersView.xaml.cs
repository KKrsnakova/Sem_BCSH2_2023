using CommunityToolkit.Mvvm.ComponentModel;
using Sem_BCSH2_2023.ViewModel;
using System.Threading;
using System.Windows.Controls;

namespace Sem_BCSH2_2023.View
{
    public partial class FlowersView : UserControl
    {
        
        public FlowersView()
        {
            InitializeComponent();
            lvFlowers.ItemsSource = FlowerViewModel.flowers;
        }

       
        private void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Thread threadOpen = new Thread(() =>
            {
                AddGoods windowAddGoods = Dispatcher.Invoke(() => new AddGoods());
                Dispatcher.Invoke(() => windowAddGoods.Show());
            });
            threadOpen.Start();
            
        }

        private void BtnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
