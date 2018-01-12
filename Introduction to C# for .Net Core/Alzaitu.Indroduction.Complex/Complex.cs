using System;

namespace Alzaitu.Indroduction.Complex
{
    /// <summary>
    /// Represets a complex number.
    /// </summary>
    /// <inheritdoc cref="IComparable{Complex}"/>
    public struct Complex : IComparable<Complex>
    {
        /// <summary>
        /// The real component of the complex number.
        /// </summary>
        public double Real { get; }

        /// <summary>
        /// The imaginary component of the complex number.
        /// </summary>
        public double Imaginary { get; }

        /// <summary>
        /// The magnitude of the vector drawn by this complex number.
        /// </summary>
        public double Magnitude => Math.Sqrt(Real * Real + Imaginary * Imaginary);

        /// <summary>
        /// Create a new complex number with only a real component.
        /// </summary>
        /// <param name="real">The magnitude of the real part of the complex number.</param>
        public Complex(double real) : this(real, 0)
        {
            
        }
        
        /// <summary>
        /// Create a new complex number with both a real and imaginary component.
        /// </summary>
        /// <param name="real">The magnitude of the real part of the complex number.</param>
        /// <param name="imaginary">The magnitude of the imaginary part of the complex number.</param>
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public override string ToString() => Real > 0 && Imaginary > 0 ? $"{Real} + {Imaginary}i" : Real > 0 ? $"{Real}" : $"{Imaginary}i";

        public override int GetHashCode() => (int)(Real * 1000) ^ (int)(Imaginary * 10);

        public int CompareTo(Complex other) => Magnitude.CompareTo(other.Magnitude);

        public static implicit operator Complex(double real) => new Complex(real);

        public static explicit operator double(Complex complex) => complex.Real;

        public static Complex operator +(Complex one, Complex two) => new Complex(one.Real + two.Real, one.Imaginary + two.Imaginary);

        public static Complex operator -(Complex one, Complex two) => new Complex(one.Real - two.Real, one.Imaginary - two.Imaginary);

        public static Complex operator *(Complex one, Complex two) => new Complex(one.Real * two.Real - one.Imaginary * two.Imaginary, one.Real * two.Imaginary + one.Imaginary * two.Real);
    }
}
