using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Sem_BCSH2_2023.ViewModel
{
    public class OtherItemsViewModel : BaseViewModel
    {
        public ICommand AddOtherItem { get; }
        public ICommand DeleteAllOtherItem { get; }

        public OtherItemsViewModel()
        {
            AddOtherItem = new CommandViewModel(AddOtherItemCom);
            DeleteAllOtherItem = new CommandViewModel(DeleteAllOtherItemCom);

        }

        private void DeleteAllOtherItemCom(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete odstranit všechny položky?", "Potvrzení odstranění", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                GoodViewModel.RemoveAllOtherItem();
            }
        }

        private void AddOtherItemCom(object obj)
        {

            AddGoods windowAddGoods = new AddGoods(null, false);
            windowAddGoods.Show();

        }
    }


}
