using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.ViewModel
{
    public class OtherItemsViewModel : BaseViewModel
    {
        public static ObservableCollection<OtherItems> OtherItemsList = new();

        public static void AddOtherItems(string nameAdd, double priceAdd, int countAdd, string usageAdd)
        {
            OtherItemsList.Add(new OtherItems(IdGenerator(), nameAdd, priceAdd, usageAdd, countAdd));
        }

        public static void RemoveOtherItem(OtherItems selectedOtherItem)
        {
            OtherItemsList.Remove(selectedOtherItem);
        }


        private static int IdGenerator()
        {
            int pocet;
            if (OtherItemsList.Count == 0)
            {
                pocet = 1;
            }
            else
            {
                pocet = OtherItemsList.Last().Id;
                pocet++;
            }
            return pocet;
        }
    }
}
