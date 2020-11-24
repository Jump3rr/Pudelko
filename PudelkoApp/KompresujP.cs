using System;
using PudelkoLib;

namespace PudelkoApp
{
    public static class KompresujP
    {
        public static Pudelko Kompresuj(this Pudelko p)
        {
            double a = Math.Cbrt(p.Objetosc);
            return new Pudelko(a, a, a);
        }
        
    }
}
