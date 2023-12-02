using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Sem_BCSH2_2023.Model
{
    public class SortData
    {
        public SortData() { }

        public void SortDataMethod(string propertyName, ListView lv)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(lv.ItemsSource);
            ListSortDirection direction = ListSortDirection.Ascending;

            // Pokud sloupec je již aktuálně seřazený, změňte směr řazení
            if (view.SortDescriptions.Count > 0 && view.SortDescriptions[0].PropertyName == propertyName)
            {
                direction = (view.SortDescriptions[0].Direction == ListSortDirection.Ascending) ?
                    ListSortDirection.Descending : ListSortDirection.Ascending;
            }

            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(propertyName, direction));
            view.Refresh();
        }
    }
}
