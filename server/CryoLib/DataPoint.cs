using System;
using System.Collections.Generic;
using System.Text;

namespace CryoLib {
	public class DataPoint {
		public double temp;
		public double data;

		public DataPoint() {
			this.temp = 0.0;
			this.data = 0.0;
		}

		public DataPoint(double temp, double data) {
			this.temp = temp;
			this.data = data;
		}
	}
}
