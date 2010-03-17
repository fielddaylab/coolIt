using System;
using System.Collections.Generic;
using System.Text;
using Iesi.Collections;

namespace Persistence {
	public class P_ProblemState {
		private int id;
		private DateTime timestamp;
		private double powerFactor;
		private double cost;
		private double stressLimit;
		private double temperature;
		private bool isValidSolution;
		private P_Episode episode;
        private Iesi.Collections.ISet strutStates = new HashedSet();
        private Iesi.Collections.ISet coolerStates = new HashedSet();

        public virtual Iesi.Collections.ISet CoolerStates
        {
            get { return coolerStates; }
            set { coolerStates = value; }
        }

        public virtual Iesi.Collections.ISet StrutStates
        {
            get { return strutStates; }
            set { strutStates = value; }
        }

		public virtual int Id {
			get { return id; }
			set { id = value; }
		}

		public virtual DateTime Timestamp {
			get { return timestamp; }
			set { timestamp = value; }
		}

		public virtual double PowerFactor {
			get { return powerFactor; }
			set { powerFactor = value; }
		}

		public virtual double Cost {
			get { return cost; }
			set { cost = value; }
		}

		public virtual double StressLimit {
			get { return stressLimit; }
			set { stressLimit = value; }
		}

		public virtual double Temperature {
			get { return temperature; }
			set { temperature = value; }
		}

		public virtual bool IsValidSolution {
			get { return isValidSolution; }
			set { isValidSolution = value; }
		}

		public virtual P_Episode Episode {
			get { return episode; }
			set { episode = value; }
		}

		public P_ProblemState() {
			timestamp = DateTime.Now;
		}

		public P_ProblemState(double powerFactor, double cost,
			double stressLimit, double temperature, bool isValidSolution)
			: this() {
			this.powerFactor = powerFactor;
			this.cost = cost;
			this.stressLimit = stressLimit;
			this.temperature = temperature;
			this.isValidSolution = isValidSolution;
		}

		static public P_ProblemState RandomState() {
			Random rand = new Random();

			double powerFactor = rand.NextDouble();
			double cost = rand.NextDouble();
			double stressLimit = rand.NextDouble();
			double temperature = rand.NextDouble();
			bool isValidSolution = rand.Next() % 5 == 0;
			return new P_ProblemState(powerFactor, cost, stressLimit, temperature, isValidSolution);
		}

        public virtual void AddStrut(P_StrutState strut)
        {
            strut.ProblemState = this;
            this.StrutStates.Add(strut);
        }

        public virtual void AddCooler(P_CoolerState cooler)
        {
            cooler.ProblemState = this;
            this.CoolerStates.Add(cooler);
        }
	}
}
