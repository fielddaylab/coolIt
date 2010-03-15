using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace CryoLib {
    /**
     * Class that represents the coolers included in a problem definition
     * Primarily a placeholder for constraints on the coolers
     **/
	public class Cooler {
        #region properties set by the problem
        private string coolerID;
        private ConstraintCollection constraints;

        [XmlAttribute]
        public string ID
        {
            get { return coolerID; }
            set { coolerID = value; }
        }

        [XmlArray]
        public ConstraintCollection Constraints
        {
            get { return constraints; }
            set { constraints = value; }
        }
        #endregion

        #region state properties
        public double InputPower { get; set; }

        [XmlElement]
        public CoolerType SelectedCooler { get; set; }
        #endregion

        #region convenience properties - accessors to constraint values
        /// <summary>
        /// Convenience property - to make life easier.
        /// </summary>
        public double InputPowerLimit
        {
            get
            {
                return constraints.getConstraintTarget(VALUE.INPUT_POWER, OP.LE, double.MaxValue);
            }
        }
        #endregion

        /**
         * Parameterless constructor is necessary for serialization
         **/
        public Cooler()
        {

        }

        /**
         * Constructor used to load the strut from a problem definition
         **/
        public Cooler( XPathNavigator navigator ) {
			// Get the ID
			navigator.MoveToChild("ID", "");
			this.ID = navigator.Value;
			// Get the constraint list
            this.constraints = new ConstraintCollection(navigator.Clone());;
		}

		public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Cooler ID: {0}\n", this.coolerID);
			return sb.ToString();
		}
	}
}
