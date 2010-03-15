using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace CryoLib {
	public class StrutType {
        const double DEFAULT_MIN_STRUT_LENGTH = 0.01;
        const double DEFAULT_MAX_STRUT_LENGTH = 10.0;
        const double DEFAULT_MIN_STRUT_CROSS_SECTION = 0.001;
        const double DEFAULT_MAX_STRUT_CROSS_SECTION = 0.5;

        #region properties set by the problem

        private SupportMode supportMode;
        private string strutID;
        private int count;

        [XmlAttribute]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

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
        private double length = 0.1;
        private double crossSectionalArea;
        private Material material;

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

		public double CrossSectionalArea {
			get { return crossSectionalArea; }
            set { crossSectionalArea = value; }
		}

        [XmlElement]
		public Material Material {
			get { return material; }
            set { material = value; }
        }
        #endregion


        #region Convenince Properties
        /// <summary>
        /// Convenience property - to make life easier.
        /// </summary>
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
        public StrutType()
        {

        }

        /**
         * Constructor used within the UI to set user selected values
         * This may go away depending on UI changes?
         **/
        public StrutType(double length, double crossSectionalArea, Material material)
        {
            this.length = length;
            this.crossSectionalArea = crossSectionalArea;
            this.material = material;
            this.Count = 1;
        }

        public StrutType(double length, double crossSectionalArea, Material material, int strutCount) {
			this.length = length;
			this.crossSectionalArea = crossSectionalArea;
			this.material = material;
            this.Count = strutCount;
		}

        /**
         * Constructor used to load the strut from a problem definition
         **/
        public StrutType( XPathNavigator navigator ) {
			// Get the ID
			navigator.MoveToChild("ID", "");
			this.ID = navigator.Value;

            navigator.MoveToNext("count", "");
            this.count = navigator.ValueAsInt;

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
            sb.AppendFormat("Strut Type ID: {0}\n", this.strutID);
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
