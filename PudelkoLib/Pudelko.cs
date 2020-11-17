using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace PudelkoLib
{
    public sealed class Pudelko //: IFormattable, IEquatable<Pudelko>, IEnumerable
    {

        private readonly double a = 0.1;
        private readonly double b = 0.1;
        private readonly double c = 0.1;

        public double A
        {
            get => Math.Round(a, 3);
        }
        public double B
        {
            get => Math.Round(b, 3);
        }
        public double C
        {
            get => Math.Round(c, 3);
        }
        public double Objetosc { get => Math.Round(A * B * C); }
        public double Pole { get => Math.Round(2 * ((A * B) + (B * C) + (A * C))); }

        public Pudelko(double? a=null, double? b=null, double? c=null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.a = (a != null ? (round((double)a / (ushort)unit)) : 0.1);
            this.b = (b != null ? (round((double)b / (ushort)unit)) : 0.1);
            this.c = (c != null ? (round((double)c / (ushort)unit)) : 0.1);

            if (A <= 0 || A > 10 || B <= 0 || B > 10 || C <= 0 || C > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private double round(double number)
        {
            return Math.Floor(number * 1000) / 1000;
        }




        //private UnitOfMeasure unit { get; set; }
    }



    public enum UnitOfMeasure : ushort
    {
        milimeter = 1000,
        centimeter = 100,
        meter = 1
    }
}