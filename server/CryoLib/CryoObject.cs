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

		public CryoObject(string name, int id, double price, string priceUnit, string currencyUnit) {
			this.Name = name;
			this.id = id;
			this.price = price;
			this.priceUnit = priceUnit;
			this.currencyUnit = currencyUnit;
		}

		public CryoObject() { }



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
