using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using System.Xml.Serialization;

namespace CryoLib {
	public abstract class CryoObject {
		public string Name;
		public int id;
		public double price = -1;
		public string priceUnit = "";
		public string currencyUnit = "";

        #region Constructors
        public CryoObject(string name, int id, double price, string priceUnit, string currencyUnit) {
			this.Name = name;
			this.id = id;
			this.price = price;
			this.priceUnit = priceUnit;
			this.currencyUnit = currencyUnit;
		}

		public CryoObject() { }
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
                priceSpecified = value;
                priceUnitSpecified = value;
                currencyUnitSpecified = value;
            }
        }

        //Serialzation properties
        [System.Xml.Serialization.XmlIgnore]
        public bool priceSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool priceUnitSpecified = false;

        [System.Xml.Serialization.XmlIgnore]
        public bool currencyUnitSpecified = false;
        #endregion

		/// <summary>
		/// This is intended to return a longer string describing the
		/// object in some detail.
		/// </summary>
		/// <returns></returns>
		public abstract string Describe();

		/// <summary>
		/// Get some piece of data describing the object.  The kinds of data
		/// available depend on the kind of object.
		/// </summary>
		/// <param name="dataType"></param>
		/// <returns></returns>
		public abstract MWNumericArray getData(string dataType);

		public override string ToString() {
			if (price >= 0) {
				return string.Format("{0} ({1} {2} {3})", Name, price, currencyUnit, priceUnit);
			} else {
				return Name;
			}
		}

	}
}
