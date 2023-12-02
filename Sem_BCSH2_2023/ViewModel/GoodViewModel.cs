using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Sem_BCSH2_2023.ViewModel
{
    public class GoodViewModel: BaseViewModel
    {
        public static ObservableCollection<Good> GoodsList = new();

        public GoodViewModel()
        {
            
        }




        //Flowers
        public static void AddFlower(string nameAdd, double priceAdd, string descAdd, string spec)
        {
            GoodsList.Add(new Flower(id: IdGenerator(),
                                        name: nameAdd,
                                        price: priceAdd,
                                        description: descAdd,
                                        flowerSpecies: spec));
        }

        public static void AddFlower(Flower flower)
        {
            GoodsList.Add((Flower)flower);
        }

        public static void RemoveFlower(Flower selectedFlower)
        {
            GoodsList.Remove(selectedFlower);
        }
        public static void RemoveAllFlower()
        {
            var flowersToRemove = GoodsList.OfType<Flower>().ToList();

            foreach (var flower in flowersToRemove)
            {
                GoodsList.Remove(flower);
            }
        }



        //Other goods


        public static void AddOtherItems(string nameAdd, double priceAdd, int countAdd, string usageAdd)
        {
            GoodsList.Add(new OtherItems(IdGenerator(), nameAdd, priceAdd, usageAdd, countAdd));
        }

        public static void AddOtherItems(OtherItems otherItems)
        {
            GoodsList.Add(otherItems);
        }

        public static void RemoveOtherItem(OtherItems selectedOtherItem)
        {
            GoodsList.Remove(selectedOtherItem);
        } 
        
        public static void RemoveAllOtherItem()
        {

            var otherItemsToRemove = GoodsList.OfType<OtherItems>().ToList();

            foreach (var otherItem in otherItemsToRemove)
            {
                GoodsList.Remove(otherItem);
            }
        }

        






        private static int IdGenerator()
        {
            int pocet;
            if (GoodsList.Count == 0)
            {
                pocet = 1;
            }
            else
            {
                pocet = GoodsList.Last().Id;
                pocet++;
            }
            return pocet;
        }

    }


}
