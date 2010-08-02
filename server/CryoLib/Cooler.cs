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
        public int ID{ get;  set; }

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
        public CoolerModel SelectedCooler { get; set; }
        #endregion

        #region state properties - outputs
        public double PowerFactor { get; set; }
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
                PowerFactorSpecified = value;
                SelectedCoolerSpecified = value;
            }
        }

        public bool ShowOutputs
        {
            set
            {
                InputPowerSpecified = value;
            }
        }

        //Serialzation properties
        [System.Xml.Serialization.XmlIgnore]
        public bool InputPowerSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool SelectedCoolerSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool PowerFactorSpecified = false;
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

        #region Constructors
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
			this.ID = navigator.ValueAsInt;
			// Get the constraint list
            this.constraints = new ConstraintCollection(navigator.Clone());;
        }
        #endregion

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Cooler ID: {0}\n", this.coolerID);
			return sb.ToString();
		}
	}
}
