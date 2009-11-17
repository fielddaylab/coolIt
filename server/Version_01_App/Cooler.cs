using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;
using System.IO;


namespace Version_01_App {
	public class Cooler : CryoObject {
		private List<PropertyDataPoint> coolingPowerData = new List<PropertyDataPoint>();

		/// <summary>
		/// Constructor - create a cooler given an XPathNavigator positioned
		/// at a node in an XPathDocument which describes this cooler.
		/// </summary>
		/// <param name="navigator">The XPathNavigator to use</param>
		public Cooler(XPathNavigator navigator) {
			navigator.MoveToChild("name", "");
			this.name = navigator.Value;
			navigator.MoveToNext();
			do {
				XPathNavigator clone = navigator.Clone();
				clone.MoveToFirstChild();
				double temp = clone.ValueAsDouble;
				clone.MoveToNext();
				double coolingPower = clone.ValueAsDouble;
				PropertyDataPoint point = new PropertyDataPoint(temp, coolingPower);
				coolingPowerData.Add(point);
			} while (navigator.MoveToNext());

		}
		public override MWNumericArray getData(string dataType) {
			if( dataType != "CPM" ) {
				string msg = string.Format("Data type \"{0}\" is not defined for Coolers", dataType);
				throw new Exception(msg);
			}
			double[,] data = new double[coolingPowerData.Count,2];
			for (int i = 0; i < coolingPowerData.Count; i++) {
				data[i, 0] = coolingPowerData[i].temp;
				data[i, 1] = coolingPowerData[i].data;
			}
			return (MWNumericArray)data;
		}

		public override string Describe() {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("\"{0}\"\n", name);
			sb.Append("Temp\tCooling Power\n");
			for (int i = 0; i < coolingPowerData.Count; i++) {
				sb.AppendFormat("{0}\t{1}\n", coolingPowerData[i].temp, coolingPowerData[i].data);
			}
			return sb.ToString();
		}


	}
}
