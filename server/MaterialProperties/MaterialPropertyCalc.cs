using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace MaterialProperties {
	public class MaterialPropertyCalc {
		private string name;
		private int id;
		private double price;
		private double scaledPrice;
		private double density;
		private double tensileStrength;
		private double compressionStrength;
		private double youngsModulus;
		private double shearStrength;
		private bool usable = true;
		private EquationSolver conductivitySolver;
		private EquationSolver integratedConductivitySolver;
		private int minX;
		private int maxX;
		private double[] temperature;
		private double[] conductivity;
		private double[] integratedConductivity;
		const int ROOM_TEMP = 300;

		public bool Usable {
			get { return usable; }
		}

		public string Name {
			get { return name; }
		}

		public int Id {
			get { return id; }
		}

		public double Price {
			get { return price; }
		}

		public double ScaledPrice {
			get { return scaledPrice; }
		}

		public double Density {
			get { return density; }
		}

		public double TensileStrength {
			get { return tensileStrength; }
		}

		public double CompressionStrength {
			get { return compressionStrength; }
		}

		public double YoungsModulus {
			get { return youngsModulus; }
		}

		public double ShearStrength {
			get { return shearStrength; }
		}

		public override string ToString() {
			return name;
		}

		public int MinX {
			get { return minX; }
		}

		public int MaxX {
			get { return maxX; }
		}

		/// <summary>
		/// Construct MaterialPropertyCalc from an XML file given an XPathNavigator.
		/// </summary>
		/// <param name="navigator">The navigator</param>
		public MaterialPropertyCalc(XPathNavigator navigator) {
			navigator.MoveToChild("name", "");
			this.name = navigator.Value;

			navigator.MoveToNext("ID", "" );
			this.id = navigator.ValueAsInt;

			navigator.MoveToNext("price", "");
			this.price = navigator.ValueAsDouble;
			if (this.price < 0.0) {
				this.usable = false;
			}

			navigator.MoveToNext("density", "");
			this.density = navigator.ValueAsDouble;
			if (this.density < 0.0) {
				this.usable = false;
			}

			navigator.MoveToNext("tensileStrength", "" );
			this.tensileStrength = navigator.ValueAsDouble;
			if (this.tensileStrength < 0.0) {
				this.usable = false;
			}

			if (navigator.MoveToNext("compressionStrength", "" )) {
				this.compressionStrength = navigator.ValueAsDouble;
			} else {
				this.compressionStrength = -1;
			}

			if (navigator.MoveToNext("youngsModulus", "")) {
				this.youngsModulus = navigator.ValueAsDouble;
			} else {
				this.youngsModulus = -1;
			}

			if (navigator.MoveToNext("shearStrength", "")) {
				this.shearStrength = navigator.ValueAsDouble;
			} else {
				this.shearStrength = -1;
			}

			navigator.MoveToNext("thermalConductivity", "");
			this.conductivitySolver = parseSolver(navigator.Clone());

			if (navigator.MoveToNext("integratedThermalConductivity", "")) {
				this.integratedConductivitySolver = parseSolver( navigator.Clone() );
			} else {
				this.usable = false;
			}

			if (conductivitySolver.MinX > integratedConductivitySolver.MinX) {
				this.minX = conductivitySolver.MinX;
			} else {
				this.minX = integratedConductivitySolver.MinX;
			}

			if (conductivitySolver.MaxX < integratedConductivitySolver.MaxX) {
				this.maxX = conductivitySolver.MaxX;
			} else {
				this.maxX = integratedConductivitySolver.MaxX;
			}

			calc();

		}

		public void SetPriceScale(double offset, double scalingFactor) {
			scaledPrice = (price + offset) * scalingFactor;
		}

		/// <summary>
		/// Build a solver for an equation described in an XML file given an XPathNavigator positioned
		/// at the relevant part of the XML file.
		/// </summary>
		/// <param name="navigator">The navigator.</param>
		/// <returns>A solver for the specified equation.</returns>
		private EquationSolver parseSolver(XPathNavigator navigator) {
			List<double> coefficients = new List<double>();
			int minX;
			int maxX;

			navigator.MoveToChild("equationType", "");
			string eqnType = navigator.Value;

			navigator.MoveToNext("minTemp", "");
			minX = navigator.ValueAsInt;

			navigator.MoveToNext("maxTemp", "");
			maxX = navigator.ValueAsInt;

			while (navigator.MoveToNext("coefficient", "")) {
				double coefficient = navigator.ValueAsDouble;
				coefficients.Add(coefficient);
			}

			return EquationSolverFactory.GetSolver(eqnType, coefficients.ToArray(), minX, maxX);
		}

		/// <summary>
		/// Initialize temperature, thermal conductivity, and integrated thermal conductivity values for
		/// the material.  We pre-calcualte everything to avoid doing the calculations multiple times.
		/// </summary>
		private void calc() {
			temperature = new double[ROOM_TEMP - minX + 1];
			for (int i = 0; i < temperature.Length; i++) {
				temperature[i] = i + minX;
			}

			conductivity = new double[ROOM_TEMP - minX + 1];
			for (int i = 0; i < conductivity.Length; i++) {
				conductivity[i] = conductivitySolver.Y(i + minX);
			}

			if (integratedConductivitySolver != null) {
				integratedConductivity = new double[ROOM_TEMP - minX + 1];
				for (int i = 0; i < integratedConductivity.Length; i++) {
					integratedConductivity[i] = integratedConductivitySolver.Y(i + minX);
				}
			}
		}

		/// <summary>
		/// Return an array of temperature (X) values.  Note that these may include values outside the
		/// "valid" range specified by MinX and MaxX.
		/// </summary>
		public double[] Temperature {
			get { return temperature; }
		}

		/// <summary>
		/// Return an array of thermal conductivity values.  Note that these may include values outside the
		/// "valid" range specified by MinX and MaxX.
		/// </summary>
		public double[] ThermalConductivity {
			get { return conductivity; }
		}

		/// <summary>
		/// Return an array of integrated thermal conductivity values.  Note that these may include values outside the
		/// "valid" range specified by MinX and MaxX.
		/// </summary>
		public double[] IntegratedThermalConductivity {
			get { return integratedConductivity; }
		}

		/// <summary>
		/// Provide X values ONLY for the officially valid range, i.e. from
		/// MinX to MaxX inclusive.
		/// </summary>
		public double[] OfficialTemperature {
			get {
				double[] answer = new double[maxX - minX + 1];
				for (int i = 0; i < answer.Length; i++) {
					answer[i] = temperature[i];
				}
				return answer;
			}
		}

		/// <summary>
		/// Provide Y values ONLY for the officially valid range, i.e. from
		/// MinX to MaxX inclusive.
		/// </summary>
		public double[] OfficialThermalConductivity {
			get {
				double[] answer = new double[maxX - minX + 1];
				for (int i = 0; i < answer.Length; i++) {
					answer[i] = conductivity[i];
				}
				return answer;
			}
		}

		/// <summary>
		/// Generate XML to describe the material.
		/// </summary>
		/// <param name="doc"></param>
		/// <returns></returns>
		public XmlElement ToXml(XmlDocument doc, double priceScalingFactor, double priceScalingOffset ) {

			XmlElement materialElem = doc.CreateElement("material");

			XmlElement nameElem = doc.CreateElement("name");
			nameElem.InnerText = name;
			materialElem.AppendChild(nameElem);

			XmlElement idElem = doc.CreateElement("ID");
			idElem.InnerText = id.ToString();
			materialElem.AppendChild(idElem);

			XmlElement yieldStrengthElem = doc.CreateElement("yieldStrength");
			yieldStrengthElem.InnerText = tensileStrength.ToString();
			materialElem.AppendChild(yieldStrengthElem);

			XmlElement priceElem = doc.CreateElement("price");
			// price is in dollars / kg
			// density is in g / cm^3
			double scaledPrice = priceScalingFactor * (price + priceScalingOffset);	// this is in dollars / kg
			double convertedPrice = scaledPrice * 1000 * density;	// this is in dollars / m^3
			priceElem.InnerText = convertedPrice.ToString();
			materialElem.AppendChild(priceElem);

			XmlElement priceUnitElem = doc.CreateElement("priceUnit");
			priceUnitElem.InnerText = "m^3";
			materialElem.AppendChild(priceUnitElem);

			XmlElement currencyUnitElem = doc.CreateElement("currencyUnit");
			currencyUnitElem.InnerText = "$";
			materialElem.AppendChild(currencyUnitElem);

			XmlElement thermalConductivityElem = genDataSet("thermalConductivity", "temp", temperature, "conductivity", conductivity, doc);
			materialElem.AppendChild(thermalConductivityElem);

			if (integratedConductivity != null) {
				XmlElement integratedConductivityElement = genDataSet("integratedThermalConductivity", "temp", temperature, "conductivity", IntegratedThermalConductivity, doc);
				materialElem.AppendChild(integratedConductivityElement);
			}

			return materialElem;
		}

		/// <summary>
		/// The XML format we're generating includes a full set of temperature/value pairs for both thermal
		/// conductivity and integrated thermal conductivity.  This function can generate the XML for both of
		/// these elements.
		/// </summary>
		/// <param name="dataSetName"></param>
		/// <param name="xDataName"></param>
		/// <param name="xData"></param>
		/// <param name="yDataName"></param>
		/// <param name="yData"></param>
		/// <param name="doc"></param>
		/// <returns></returns>
		private XmlElement genDataSet(string dataSetName, string xDataName, double[] xData, string yDataName, double [] yData, XmlDocument doc) {
			XmlElement answer = doc.CreateElement(dataSetName);
			for (int i = 0; i < xData.Length; i++) {
				XmlElement dataPointElem = doc.CreateElement("dataPoint");

				XmlElement xElem = doc.CreateElement(xDataName);
				xElem.InnerText = xData[i].ToString();
				dataPointElem.AppendChild(xElem);

				XmlElement yElem = doc.CreateElement(yDataName);
				yElem.InnerText = yData[i].ToString();
				dataPointElem.AppendChild(yElem);

				answer.AppendChild(dataPointElem);
			}
			return answer;
		
		}

	}


}
