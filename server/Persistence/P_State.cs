using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence {
	public class P_State {
		private int id;
		private DateTime timestamp;
		private P_Cooler cooler;
		private P_Material material;
		private double length;
		private double crossSection;
		private double powerFactor;
		private double inputPower;
		private double cost;
		private double stressLimit;
		private double temperature;
        private double cooledLength;

        public virtual double CooledLength
        {
            get { return cooledLength; }
            set { cooledLength = value; }
        }
		private bool isValidSolution;
		private P_Episode episode;

		public virtual int Id {
			get { return id; }
			set { id = value; }
		}

		public virtual DateTime Timestamp {
			get { return timestamp; }
			set { timestamp = value; }
		}

		public virtual P_Material Material {
			get { return material; }
			set { material = value; }
		}

		public virtual P_Cooler Cooler {
			get { return cooler; }
			set { cooler = value; }
		}

		public virtual double Length {
			get { return length; }
			set { length = value; }
		}

		public virtual double CrossSection {
			get { return crossSection; }
			set { crossSection = value; }
		}

		public virtual double PowerFactor {
			get { return powerFactor; }
			set { powerFactor = value; }
		}

		public virtual double InputPower {
			get { return inputPower; }
			set { inputPower = value; }
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

		public P_State() {
			timestamp = DateTime.Now;
		}

		public P_State(double length, double crossSection, double powerFactor, double inputPower, double cost,
			double stressLimit, double temperature, double cooledLength, bool isValidSolution)
			: this() {
			this.length = length;
			this.crossSection = crossSection;
			this.powerFactor = powerFactor;
			this.inputPower = inputPower;
			this.cost = cost;
			this.stressLimit = stressLimit;
			this.temperature = temperature;
            this.cooledLength = cooledLength;
			this.isValidSolution = isValidSolution;
		}

		static public P_State RandomState() {
			Random rand = new Random();

			double length = rand.NextDouble();
			double crossSection = rand.NextDouble();
			double powerFactor = rand.NextDouble();
			double inputPower = rand.NextDouble();
			double cost = rand.NextDouble();
			double stressLimit = rand.NextDouble();
			double temperature = rand.NextDouble();
            double cooledLength = length;
			bool isValidSolution = rand.Next() % 5 == 0;
			return new P_State(length, crossSection, powerFactor, inputPower, cost, stressLimit, temperature, cooledLength, isValidSolution);
		}


	}
}
