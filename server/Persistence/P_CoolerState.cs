using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence {
	public class P_CoolerState {
		private int id;
        public virtual double InputPower {get; set; }
        public virtual double PowerFactor { get; set; }
        public virtual P_Cooler Cooler {get; set;}
        public virtual P_ProblemState ProblemState { get; set; }

		public virtual int Id {
			get { return id; }
			set { id = value; }
		}

        public P_CoolerState()
        {
		}

		public P_CoolerState(double inputPower, double powerFactor,
			P_ProblemState state)
			: this() {
			this.InputPower = inputPower;
            this.PowerFactor = powerFactor;
			this.ProblemState = state;
		}

		static public P_CoolerState RandomStrutState(P_ProblemState problemState) {
			Random rand = new Random();

			double inputPower = rand.NextDouble();
            double powerFactor = rand.NextDouble();
            return new P_CoolerState(inputPower, powerFactor, problemState);
		}


	}
}