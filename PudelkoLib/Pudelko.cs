using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable
    {

        private readonly double a = 0.1;
        private readonly double b = 0.1;
        private readonly double c = 0.1;

        public double A
        {
            get => Convert.ToDouble(a.ToString("0.000"));
        }
        public double B
        {
            get => Convert.ToDouble(b.ToString("0.000"));
        }
        public double C
        {
            get => Convert.ToDouble(c.ToString("0.000"));
        }
        public double Objetosc { get => Math.Round(A * B * C, 9); }
        public double Pole { get => Math.Round(2 * ((A * B) + (B * C) + (A * C)), 6); }

        public Pudelko(double? a = null, double? b = null, double? c=null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.a = a != null ? round((double)a / (ushort)unit) : 0.1; 
            this.b = b != null ? round((double)b / (ushort)unit) : 0.1;
            this.c = c != null ? round((double)c / (ushort)unit) : 0.1;

            if (A <= 0 || A > 10 || B <= 0 || B > 10 || C <= 0 || C > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private double round(double number)
        {
            return Math.Floor(number * 1000) / 1000;
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.GetCultureInfo("en-US"));
        }

        public override string ToString()
        {
            return this.ToString("m", CultureInfo.GetCultureInfo("en-US"));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                format = "m";
            switch (format)
            {
                case "m":
                    return $"{A.ToString("0.000", formatProvider)} {format} × {B.ToString("0.000", formatProvider)} {format} × {C.ToString("0.000", formatProvider)} {format}";
                case "cm":
                    return $"{(A*100).ToString("0.0", formatProvider)} {format} × {(B*100).ToString("0.0", formatProvider)} {format} × {(C*100).ToString("0.0", formatProvider)} {format}";
                case "mm":
                    return $"{(A*1000).ToString("0", formatProvider)} {format} × {(B*1000).ToString("0", formatProvider)} {format} × {(C*1000).ToString("0", formatProvider)} {format}";
                default:
                    throw new FormatException();
            }
        }
        public bool Equals(Pudelko pudelko)
        {
            bool isEquals = Objetosc == pudelko.Objetosc && Pole == pudelko.Pole;
            return isEquals;
        }
        public override bool Equals(object obj)
        {
            if (obj is Pudelko)
                return Equals((Pudelko)obj);
            return base.Equals(obj);
        }
        private UnitOfMeasure unit { get; set; }
        public override int GetHashCode()
        {
            return (A, B, C, unit).GetHashCode();
        }

        public static bool operator ==(Pudelko p1, Pudelko p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Pudelko p1, Pudelko p2)
        {
            return !p1.Equals(p2);
        }
        public static explicit operator double[](Pudelko p)
        {
            return new double[] { p.A, p.B, p.C };
        }
        public static implicit operator Pudelko(ValueTuple<double, double, double> p)
        {
            return new Pudelko(p.Item1, p.Item2, p.Item3, UnitOfMeasure.milimeter);
        }

        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            double[] p1Arr = new double[] { p1.A, p1.B, p1.C };
            double[] p2Arr = new double[] { p2.A, p2.B, p2.C };

            Array.Sort(p1Arr);
            Array.Sort(p2Arr);
            double newA;
            double newB;
            double newC;
            if (p2Arr[0] > p1Arr[1])
            {
                newA = p1Arr[0] + p2Arr[2];
                if (p1Arr[2] > p2Arr[1])
                    newB = p1Arr[2];
                else
                    newB = p2Arr[1];
                newC = p2Arr[0];
            }
            else if (p1Arr[0] > p2Arr[1])
            {
                newA = p1Arr[2] + p2Arr[0];
                newC = p1Arr[0];
                if (p2Arr[2] > p1Arr[1])
                    newB = p2Arr[2];
                else
                    newB = p1Arr[1];
            }
            else
            {
                newA = p1Arr[0] + p2Arr[0];
                if (p1Arr[1] > p2Arr[1])
                    newB = p1Arr[1];
                else
                    newB = p2Arr[1];
                if (p1Arr[2] > p2Arr[2])
                    newC = p1Arr[2];
                else
                    newC = p2Arr[2];

            }
            return new Pudelko(newA, newB, newC);
        }

        public double this[int indexer]
        {
            get
            {
                switch (indexer)
                {
                    case 0:
                        return A;
                    case 1:
                        return B;
                    case 2:
                        return C;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
        public IEnumerator<double> GetEnumerator()
        {
            return new PudelkoEnumerator(this);
        }
    }
    class PudelkoEnumerator : IEnumerator<double>
    {
        private readonly Pudelko p;

        public PudelkoEnumerator(Pudelko pudelko)
        {
            p = pudelko;
        }
        private int i = 0;
        public object Current => p[i++];

        double IEnumerator<double>.Current => p[i++];


        public bool MoveNext()
        {
            return i <= 1;
        }

        public void Reset()
        {
            i = 0;
        }
        public void Dispose()
        {
        }
    }

    public enum UnitOfMeasure : ushort
    {
        milimeter = 1000,
        centimeter = 100,
        meter = 1
    }
}