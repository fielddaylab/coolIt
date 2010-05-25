using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace CryoLib {
	public class Constraint : IComparable<Constraint> {
		private VALUE value;
		private OP op;
		private double target;

		[XmlAttribute]
		public VALUE Value {
			get { return value; }
			set { this.value = value; }
		}

		[XmlAttribute]
		public OP Op {
			get { return op; }
			set { op = value; }
		}

		[XmlAttribute]
		public double Target {
			get { return target; }
			set { target = value; }
		}

		public Constraint(VALUE value, OP op, double target) {
			this.value = value;
			this.op = op;
			this.target = target;
		}

		public Constraint(XPathNavigator navigator) {
			navigator.MoveToChild("Value", "");
			switch (navigator.Value) {
				case "Strut Length":			// unit is meter (m)
					value = VALUE.STRUT_LENGTH;
					break;
				case "Strut Cross Section":		// unit is squareMeter (m^2)
					value = VALUE.STRUT_CROSS_SECTION;
					break;
				case "Strength":				// unit is megaNewton (MN)
					value = VALUE.STRENGTH;
					break;
				case "Input Power":				// unit is Watt (W)
					value = VALUE.INPUT_POWER;
					break;
				case "Temp":					// unit is Kelvin (K)
					value = VALUE.TEMP;			
					break;
				case "Cost":					// unit is U.S. dollar ($)
					value = VALUE.COST;			
					break;
				default:
					string msg = String.Format("Unexpected constraint value type ({0})", navigator.Value);
					throw new Exception(msg);
			}
			navigator.MoveToNext();
			switch (navigator.Value) {
				case "LT":
					op = OP.LT;
					break;
				case "LE":
					op = OP.LE;
					break;
				case "EQ":
					op = OP.EQ;
					break;
				case "GE":
					op = OP.GE;
					break;
				case "GT":
					op = OP.GT;
					break;
				case "NE":
					op = OP.NE;
					break;
				default:
					string msg = String.Format("Unexpected constraint operator ({0})", navigator.Value);
					throw new Exception(msg);
			}
			navigator.MoveToNext();
			target = double.Parse(navigator.Value);
		}

		public bool CheckValue(double value) {
			switch (op) {
				case OP.EQ:
					return value == target;
				case OP.GE:
					return value >= target;
				case OP.GT:
					return value > target;
				case OP.LE:
					return value <= target;
				case OP.LT:
					return value < target;
				case OP.NE:
					return value != target;
				default:
					return false;
			}
		}

		/// <summary>
		/// No-argument (default) constructor.
		/// </summary>
		public Constraint() {
        }

        #region Compare
        /**
         * ICompare implementation so that constraints can be sorted
         * Sort order is determined by definition order of the VALUE enum
         */
        public int CompareTo(Constraint other)
        {
			if (this.Value < other.Value) {
				return -1;
			} else if (this.Value > other.Value) {
				return 1;
			} else {
				return 0;
			}
        }
        #endregion
    }

	/// <summary>
	/// These values are in order of priority for giving feedback - i.e. if the strut breaks, say that in
	/// feedback and ignore other problems like too much power.
	/// </summary>
	public enum VALUE { STRENGTH, INPUT_POWER, TEMP, COST, STRUT_LENGTH, STRUT_CROSS_SECTION };

	public enum OP { LT, LE, EQ, GE, GT, NE };

}
