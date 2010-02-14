using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace CryoLib {
	public class Strut {
        const double DEFAULT_MIN_STRUT_LENGTH = 0.01;
        const double DEFAULT_MAX_STRUT_LENGTH = 10.0;
        const double DEFAULT_MIN_STRUT_CROSS_SECTION = 0.001;
        const double DEFAULT_MAX_STRUT_CROSS_SECTION = 0.5;

        #region properties set by the problem
        private double heatLeak;
        private SupportMode supportMode;
        private string strutID;

        [XmlAttribute]
        public string ID
        {
            get { return strutID; }
            set { strutID = value; }
        }

        [XmlAttribute]
        public SupportMode SupportMode
        {
            get { return supportMode; }
            set { supportMode = value; }
        }

        [XmlAttribute]
        public double HeatLeak
        {
            get { return heatLeak; }
            set { heatLeak = value; }
        }

        //constraints set by the problem
        private ConstraintCollection constraints;

        [XmlArray]
        public ConstraintCollection Constraints
        {
            get { return constraints; }
            set { constraints = value; }
        }
        #endregion

        #region user selected properties, set in the UI
        private double length;
        private double crossSectionalArea;
        private Material material;

        public double Length
        {
            get { return length; }
        }

		public double CrossSectionalArea {
			get { return crossSectionalArea; }
		}

		public Material Material {
			get { return material; }
        }
        #endregion


        #region Convenince Properties
        /// <summary>
        /// Convenience property - to make life easier.
        /// </summary>
        //TODO:  Fix these and getConstraint method
        public double MinStrutLength
        {
            get
            {
                return constraints.getConstraintTarget(VALUE.STRUT_LENGTH, OP.GE, DEFAULT_MIN_STRUT_LENGTH);
            }
        }

        /// <summary>
        /// Convenience property - to make life easier.
        /// </summary>
        public double MaxStrutLength
        {
            get
            {
                return constraints.getConstraintTarget(VALUE.STRUT_LENGTH, OP.LE, DEFAULT_MAX_STRUT_LENGTH);
            }
        }

        /// <summary>
        /// Convenience property - to make life easier.
        /// </summary>
        public double MinStrutCrossSection
        {
            get
            {
                return constraints.getConstraintTarget(VALUE.STRUT_CROSS_SECTION, OP.GE, DEFAULT_MIN_STRUT_CROSS_SECTION);
            }
        }

        /// <summary>
        /// Convenience property - to make life easier.
        /// </summary>
        public double MaxStrutCrossSection
        {
            get
            {
                return constraints.getConstraintTarget(VALUE.STRUT_CROSS_SECTION, OP.LE, DEFAULT_MAX_STRUT_CROSS_SECTION);
            }
        }
        #endregion

        /**
         * Parameterless constructor is necessary for serialization
         **/
        public Strut()
        {

        }

        /**
         * Constructor used within the UI to set user selected values
         * This may go away depending on UI changes?
         **/
        public Strut(double length, double crossSectionalArea, Material material) {
			this.length = length;
			this.crossSectionalArea = crossSectionalArea;
			this.material = material;
		}

        /**
         * Constructor used to load the strut from a problem definition
         **/
        public Strut( XPathNavigator navigator ) {
			// Get the ID
			navigator.MoveToChild("ID", "");
			this.ID = navigator.Value;

            // Get the heat leak
            navigator.MoveToNext("heatLeak", "");
            heatLeak = navigator.ValueAsDouble;

            // Get the support mode
            navigator.MoveToNext("supportMode", "");
            switch (navigator.Value)
            {
                case "Compression":
                    SupportMode = SupportMode.COMPRESSION;
                    break;
                case "Tension":
                    SupportMode = SupportMode.TENSION;
                    break;
            }

			// Get the constraint list
            this.constraints = new ConstraintCollection(navigator.Clone());;
		}

		public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Strut ID: {0}\n", this.strutID);
			sb.AppendFormat("Length: {0}\n", length);
			sb.AppendFormat("CrossSectionalArea: {0}\n", crossSectionalArea);
            if (material != null)
            {
                sb.AppendFormat("Material: {0}", material.Describe());
            }
			return sb.ToString();
		}
	}
}
