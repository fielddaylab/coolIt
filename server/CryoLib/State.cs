using System;
using System.Collections.Generic;
using System.Text;

namespace CryoLib {
	public class State {
		public double temperature;		// Kelvin (K)
		public int numStruts;
		public double length;			// meters (m)
		public double crossSection;		// square meters (m^2)
		public string materialName;
		public double powerFactor;		// 0 - 1
		public string coolerName;
		public double inputPower;		// Watts (W)
		public double cost;				// U.S. Dollars
		public double stressLimit;		// meganewtons (MN)
        public double cooledLength;     // meters (m)
		public string problemName;
		public bool isValidSolution;
	}
}
