using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialProperties {
	public abstract class EquationSolver {
		protected double[] coefficients;
		protected int minX;
		protected int maxX;

		public int MinX {
			get { return minX; }
			set { minX = value; }
		}

		public int MaxX {
			get { return maxX; }
			set { maxX = value; }
		}

		public EquationSolver(double[] coefficients, int minX, int maxX) {
			this.coefficients = coefficients;
			this.minX = minX;
			this.maxX = maxX;
		}

		public abstract double Y(double x);
	}
	/// <summary>
	/// Solves the equation: y = 10^(a+b(log10T) + c(log10T)^2 + d(log10T)^3 + e(log10T)^4 + f(log10T)^5 + g(log10T)^6 + h(log10T)^7 + i(log10T)^8)
	/// </summary>
	public class Type1Solver : EquationSolver {
		public Type1Solver(double[] coefficients, int minX, int maxX)
			: base(coefficients, minX, maxX) { }

		public override double Y(double x) {
			double log_ten_x = Math.Log10(x);
			double curPow = 1.0;
			double exponent = 0.0;
			for (int i = 0; i < coefficients.Length; i++) {
				exponent += coefficients[i] * curPow;
				curPow *= log_ten_x;
			}
			double answer = Math.Pow(10.0, exponent);
			return answer;
		}
	}

	/// <summary>
	/// Solves the equation: y=a+bx+cx^2+dx^3+ex^4+fx^5+gx^6+hx^7+ix^8+jx^9+kx^10
	/// </summary>
	public class PolyFitSolver : EquationSolver {
		private double yAtMaxX;

		public PolyFitSolver(double[] coefficients, int minX, int maxX)
			: base(coefficients, minX, maxX)
		{
			yAtMaxX = simpleY(maxX);
		}

		public override double Y(double x) {
			return yAtMaxX - simpleY(x);
		}

		private double simpleY(double x) {
			double answer = 0.0;
			double xRaised = 1.0;
			for (int i = 0; i < coefficients.Length; i++) {
				answer += xRaised * coefficients[i];
				xRaised *= x;
			}
			return answer;
		}
	}

	/// <summary>
	/// Solves the equation: y=a+blnx+c(lnx)^2+d(lnx)^3+e(lnx)^4+f(lnx)^5+g(lnx)^6+h(lnx)^7+i(lnx)^8+j(lnx)^9+k(lnx)^(10)
	/// </summary>
	public class PolyLnSolver : EquationSolver {
		private double yAtMaxX;

		public PolyLnSolver(double[] coefficients, int minX, int maxX)
			: base(coefficients, minX, maxX)
		{
			yAtMaxX = simpleY(maxX);
		}

		public override double Y(double x) {
			return yAtMaxX - simpleY(x);
		}

		private double simpleY(double x) {
			double lnX = Math.Log(x);
			double answer = 0.0;
			double lnXRaised = 1.0;
			for (int i = 0; i < coefficients.Length; i++) {
				answer += lnXRaised * coefficients[i];
				lnXRaised *= lnX;
			}
			return answer;
		}
	}


	public class EquationSolverFactory {
		public static EquationSolver GetSolver(string equationType, double[] coefficients, int minX, int maxX) {
			switch (equationType) {
				//case "Type1":
				case "type1":
					return new Type1Solver(coefficients, minX, maxX);
				case "polyLn":
					return new PolyLnSolver(coefficients, minX, maxX);
				case "polyFit":
					return new PolyFitSolver(coefficients, minX, maxX );
				default:
					string msg = string.Format("Don't know how to solve equations of type \"{0}\"", equationType);
					throw new Exception(msg);
			}
		}
	}

}
