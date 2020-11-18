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
                new Pudelko(1,2),
                new Pudelko(1,2,3),
                new Pudelko(9.9, null, 5),
                new Pudelko(UnitOfMeasure.centimeter),
                new Pudelko(1, UnitOfMeasure.centimeter),
                new Pudelko(2, UnitOfMeasure.centimeter),
                new Pudelko(2156,2,41.6, UnitOfMeasure.milimeter),
                new Pudelko(22, 89.5, 185, UnitOfMeasure.centimeter),
                new Pudelko(1.2, 2.3, 0.1),
                new Pudelko(4, 1, 2).Kompresuj(),
                new Pudelko(2,2,2),
                new Pudelko(4,2,1),

            };

            pudelka.ForEach(
            (pudelko) => {
            Console.WriteLine(pudelko.ToString());
            });

            Console.WriteLine("Lista posortowana:");

            pudelka.Sort(Sortuj);
            pudelka.ForEach(
            (pudelko) => {
               Console.WriteLine(pudelko.ToString());
            });
        }
        public static int Sortuj(Pudelko p1, Pudelko p2)
        {
            if (p1.Objetosc == p2.Objetosc)
            {
                if (p1.Pole == p2.Pole)
                {
                    if ((p1.A + p1.B + p1.C) > (p2.A + p2.B + p2.C))
                        return 1;
                    else
                        return -1;
                }
                else if (p1.Pole > p2.Pole)
                    return 1;
                else
                    return -1;
            }
            else if (p1.Objetosc > p2.Objetosc)
                return 1;
            else
                return -1;
        }
    }
}
