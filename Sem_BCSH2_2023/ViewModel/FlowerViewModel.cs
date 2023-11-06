using CommunityToolkit.Mvvm.ComponentModel;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.ViewModel
{
   
    public class FlowerViewModel:BaseViewModel
    { 

    
    public static ObservableCollection<Flower> flowers = new ObservableCollection<Flower>();

        public FlowerViewModel()
        {
            
            //flowers.Add(new Flower(1, "Název květu", 1.1, "Popis květu"));
            //flowers.Add(new Flower(2, "Název asd", 1.1, "Popis květu"));
            //flowers.Add(new Flower(3, "dasd květu", 1.1, "Popis květu"));

            


        }

        

       


    }
}
