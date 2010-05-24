using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace CryoLib {
	public class Material : CryoObject
    {

        #region Properties
        private List<DataPoint> thermalConductivityData;
		private List<DataPoint> integratedThermalConductivityData;
		private double yieldStrength = -1.0;	// Given in Mega Pascals (MPa)
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
                IntegratedThermalConductivitySpecified = value;
                YieldStrengthSpecified = value;
                MPSpecified = value;
                base.ShowObjectDetails = value;
            }
        }

        //Serialzation properties
        [System.Xml.Serialization.XmlIgnore]
        public bool YieldStrengthSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool IntegratedThermalConductivitySpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool MPSpecified = false;
        #endregion

        #region Property Accessors
        public double YieldStrength {
			get { return yieldStrength; }
            set { yieldStrength = value; }
		}

		public List<DataPoint> MP {
			get { return thermalConductivityData; }
            set { thermalConductivityData = value; }
		}

		public List<DataPoint> IntegratedThermalConductivity {
			get { return integratedThermalConductivityData; }
            set { integratedThermalConductivityData = value;  }
        }
        #endregion

        #region Constructors
        public Material() {
			this.Name = "(no such material)";
		}

		/// <summary>
		/// Constructor - create a material given an XPathNavigator positioned
		/// at a node in an XPathDocument which describes this material.
		/// </summary>
		/// <param name="navigator">The XPathNavigator to use</param>
		public Material(XPathNavigator navigator) {
			// get the name
			navigator.MoveToChild("name", "");
			this.Name = navigator.Value;

			navigator.MoveToNext("ID", "");
			this.id = navigator.ValueAsInt;

			navigator.MoveToNext("yieldStrength","");
			yieldStrength = navigator.ValueAsDouble;

			navigator.MoveToNext("price","");
			price = navigator.ValueAsDouble;

			navigator.MoveToNext("priceUnit","");
			priceUnit = navigator.Value;

			navigator.MoveToNext("currencyUnit","");
			currencyUnit = navigator.Value;

			navigator.MoveToNext("thermalConductivity","");
			thermalConductivityData = readDataSet(navigator);
			if( navigator.MoveToNext("integratedThermalConductivity","") ) {
				integratedThermalConductivityData = readDataSet(navigator);
			}
		}


		public Material(string name, int id, double yieldStrength, List<DataPoint> pm, List<DataPoint>integratedThermalConductivity, double price, string priceUnit, string currencyUnit)
			:
			base(name, id, price, priceUnit, currencyUnit) {
			this.yieldStrength = yieldStrength;
			this.thermalConductivityData = pm;
			this.integratedThermalConductivityData = integratedThermalConductivity;
            }
        #endregion

        private List<DataPoint> readDataSet(XPathNavigator navigator)
        {
            List<DataPoint> answer = new List<DataPoint>();
            if (navigator.MoveToChild("dataPoint", ""))
            {
                do
                {
                    navigator.MoveToChild("temp", "");
                    double temp = navigator.ValueAsDouble;
                    navigator.MoveToNext("conductivity", "");
                    double conductivity = navigator.ValueAsDouble;
                    DataPoint point = new DataPoint(temp, conductivity);
                    answer.Add(point);
                    navigator.MoveToParent();
                } while (navigator.MoveToNext("dataPoint", ""));
                navigator.MoveToParent();
            }
            return answer;
        }

        public double Goodness(double temperature)
        {
            if (yieldStrength < 0.0)
            {
                return -1.0;
            }
            else if (integratedThermalConductivityData == null)
            {
                return -1.0;
            }
            else
            {
                return yieldStrength / integratedThermalConductivityData[(int)temperature].data;
            }
        }

		public override MWNumericArray getData(string dataType) {
			if (dataType != "PM") {
				string msg = string.Format("Data type \"{0}\" is not defined for Materials", dataType);
				throw new Exception(msg);
			}
			double[,] data = new double[thermalConductivityData.Count, 2];
			for (int i = 0; i < thermalConductivityData.Count; i++) {
				data[i, 0] = thermalConductivityData[i].temp;
				data[i, 1] = thermalConductivityData[i].data;
			}
			return (MWNumericArray)data;
		}

		public override string Describe() {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("\"{0}\"\n", Name);
			sb.Append("Temp\tConductivity\n");
			for (int i = 0; i < thermalConductivityData.Count; i++) {
				sb.AppendFormat("{0}\t{1}\n", thermalConductivityData[i].temp, thermalConductivityData[i].data);
			}
			return sb.ToString();
		}

		public override string ToString() {
			return string.Format( "{0} ({1:C0} / m^3)", Name, price );
		}


	}
}
