using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sem_BCSH2_2023.Model
{
    public class Species
    {
        public enum SpecFlower
        {
            PokojoveRostliny,
            VenkovniRostliny,
            Bylinky,
            Orchideje,
            KaktusySukulenty,
            VodniRostliny,
            PopinaveRostliny,
            Ostatni
        }

        public List<SpecFlower> GetSpecFlowers()
        {
            return Enum.GetValues(typeof(SpecFlower)).Cast<SpecFlower>().ToList();
        }

        public static class SpecFlowerInfo
        {
            public static readonly int Count = Enum.GetValues(typeof(SpecFlower)).Length;

            public static IEnumerable Spec
            {
                get
                {
                    foreach (SpecFlower spec in Enum.GetValues(typeof(SpecFlower)))
                    {
                        yield return spec;
                    }
                }
            }

            public static string GetFlowerSpec(SpecFlower spec)
            {
                return spec switch
                {
                    SpecFlower.PokojoveRostliny => "Pokojové rostliny",
                    SpecFlower.VenkovniRostliny => "Venkovní rostliny",
                    SpecFlower.Bylinky => "Bylinky",
                    SpecFlower.Orchideje => "Orchideje",
                    SpecFlower.KaktusySukulenty => "Kaktusy a Sukulenty",
                    SpecFlower.VodniRostliny => "Vodní rostliny",
                    SpecFlower.Ostatni => "Ostatní",
                    _ => "",
                };
            }
        }
    }
}