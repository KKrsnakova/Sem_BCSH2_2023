using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    public class FlowerViewModel : BaseViewModel
    {
        public ICommand AddFlower { get; }
        public ICommand DeleteAllFlower { get; }

        public FlowerViewModel()
        {
            AddFlower = new CommandViewModel(AddCom);
            DeleteAllFlower = new CommandViewModel(DeleteAllCom);
        }

        private void DeleteAllCom(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete odstranit všechny položky?", "Potvrzení odstranění", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                GoodViewModel.RemoveAllFlower();
            }
        }

        private void AddCom(object obj)
        {
                AddGoods windowAddGoods = new AddGoods(null, true);
                windowAddGoods.Show();
        }
    }


}
