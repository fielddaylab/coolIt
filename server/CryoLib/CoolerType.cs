using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;
using System.IO;
using System.Xml.Serialization;


namespace CryoLib {
	public class CoolerType : CryoObject {

		private List<DataPoint> coolingPowerData = new List<DataPoint>();
		private InputPowerCalculator inputPowerCalc;
		private double maxInputPower;
		private double maxOutputPower;

		/// <summary>
		/// No-argument (default) constructor.
		/// </summary>
		public CoolerType() {
			this.Name = "(no such cooler)";
		}

		/// <summary>
		/// Constructor - create a cooler given an XPathNavigator positioned
		/// at a node in an XPathDocument which describes this cooler.  This constructor
		/// would generally be used by the CoolIt Web Service.
		/// </summary>
		/// <param name="navigator">The XPathNavigator to use</param>
		public CoolerType(XPathNavigator navigator) {
			navigator.MoveToChild("name", "");
			this.Name = navigator.Value;
			navigator.MoveToNext("ID", "");
			this.id = navigator.ValueAsInt;
			navigator.MoveToNext("price","");
			price = navigator.ValueAsInt;
			navigator.MoveToNext("priceUnit","");
			priceUnit = navigator.Value;
			navigator.MoveToNext("currencyUnit","");
			currencyUnit = navigator.Value;
			navigator.MoveToNext("dataPoint","");
			do {
				XPathNavigator clone = navigator.Clone();
				clone.MoveToChild("temp","");
				double temp = clone.ValueAsDouble;
				clone.MoveToNext("coolingPower","");
				double coolingPower = clone.ValueAsDouble;
				DataPoint point = new DataPoint(temp, coolingPower);
				coolingPowerData.Add(point);
			} while (navigator.MoveToNext("dataPoint",""));
			maxOutputPower = coolingPowerData[1].data;

		}

		/// <summary>
		/// Constructor - create a cooler given data describing the cooler.  This constructor
		/// would normally be used by a client of the CoolIt Web Service.  The web service would
		/// supply the data.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="cpm"></param>
		/// <param name="price"></param>
		/// <param name="priceUnit"></param>
		/// <param name="currencyUnit"></param>
		public CoolerType(string name, int id, List<DataPoint> cpm, double price, string priceUnit, string currencyUnit)
			:
			base(name, id, price, priceUnit, currencyUnit) {
			this.coolingPowerData = cpm;
			maxOutputPower = coolingPowerData[1].data;
		}

		/// <summary>
		/// Return the Cooling Power Matrix
		/// </summary>
		public List<DataPoint> CPM {
			get { return coolingPowerData; }
		}

		public InputPowerCalculator InputPowerCalculator {
			set {
				inputPowerCalc = value;
				maxInputPower = calcMaxInputPower();
			}
		}

		public double maxPowerFactor(double inputPowerLimit, double targetTemp) {
			Range range = new Range(0.0, 1.0);
			for (int i = 0; i < 10; i++) {
				range = iterate(range, inputPowerLimit, targetTemp);
			}
			if (InputPower(targetTemp, range.high) <= inputPowerLimit) {
				return range.high;
			} else if (InputPower(targetTemp, range.Average) <= inputPowerLimit) {
				return range.Average;
			} else {
				return range.low;
			}
		}

		private Range iterate(Range range, double inputPowerLimit, double targetTemp) {
			double middle = range.Average;
			double inputPower = InputPower(targetTemp, middle);
			if (inputPower < inputPowerLimit) {
				return new Range(middle, range.high);
			} else {
				return new Range(range.low, middle);
			}
		}

		private struct Range {
			public double low;
			public double high;

			public Range(double low, double high) {
				this.low = low;
				this.high = high;
			}

			public double Average {
				get { return (low + high) / 2.0; }
			}
		}

		private double calcMaxInputPower() {
			double maxPower = 0.0;
			for (double i = 0.0; i < 301.0; i++) {
				double pwr = InputPower(i, 1.0);
				if (pwr > maxPower) {
					maxPower = pwr;
				}
			}
			return maxPower;
		}

		public double OutputPower(double temperature, double powerFactor) {
			double x1 = coolingPowerData[0].temp;
			double y1 = coolingPowerData[0].data;
			double x2 = coolingPowerData[1].temp;
			double y2 = coolingPowerData[1].data;
			double x = temperature;
			double y = y1 + ((x - x1)*(y2 - y1) / (x2 - x1));
			double powerFactoredY = y - (coolingPowerData[1].data * (1 - powerFactor));
			if( powerFactoredY < 0 ) {
				return 0;
			} else {
				return powerFactoredY;
			}
		}

		public double MaxOutputPower {
			get { return maxOutputPower; }
		}

		public double MaxInputPower {
			get { return maxInputPower; }
		}

		public double InputPower(double temperature, double powerFactor) {
			if (inputPowerCalc == null) {
				throw new Exception("Specific Power Calculator must be set before calling InputPower() function");
			}
			double outputPower = OutputPower(temperature, powerFactor);
			double answer = inputPowerCalc.InputPower(temperature, outputPower);
			return answer;
		}


		public override MWNumericArray getData(string dataType) {
			return (MWNumericArray)getDataNative(dataType);
		}

		public double[,] getDataNative(string dataType) {
			if (dataType != "CPM") {
				string msg = string.Format("Data type \"{0}\" is not defined for Coolers", dataType);
				throw new Exception(msg);
			}
			double[,] data = new double[coolingPowerData.Count, 2];
			for (int i = 0; i < coolingPowerData.Count; i++) {
				data[i, 0] = coolingPowerData[i].temp;
				data[i, 1] = coolingPowerData[i].data;
			}
			return data;
		}


		public override string Describe() {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("\"{0}\"\n", Name);
			sb.Append("Temp\tCooling Power\n");
			for (int i = 0; i < coolingPowerData.Count; i++) {
				sb.AppendFormat("{0}\t{1}\n", coolingPowerData[i].temp, coolingPowerData[i].data);
			}
			return sb.ToString();
		}

		public override string ToString() {
			return string.Format("{0} ({1:C0})", Name, price);
		}


	}
}
