using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace Version_01_App {
	public class Material : CryoObject {
		private List<PropertyDataPoint> thermalConductivityData = new List<PropertyDataPoint>();

		/// <summary>
		/// Constructor - create a material given an XPathNavigator positioned
		/// at a node in an XPathDocument which describes this material.
		/// </summary>
		/// <param name="navigator">The XPathNavigator to use</param>
		public Material(XPathNavigator navigator) {
			navigator.MoveToChild("name", "");
			this.name = navigator.Value;
			navigator.MoveToNext();
			do {
				XPathNavigator clone = navigator.Clone();
				clone.MoveToFirstChild();
				double temp = clone.ValueAsDouble;
				clone.MoveToNext();
				double conductivity = clone.ValueAsDouble;
				PropertyDataPoint point = new PropertyDataPoint(temp, conductivity);
				thermalConductivityData.Add(point);
			} while (navigator.MoveToNext());

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
			sb.AppendFormat("\"{0}\"\n", name);
			sb.Append("Temp\tConductivity\n");
			for (int i = 0; i < thermalConductivityData.Count; i++) {
				sb.AppendFormat("{0}\t{1}\n", thermalConductivityData[i].temp, thermalConductivityData[i].data);
			}
			return sb.ToString();
		}


	}
}
