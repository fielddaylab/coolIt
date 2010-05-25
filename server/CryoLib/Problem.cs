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
        private double heatLeak;
		private ConstraintCollection constraints;
        private StrutTypeCollection struts;
        private CoolerCollection coolers;
		private ProblemImageCollection problemImageCollection;

        #region State Properties
        private bool solved;
        public double Temperature { get; set; }
        public double PowerFactor { get; set; }
        public double Cost { get; set; }
        #endregion

        #region Serialzation Properties
        /**
         * Method that controls whether or not all the object properties
         * should be serialized when returned in XML by the
         * webservice.  There is a specific pattern that can be utilized 
         * to control this, which is what all the "Specified" properties are for
         * http://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx
         **/
        public bool ShowObjectDetails
        {
            set
            {
                DescriptionSpecified = value;
                MonetaryIncentiveSpecified = value;
                HeatLeakSpecified = value;
                ConstraintsSpecified = value;
                ImageCollectionSpecified = value;
                PowerFactorSpecified = value;
                StrutsSpecified = value;
                CoolersSpecified = value;
            }
        }

        public bool ShowOutputs
        {
            set
            {
                TemperatureSpecified = value;
                CostSpecified = value;
                SolvedSpecified = value;
                StrutsSpecified = value;
                CoolersSpecified = value;
            }
        }

        //Serialzation properties
        [System.Xml.Serialization.XmlIgnore]
        public bool DescriptionSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool MonetaryIncentiveSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool HeatLeakSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool ConstraintsSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool StrutsSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool CoolersSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool ImageCollectionSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool TemperatureSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool PowerFactorSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool CostSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool SolvedSpecified = false;
        #endregion

        #region Property Accessors
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

		public string Description {
			get { return description; }
			set { description = value; }
		}

		public double MonetaryIncentive {
			get { return monetaryIncentive; }
			set { monetaryIncentive = value; }
		}

        public double HeatLeak
        {
            get { return heatLeak; }
            set { heatLeak = value; }
        }

		public ConstraintCollection Constraints {
			get { return constraints; }
			set { constraints = value; }
		}

        public StrutTypeCollection Struts
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
        #endregion

        #region Constructors
        public Problem(
						string name,
						int id,
						string description,
						double incentive,
                        double heatLeak,
						ProblemImageCollection imageCollection,
						ConstraintCollection constraints,
                        StrutTypeCollection struts,
                        CoolerCollection coolers)
		{
			this.name = name;
			this.id = id;
			this.description = description;
			this.monetaryIncentive = incentive;
            this.heatLeak = heatLeak;
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

            // Get the heat leak
            navigator.MoveToNext("heatLeak", "");
            heatLeak = navigator.ValueAsDouble;

			navigator.MoveToNext("images","");
			problemImageCollection = new ProblemImageCollection(navigator.Clone());

			// Get the constraint list
            this.constraints = new ConstraintCollection(navigator.Clone());

            //Get the strut list
            this.struts = new StrutTypeCollection(navigator.Clone());

            //Get the cooler list
            this.coolers = new CoolerCollection(navigator.Clone());
        }

        /// <summary>
        /// No-argument (default) constructor.
        /// </summary>
        public Problem()
        {
            //name = "(no such problem)";
            this.constraints = new ConstraintCollection();
            this.problemImageCollection = new ProblemImageCollection();
            this.struts = new StrutTypeCollection();
            this.coolers = new CoolerCollection();
        }
        #endregion

		public double TargetTemperature {
			get {
				return constraints.getConstraintTarget(VALUE.TEMP, OP.LT, double.MaxValue);
			}
		}

		public override string ToString() {
			return name;
		}

		private string fixFormatting(string src) {
			string answer = src.Replace("\n", " ");
			answer = answer.Replace("\t", "");
			return answer;
		}

	}

	public enum SupportMode { COMPRESSION, TENSION };
}
