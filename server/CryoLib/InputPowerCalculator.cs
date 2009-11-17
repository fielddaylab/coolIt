using System;
using System.Collections.Generic;
using System.Text;

namespace CryoLib {
	public class InputPowerCalculator {
		private static double[] specificPower;

		public InputPowerCalculator(DataPoint[] data) {
			if (specificPower != null) {
				return;
			}
			
			specificPower = new double[301];	// temperature range 0 - 300 K
			specificPower[0] = -1;				// undefined at 0 K
			specificPower[1] = -1;				// undefined at 1 K

			// Data file includes values for every 2 deg in the range 2 - 300, fill in those values
			foreach (DataPoint point in data) {
				specificPower[(int)point.temp] = point.data;
			}

			// Use averaging to fill in all the odd numbered values
			for (int i = 2; i < 300; i++) {
				if (specificPower[i] == 0.0) {
					specificPower[i] = (specificPower[i - 1] + specificPower[i + 1]) / 2.0;
				}
			}
		}

		public double InputPower(double temperature, double outputPower) {
			if (temperature < 2.0 || temperature > 300.0) {
				return -1.0;
			}
			return specificPower[(int)Math.Round(temperature)] * outputPower;
		}
	}
}
