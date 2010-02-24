using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence {
	public class P_StrutState {
		private int id;
        public virtual double CrossSection {get; set; }
        public virtual double Length {get; set;}
        public virtual P_Material Material {get; set;}
        public virtual P_ProblemState ProblemState { get; set; }

		public virtual int Id {
			get { return id; }
			set { id = value; }
		}

        public P_StrutState()
        {
		}

		public P_StrutState(double crossSection, double length,
			P_ProblemState state)
			: this() {
			this.CrossSection = crossSection;
			this.Length = length;
			this.ProblemState = state;
		}

		static public P_StrutState RandomStrutState(P_ProblemState problemState) {
			Random rand = new Random();

			double crossSection = rand.NextDouble();
			double length = rand.NextDouble();
			return new P_StrutState(crossSection, length, problemState);
		}


	}
}
