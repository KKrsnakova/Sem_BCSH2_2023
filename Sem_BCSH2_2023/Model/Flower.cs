using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Model
{
    public class Flower : Good
    {
        private string _description;
        private string _flowerSpecies;

        public string Description { get => _description; set => SetProperty(ref _description, value, nameof(Description)); }

        public string FlowerSpecies { get => _flowerSpecies; set=> SetProperty(ref _flowerSpecies, value, nameof(FlowerSpecies)); }

        public Flower(int id, string name, double price, string description, string flowerSpecies) : base(id, name, price)
        {
            Description = description;
            FlowerSpecies = flowerSpecies;
        }

        public override string? ToString()
        {
            return Id + " " + Name + "Is Flower";
        }



    }
}
