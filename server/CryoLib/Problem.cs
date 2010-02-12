using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace CryoLib {
	public class Problem {
		private string name;
		private int id;
		private string description;
		private double monetaryIncentive;
		private ConstraintCollection constraints;
        private StrutCollection struts;
        private CoolerCollection coolers;
		private ProblemImageCollection problemImageCollection;
		private bool solved;
		const double DEFAULT_MIN_STRUT_LENGTH = 0.01;
		const double DEFAULT_MAX_STRUT_LENGTH = 10.0;
		const double DEFAULT_MIN_STRUT_CROSS_SECTION = 0.001;
		const double DEFAULT_MAX_STRUT_CROSS_SECTION = 0.5;


		[XmlAttribute]
		public string Name {
			get { return name; }
			set { name = value; }
		}

		[XmlAttribute]
		public int ID {
			get { return id; }
			set { id = value; }
		}

		[XmlElement]
		public string Description {
			get { return description; }
			set { description = value; }
		}

		[XmlElement]
		public double MonetaryIncentive {
			get { return monetaryIncentive; }
			set { monetaryIncentive = value; }
		}

		public ConstraintCollection Constraints {
			get { return constraints; }
			set { constraints = value; }
		}

        public StrutCollection Struts
        {
            get { return struts; }
            set { struts = value; }
        }

        public CoolerCollection Coolers
        {
            get { return coolers; }
            set { coolers = value; }
        }

		public ProblemImageCollection ImageCollection {
			get { return problemImageCollection; }
			set { problemImageCollection = value; }
		}

		public bool Solved {
			get { return solved; }
			set { solved = value; }
		}

		public Problem(
						string name,
						int id,
						string description,
						double incentive,
						ProblemImageCollection imageCollection,
						ConstraintCollection constraints,
                        StrutCollection struts,
                        CoolerCollection coolers)
		{
			this.name = name;
			this.id = id;
			this.description = description;
			this.monetaryIncentive = incentive;
			this.problemImageCollection = imageCollection;
			this.constraints = constraints;
            this.struts = struts;
            this.coolers = coolers;
		}

		public Problem( XPathNavigator navigator ) {
			List<string> imageList = new List<string>();

			// Get the name
			navigator.MoveToChild("name", "");
			name = navigator.Value;

			// Get the ID
			navigator.MoveToNext("ID", "");
			id = navigator.ValueAsInt;

			// Get the description
			navigator.MoveToNext("problemDescription","");
			description = fixFormatting( navigator.Value );

			// Get the monetaryIncentive
			navigator.MoveToNext("monetaryIncentive","");
			monetaryIncentive = navigator.ValueAsDouble;

			navigator.MoveToNext("images","");
			problemImageCollection = new ProblemImageCollection(navigator.Clone());

			// Get the constraint list
            this.constraints = new ConstraintCollection(navigator.Clone());

            //Get the strut list
            this.struts = new StrutCollection(navigator.Clone());

            //Get the cooler list
            this.coolers = new CoolerCollection(navigator.Clone());
        }

		/// <summary>
		/// Convenience property - to make life easier.
		/// </summary>
        //TODO:  Fix these and getConstraint method
		public double MinStrutLength {
			get {
				return getConstraint(VALUE.STRUT_LENGTH, OP.GE, DEFAULT_MIN_STRUT_LENGTH);
			}
		}

		/// <summary>
		/// Convenience property - to make life easier.
		/// </summary>
		public double MaxStrutLength {
			get {
				return getConstraint(VALUE.STRUT_LENGTH, OP.LE, DEFAULT_MAX_STRUT_LENGTH);
			}
		}

		/// <summary>
		/// Convenience property - to make life easier.
		/// </summary>
		public double MinStrutCrossSection {
			get {
				return getConstraint(VALUE.STRUT_CROSS_SECTION, OP.GE, DEFAULT_MIN_STRUT_CROSS_SECTION);
			}
		}

		/// <summary>
		/// Convenience property - to make life easier.
		/// </summary>
		public double MaxStrutCrossSection {
			get {
				return getConstraint(VALUE.STRUT_CROSS_SECTION, OP.LE, DEFAULT_MAX_STRUT_CROSS_SECTION);
			}
		}

		/// <summary>
		/// Convenience property - to make life easier.
		/// </summary>
		public double InputPowerLimit {
			get {
				return getConstraint(VALUE.INPUT_POWER, OP.LE, double.MaxValue);
			}
		}

		public double StrengthRequirement {
			get {
				return getConstraint(VALUE.FORCE_LIMIT, OP.GE, 0.0);
			}
		}

		public double TargetTemperature {
			get {
				return getConstraint(VALUE.TEMP, OP.LT, double.MaxValue);
			}
		}


		/// <summary>
		/// No-argument (default) constructor.
		/// </summary>
		public Problem() {
			name = "(no such problem)";
		}

		public override string ToString() {
			return name;
		}

		private double getConstraint( VALUE value, OP op, double defaultAnswer) {
			Constraint c = findConstraint(value, op);
			if (c == null) {
				return defaultAnswer;
			} else {
				return c.Target;
			}
		}

		private double getConstraint( VALUE value, OP op ) {
			Constraint c = findConstraint(value, op);
			if (c == null) {
				string msg = String.Format("Can't find constraint for Value=\"{0}\" and Op=\"{1}\"",
					value, op);
				throw new Exception(msg);
			} else {
				return c.Target;
			}
		}

		private Constraint findConstraint(VALUE value, OP op) {
			// Problem constraints might say that Temp <= x or Temp < x, treat these the same here, same goes for
			// other constraint boundaries, e.g. strength >= x or strength > x.
			OP alternateOp;
			switch (op) {
				case OP.GE:
					alternateOp = OP.GT;	// consider GT and GE equivalent
					break;
				case OP.GT:
					alternateOp = OP.GE;	// consider GT and GE equivalent
					break;
				case OP.LE:
					alternateOp = OP.LT;	// consider LT and LE equivalent
					break;
				case OP.LT:
					alternateOp = OP.LE;	// consider LT and LE equivalent
					break;
				default:
					alternateOp = op;		// this op has no equivalent
					break;
			}
			foreach (Constraint c in constraints) {
				if (c.Value == value && (c.Op == op || c.Op == alternateOp) ) {
					return c;
				}
			}
				
			return null;
		}

		private string fixFormatting(string src) {
			string answer = src.Replace("\n", " ");
			answer = answer.Replace("\t", "");
			return answer;
		}

	}

	public enum SupportMode { COMPRESSION, TENSION };
}