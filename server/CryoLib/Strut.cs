using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace CryoLib {
	public class Strut {
        #region properties set by the problem
        private double heatLeak;
        private SupportMode supportMode;
        private string strutID;
        private ConstraintCollection constraints;

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
        private ConstraintCollection strutConstraints;

        [XmlArray]
        public ConstraintCollection StrutConstraints
        {
            get { return strutConstraints; }
            set { strutConstraints = value; }
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
			sb.AppendFormat("Material: {0}", material.Describe());
			return sb.ToString();
		}
	}
}
