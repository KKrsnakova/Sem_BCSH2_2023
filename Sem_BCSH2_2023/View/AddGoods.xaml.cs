using Sem_BCSH2_2023.Model;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sem_BCSH2_2023.ViewModel
{
    /// <summary>
    /// Interaction logic for AddGoods.xaml
    /// </summary>
    public partial class AddGoods : Window
    {
        public AddGoods()
        {
            InitializeComponent();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FlowerViewModel.flowers.Add(new Flower(
             id: FlowerViewModel.flowers.Count + 1,
             name: tbName.Text,
             price: 1,
             description: tbDesc.Text ));
            this.Close();
        }
    }
}
