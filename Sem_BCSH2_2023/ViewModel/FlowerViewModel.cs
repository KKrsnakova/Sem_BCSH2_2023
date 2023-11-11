using CommunityToolkit.Mvvm.ComponentModel;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Sem_BCSH2_2023.ViewModel
{

    public class FlowerViewModel : BaseViewModel
    {

        public static ObservableCollection<Flower> FlowersList = new();

        //public FlowerViewModel()
        //{
        //    FlowersList.Add(new Flower(id: IdGenerator(),
        //                                name: "asdsdasd",
        //                                price: 20,
        //    description: "asdasd))", image: new BitmapImage(new Uri("pack://application:,,,/Resources/bg1.png"))));
        //}

        public static void AddFlower(string nameAdd, double priceAdd, string descAdd, string spec)
        {
        FlowersList.Add(new Flower(id: IdGenerator(),
                                    name: nameAdd,
                                    price: priceAdd,
                                    description: descAdd,
                                    flowerSpecies: spec  ));
    }

        public static void RemoveFlower(Flower selectedFlower)
        {
            FlowersList.Remove(selectedFlower);
        }

        private static int IdGenerator()
        {
            int pocet;
            if (FlowersList.Count == 0)
            {
                pocet = 1;
            }
            else
            {
                pocet = FlowersList.Last().Id;
                pocet++;
            }
            return pocet;
        }


    }
}
