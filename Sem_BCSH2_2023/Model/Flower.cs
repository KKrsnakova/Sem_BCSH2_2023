﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Model
{
    public class Flower : Goods
    {


        public string Description { get; set; }

        public string FlowerSpecies { get; set; }

        public Flower(int id, string name, double price, string description, string flowerSpecies) : base(id, name, price)
        {
            Description = description;
            FlowerSpecies = flowerSpecies;
        }

        //  public Species SpeciesFlower { get; set; }


        //public Flower(int id, string? name, double price, Species speciesFlower, string description) : base(id, name, price)
        //{
        //    SpeciesFlower = speciesFlower;
        //    Description = description;
        //}

    }
}