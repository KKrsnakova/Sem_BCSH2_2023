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
        public ICommand AddFlowerCom { get; }
        public ICommand DeleteAllFlowerCom { get; }
        public ICommand DeleteFlowerCom { get; }
        public ICommand EditFlowerCom{ get; }

        public ICommand OrderDoneCom { get; }

        public FlowerViewModel()
        {
            AddFlowerCom = new CommandViewModel(AddFlower);
            DeleteAllFlowerCom = new CommandViewModel(DeleteAllFlower);
            DeleteFlowerCom = new CommandViewModel(DeleteFlower);
            EditFlowerCom = new CommandViewModel(EditFlower);

        }

        private void EditFlower(object obj)
        {

            if (obj is Flower flower)
            {
                int selectedId = flower.Id;
                AddEditGoods windowEditGoods = new(selectedId, true);
                windowEditGoods.ShowDialog();
            }
        }

        private void DeleteAllFlower(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete odstranit všechny položky?", "Potvrzení odstranění", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                GoodViewModel.RemoveAllFlower();
            }
        }

        private void AddFlower(object obj)
        {
                AddEditGoods windowAddGoods = new (null, true);
                windowAddGoods.Show();
        }

        private void DeleteFlower(object obj)
        {
            
            if (obj is Flower flower)
            {
                GoodViewModel.RemoveFlower(flower);
            }
        }
    }


}
