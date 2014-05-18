using System;

namespace Complex
{
	/// <summary>
	/// The complex class provides basic operations at complex numbers.
	/// </summary>
	public class Complex
	{
		private const double eps=1e-14;
		/// <summary>
		/// The real part of the complex number.
		/// </summary>
		private double re;

		/// <summary>
		/// The imaginary part of the complex number.
		/// </summary>
		private double im;

		public static Complex i
		{
			get
			{
				return new Complex(0,1);
			}
		}
        		
		/// <summary>
		/// Thte ontructor for the complex number by real and imaginary part.
		/// </summary>
		/// <param name="realPart">The real part of the complex number.</param>
		/// <param name="imaginaryPart">The imaginary part of the complex number</param>
		public Complex(double realPart,double imaginaryPart)
		{
			im = imaginaryPart;
			re = realPart;
		}

		/// <summary>
		/// Contructor for complex number by real part (imaginary part equal 0).
		/// </summary>
		/// <param name="realPart">Real part of complex number.</param>
		public Complex(double realPart)
		{
			im = 0;
			re = realPart;
		}

		/// <summary>
		/// Default contructor for zero complex number.
		/// </summary>
		public Complex()
		{
			im = 0;
			re = 0;
		}

		/// <summary>
		/// Creates new complex number by current.
		/// </summary>
		/// <param name="complex">Source complex number.</param>
		public Complex(Complex complex)
		{
			im = Im(complex);
			re = Re(complex);
		}

		/// <summary>
		/// Provides access to imaginary part of complex number. 
		/// </summary>
		/// <param name="complex">Complex number.</param>
		/// <returns>Imaginary part of complex number.</returns>
		public static double Im(Complex complex)
		{
			return complex.im;
		}

		/// <summary>
		/// Provides access to real part of complex number.
		/// </summary>
		/// <param name="complex">Complex number.</param>
		/// <returns>Real part of complex number.</returns>
		public static double Re(Complex complex)
		{
			return complex.re;
		}

		/// <summary>
		/// Conversion operator.
		/// </summary>
		/// <param name="a">Complex number</param>
		/// <returns>Real part of complex number.</returns>
		public static explicit operator double(Complex a)
		{
			return a.re;
		}

		/// <summary>
		/// Conversion operator.
		/// </summary>
		/// <param name="r">Real number r.</param>
		/// <returns>Complex number r+0i.</returns>
		public static implicit operator Complex(double r)
		{
			return new Complex(r);
		}

		/// <summary>
		/// Unary complex operator +.
		/// </summary>
		/// <param name="a">Sourse complex number.</param>
		/// <returns>Complex number.</returns>
		public static Complex operator + (Complex a)
		{
			return a;
		}

		/// <summary>
		/// Unary complex operator -.
		/// </summary>
		/// <param name="a">Sourse complex number.</param>
		/// <returns>Source complex number with minus.</returns>
		public static Complex operator - (Complex a)
		{
			return new Complex(-a.re,-a.im);
		}


		/// <summary>
		/// Sum complex operator.
		/// </summary>
		/// <param name="a">First operand.</param>
		/// <param name="b">Second operand.</param>
		/// <returns>Sum (a+b).</returns>
		public static Complex operator + (Complex a, Complex b)
		{
			return new Complex(a.re+b.re,a.im+b.im);
		}

		/// <summary>
		/// Subtraction complex operator.
		/// </summary>
		/// <param name="a">First operand.</param>
		/// <param name="b">Second operand.</param>
		/// <returns>Subtraction (a-b).</returns>
		public static Complex operator - (Complex a, Complex b)
		{
			return new Complex(a.re-b.re,a.im-b.im);
		}

		/// <summary>
		/// Multiply complex operator.
		/// </summary>
		/// <param name="a">First operand.</param>
		/// <param name="b">Second operand.</param>
		/// <returns>Multiply (a*b).</returns>
		public static Complex operator * (Complex a, Complex b)
		{
			return new Complex(a.re*b.re - a.im*b.im, a.re*b.im + a.im*b.re);
		}

		/// <summary>
		/// Division complex operator.
		/// </summary>
		/// <param name="a">First operand.</param>
		/// <param name="b">Second operand.</param>
		/// <returns>Division (a/b)</returns>
		public static Complex operator / (Complex a, Complex b)
		{
			if ((b.re==0)&&(b.im==0))
				throw new DivideByZeroException();
			else
				return new Complex((a.re*b.re - a.im*b.im)/(b.re*b.re+b.im*b.im),
					(b.re*a.im - b.im*a.re)/(b.re*b.re+b.im*b.im));
		}
		
		/// <summary>
		/// Module of complex number.
		/// </summary>
		/// <param name="a">The complex number</param>
		/// <returns>Module of complex number.</returns>
		public static double Mod(Complex a)
		{
			return Math.Sqrt(a.re*a.re+a.im*a.im);
		}


		/// <summary>
		/// Returns the angle of complex number.
		/// </summary>
		/// <param name="a">The complex number.</param>
		/// <returns>The angle of complex number.</returns>
		public static double Angle(Complex a)
		{
			if (Mod(a)!=0)
				return Math.Acos(a.re/Mod(a));
			else
                return 0;
		}

		/// <summary>
		/// Returns the exponent of complex number.
		/// </summary>
		/// <param name="a">The complex number.</param>
		/// <returns>The exponent of complex number</returns>
		public static Complex Exp(Complex a)
		{
			return Math.Exp(a.re)*Math.Cos(a.im)+i*Math.Exp(a.re)*Math.Sin(a.im);
		}

		/// <summary>
		/// Natural logarithm of complex number.
		/// </summary>
		/// <param name="a">Source complex number.</param>
		/// <returns>Natural logarithm of complex number.</returns>
		public static Complex Ln(Complex a)
		{
			return Math.Log(Mod(a)) + i*Angle(a);
		}

		/// <summary>
		/// Returns a specified complex number raised to the specified complex power.
		/// </summary>
		/// <param name="a">Base.</param>
		/// <param name="p">Power.</param>
		/// <returns>The complex number a raised to the complex power p.</returns>
		public static Complex Pow(Complex a, Complex p)
		{
			if (Mod(a)==0) 
				return 0;
			else
                return Exp(p*Ln(a));
		}

		/// <summary>
		/// Returns the square root of complex number.
		/// </summary>
		/// <param name="a">Source complex number.</param>
		/// <returns>The square root of complex number</returns>
		public static Complex Sqrt(Complex a)
		{
			return Pow(a,0.5);
		}


		/// <summary>
		/// Returns the hyperbolic sine of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The hyperbolic sine of the complex number</returns>
		public static Complex Sh(Complex a)
		{
			return (Exp(a)-Exp(-a))/2;
		}

		/// <summary>
		/// Returns the hyperbolic cosine of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The hyperbolic cosine of the complex number</returns>
		public static Complex Ch(Complex a)
		{
			return (Exp(a)+Exp(-a))/2;
		}

		/// <summary>
		/// Returns the hyperbolic tangent of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The hyperbolic tangent of the complex number</returns>
		public static Complex Tgh(Complex a)
		{
			return Sh(a)/Ch(a);
		}

		/// <summary>
		/// Returns the hyperbolic cotangent of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The hyperbolic cotangent of the complex number</returns>
		public static Complex Ctgh(Complex a)
		{
			return Ch(a)/Sh(a);
		}
	
		/// <summary>
		/// Returns the sine of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The sine of the complex number</returns>
		public static Complex Sin(Complex a)
		{
			return Sh(i*a)/i;
		}

		/// <summary>
		/// Returns the cosine of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The cosine of the complex number</returns>
		public static Complex Cos(Complex a)
		{
			return Ch(i*a);
		}

		/// <summary>
		/// Returns the tangent of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The tangent of the complex number</returns>
		public static Complex Tg(Complex a)
		{
			return Sin(a)/Cos(a);
		}

		/// <summary>
		/// Returns the cotangent of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The cotangent of the complex number</returns>
		public static Complex Ctg(Complex a)
		{
			return Cos(a)/Sin(a);
		}

		/// <summary>
		/// Returns the arcsine of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The arcsine of the complex number</returns>
		public static Complex Arcsin(Complex a)
		{
			return Math.Sign(a.re)*(-i)*Ln(i*a+Sqrt(1-a*a));
		}

        /// <summary>
        /// Returns the sign of the complex number.
        /// </summary>
        /// <param name="a">Source complex number</param>
        /// <returns>The sign of the complex number</returns>
        public static Complex Sign(Complex a)
        {
            return Math.Sign(a.re);
        }

        /// <summary>
        /// Returns zero if the complex number is less than 0.
        /// </summary>
        /// <param name="a">Source complex number</param>
        /// <returns>0 for negative number </returns>
        public static Complex Zero(Complex a)
        {
            if (a.re < 0) return 0;
            return a.re;
        }

		/// <summary>
		/// Returns the arccosine of the complex number.
		/// </summary>
		/// <param name="a">Source complex number</param>
		/// <returns>The arccosine of the complex number</returns>
		public static Complex Arccos(Complex a)
		{
			return Math.PI/2 - Arcsin(a);
		}
		
		/// <summary>
		/// Override the ToString method so the value appears in write statements.
		/// </summary>
		/// <returns>Result string.</returns>
		public override string ToString() 
		{
			if (Math.Abs(re)<eps)
				re = 0;
			if (Math.Abs(im)<eps)
				im = 0;
			if (im!=0)
			{
				if (im>=0)
					return String.Format("({0}+{1}i)", re, im);
				else
					return String.Format("({0}{1}i)", re, im);
			}
			else
				return String.Format("{0}", re);
		}

		/// <summary>
		/// Converts the standart (a+ib) complex expression string to the complex type.
		/// </summary>
		/// <param name="s">The standart (a+ib) complex expression string.</param>
		/// <returns>The complex nubmer.</returns>
		public static Complex ToComplex(string s)
		{
			string sRe, sIm;
			int posI, posSign;

			s = s.ToLower();

			if (s=="i")
				return new Complex(0,1);

			if (s[0]=='(')
				s = s.Remove(0,1);
			if (s[s.Length-1]==')')
				s = s.Remove(s.Length-1,1);

			if (s[0]=='+')
				s = s.Remove(0,1);

			posI = s.LastIndexOf("i");
			if (posI<0)
			{
				return new Complex(Convert.ToDouble(s),0);
			}
			else
			{
				int posMinus = -1, posPlus = -1;

				for (int i=0; i<=s.Length-1; i++)
					if (s[i]=='+'&&s[i-1]!='e')
						posPlus = i;
				
				
				for (int i=0; i<=s.Length-1; i++)
					if (s[i]=='-'&&s[i-1]!='e')
						posMinus = i;

				if (posMinus>posPlus)
					posSign = posMinus;
				else
					posSign = posPlus;

				if (posSign<=0)
				{
					sIm = s.Substring(0,s.Length-1);
					return new Complex(0,Convert.ToDouble(sIm));
				}
				else
				{
					sRe = s.Substring(0,posSign);
					sIm = s.Substring(posSign,s.Length-posSign-1);
					return new Complex(Convert.ToDouble(sRe),Convert.ToDouble(sIm));
				}
			}
		}
	}
}
