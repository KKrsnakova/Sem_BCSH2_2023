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
        public OtherItems? otherItem;

        public ICommand AddOtherItem { get; }
        public ICommand DeleteAllOtherItem { get; }

        public ICommand DeleteOtherItemCom { get; }
        public ICommand EditOtherItemCom { get; }

        public OtherItemsViewModel()
        {
            AddOtherItem = new CommandViewModel(AddOtherItemCom);
            DeleteAllOtherItem = new CommandViewModel(DeleteAllOtherItemCom);

            DeleteOtherItemCom = new CommandViewModel(DeleteOtherItem);
            EditOtherItemCom = new CommandViewModel(EditOtherItem);

        }

        private void EditOtherItem(object obj)
        {

            if (obj is OtherItems item)
            {
                otherItem = item;
                int selectedId = otherItem.Id;
                AddEditGoods windowEditGoods = new(selectedId, false);
                windowEditGoods.ShowDialog();
            }
        }

        private void DeleteOtherItem(object obj)
        {
            if (obj is OtherItems item)
            {
                GoodViewModel.RemoveOtherItem(item);
            }
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

            AddEditGoods windowAddGoods = new AddEditGoods(null, false);
            windowAddGoods.Show();

        }
    }


}
