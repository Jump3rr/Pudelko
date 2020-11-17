using System;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable
    {

    }

    public enum UnitOfMeasure : ushort
    {
        milimeter = 1000,
        centimeter = 100,
        meter = 1
    }
}