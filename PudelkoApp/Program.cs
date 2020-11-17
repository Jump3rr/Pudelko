using System;
using PudelkoLib;
using System.Collections.Generic;

namespace PudelkoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pudelko> pudelka = new List<Pudelko>
            {
                new Pudelko(),
                new Pudelko(1),
                new Pudelko(1,2,3),
                new Pudelko(216,2,41.6, UnitOfMeasure.milimeter),
                new Pudelko(22, 89.5, 185, UnitOfMeasure.centimeter),
                new Pudelko(1.2, 23, null),
                //new Pudelko(null, null, null)

            };
        }
    }
}
