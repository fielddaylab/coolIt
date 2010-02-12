using System;
using System.Collections.Generic;
using System.Text;

namespace CryoLib {
	public class Optimizer {
		private CoolerTypeCollection coolers;
		private MaterialsCollection materials;
		public static SteadyStateSimulator steadyStateSim;

		static Optimizer() {
			steadyStateSim = new SteadyStateSimulator();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="coolers">The collection of available coolers</param>
		/// <param name="materials">The collection of available materials</param>
		public Optimizer( CoolerTypeCollection coolers, MaterialsCollection materials ) {
			this.coolers = coolers;
			this.materials = materials;
		}

		/// <summary>
		/// Calculate and return the optimal solution to the given problem.
		/// </summary>
		/// <param name="problem">The problem whose optimal solution we seek</param>
		/// <returns>The optimal solution</returns>
		public Solution OptimalSoultion(Problem problem) {

			// Figure out our temperature and strength requirements
			double targetTemp = 0.0;
			double strengthReq = 0.0;
			foreach( Constraint constraint in problem.Constraints ) {
				switch( constraint.Value ) {
					case VALUE.TEMP:
						targetTemp = constraint.Target;
						break;
					case VALUE.FORCE_LIMIT:
						strengthReq = constraint.Target;
						break;
				}
			}

			// Enumerate solutions for every combination of material and cooler
			List<CandidateSolution> candidates = new List<CandidateSolution>();
			foreach( Material m in materials ) {
				foreach( CoolerType c in coolers ) {
					CandidateSolution cs = new CandidateSolution(m, c, targetTemp, strengthReq, problem);
					if (cs.IsFeasible) {
						candidates.Add(cs);
					}
				}
			}

			// Find the best solution
			double solutionCost = Double.MaxValue;
			CandidateSolution optimalSolution = null;
			foreach( CandidateSolution c in candidates ) {
				if( c.SolutionCost < solutionCost ) {
					optimalSolution = c;
					solutionCost = c.SolutionCost;
				}
			}

			Solution answer = null;

			if (candidates.Count == 0) {
				return null;
			} else {
				answer = new Solution(
					problem.Name,
					optimalSolution.Cooler.Name,
					optimalSolution.CoolerPowerFactor,
					optimalSolution.Material.Name,
					optimalSolution.StrutCrossSection,
					optimalSolution.StrutLength,
					optimalSolution.SolutionCost
				);
			}
			return answer;
		}

		private class CandidateSolution {
			private Material material;
			private CoolerType cooler;
			private bool feasible;
			private double solutionCost;
			private double strutLength;
			private double strutCrossSection;
			private double coolerPowerFactor;


			public Material Material {
				get { return material; }
			}

			public CoolerType Cooler {
				get { return cooler; }
			}

			public double CoolerPowerFactor {
				get { return coolerPowerFactor; }
			}

			public bool IsFeasible {
				get { return feasible; }
			}

			public double SolutionCost {
				get {
					if (feasible) {
						return solutionCost;
					} else {
						return Double.MaxValue;
					}
				}
			}

			public double StrutLength {
				get {
					if (feasible) {
						return strutLength;
					} else {
						return Double.MaxValue;
					}
				}
			}

			public double StrutCrossSection {
				get {
					if (feasible) {
						return strutCrossSection;
					} else {
						return Double.MaxValue;
					}
				}
			}

			public CandidateSolution(Material m, CoolerType c, double targetTemp, double strengthRequirement, Problem problem ) {
				material = m;
				cooler = c;

				// If yieldStrength < 0, that means the value is unknown.  We cannot use materials without knowing
				// their yieldStrength, so solutions with this material are not feasible.
				if (m.yieldStrength < 0.0) {
					feasible = false;
					return;
				}

				// The lowest temp for which we have thermal conductivity data for a particular material sets an effective
				// lower bound on target temp.  We cannot use materials in a situation where they will be outside the
				// temperature range where we know this property.
				double minThermalData = m.MP[0].temp;
				if ( targetTemp <= minThermalData ) {
					feasible = false;
					return;
				}

				// The strut(s) must be strong enough to support the load.  Figure out what the minimum cross section
				// is.  This is the cross section for each strut.
                //TODO:  Fix this to include support number as it should now that it is moved to a strut property
                //strutCrossSection = strengthRequirement / m.yieldStrength / problem.SupportNumber;
                strutCrossSection = strengthRequirement / m.yieldStrength;
				strutCrossSection *= 1.00001;	// add tiny bit to avoid precision problems when comparing later
                //TODO:  Fix this to include support number as it should now that it is moved to a strut property
                //double calcStrength = m.yieldStrength * strutCrossSection * problem.SupportNumber;
                double calcStrength = m.yieldStrength * strutCrossSection;
				if (calcStrength < strengthRequirement) {
					throw new Exception("We have a math precision problem here");
				}

				// If the material is not strong enough to support the load given the maximum cross section
				// specified in the problem, it's not feasible
				if (strutCrossSection > problem.MaxStrutCrossSection) {
					feasible = false;
					return;
				}

				// If the material is so strong that a cross section less than the minimum specified can support the
				// load, we have to adjust the cross section to the minimum specified.
				if (strutCrossSection < problem.MinStrutCrossSection) {
					strutCrossSection = problem.MinStrutCrossSection;
				}

				// Need to determine the maximum power factor which will result in an input power that meets
				// the problem constraints.  We will always use the maximum power factor which does not violate
				// our input power constraint as we are only optimizing our cost to build (not operating costs).
				coolerPowerFactor = c.maxPowerFactor(problem.InputPowerLimit, targetTemp);
				double actualInputPower = c.InputPower(targetTemp, coolerPowerFactor);
				if (actualInputPower > problem.InputPowerLimit) {
					throw new Exception("Error in maxPowerFactor calculation");
				}


				// Given the cooler, material, cross section, target temperature, and power factor, we can calculate the
				// minimum strut length which will allow us to reach that temperature.
                //TODO:  Fix this to handle support number coming from list of struts
                //strutLength = Optimizer.steadyStateSim.strutLength(targetTemp, strutCrossSection * problem.SupportNumber, m, c, coolerPowerFactor);
                strutLength = Optimizer.steadyStateSim.strutLength(targetTemp, strutCrossSection * 1, m, c, coolerPowerFactor);

				// If the Matlab code cannot come up with a minimum strut length, the mateial is not feasible
				// given the other parameters.
				if( double.IsNaN(strutLength) ) {
					feasible = false;
					return;
				}

				// If reaching the target temperature requires a longer strut than the maximum length specified,
				// the material is not feasible.
				if (strutLength > problem.MaxStrutLength ) {
					feasible = false;
					return;
				}

				// If we can reach the target temperature with a strut shorter than the minimum, we still have to
				// use a strut that meets the minimum length requirement.
				if ( strutLength < problem.MinStrutLength) {
					strutLength = problem.MinStrutLength;
					// Now that we have adjusted the strutLength to be longer, we'll reach a colder temperature.
					// It could be that we are now below the min temp for which we have data on our strut material.
					double steadyStateTemp;
					try {
                        //TODO:  Fix this to use support number
                        //steadyStateTemp = Optimizer.steadyStateSim.simulate(strutLength, strutCrossSection * problem.SupportNumber, material, cooler, coolerPowerFactor );
                        steadyStateTemp = Optimizer.steadyStateSim.simulate(strutLength, strutCrossSection * 1, material, cooler, coolerPowerFactor);
					} catch (ArgumentException) {
						steadyStateTemp = -1;
					}

					if ( steadyStateTemp < minThermalData ) {
						// Here we reduce the power factor enough to get the temperature back in range.
						coolerPowerFactor = MaxPowerFactor(0.0, coolerPowerFactor, minThermalData, problem);
					}
				}
				
				// OK, we have a feasible solution - figure out what it's going to cost.
				feasible = true;
                //TODO:  Fix this to use support number
                //double strutVolume = strutCrossSection * strutLength * problem.SupportNumber;
                double strutVolume = strutCrossSection * strutLength * 1;
				double strutCost = m.price * strutVolume;
				solutionCost = c.price + strutCost;
			}

			private double MaxPowerFactor(double min, double max, double minThermalData, Problem problem) {
				double avg = (min + max) / 2.0;
				double steadyStateTemp;
				try {
                    //TODO:  Fix this to use support number
                    //steadyStateTemp = Optimizer.steadyStateSim.simulate(strutLength, strutCrossSection * problem.SupportNumber, material, cooler, avg);
                    steadyStateTemp = Optimizer.steadyStateSim.simulate(strutLength, strutCrossSection * 1, material, cooler, avg);
				} catch (ArgumentException) {
					steadyStateTemp = -1;
				}
				if (steadyStateTemp < minThermalData) {
					// Too cold - try a lower power factor
					return MaxPowerFactor(min, avg, minThermalData, problem);
				} else if (steadyStateTemp > problem.TargetTemperature) {
					// Too hot - try a larger power factor
					return MaxPowerFactor(avg, max, minThermalData, problem);
				} else {
					// Just right - use this power factor
					return avg;
				}

			}
		}



		/// <summary>
		/// Return a string with some advice on how to improve the proposed solution.  N.B. the
		/// proposed solution is assumed to be valid.
		/// </summary>
		/// <param name="challenge">The challenge on which we are giving advice</param>
		/// <param name="proposedSolution">The proposed solution on which we are giving advice</param>
		/// <returns>Some advice on how to improve the proposed solution</returns>
		public String GetOptimizationAdvice(Problem challenge, Solution proposedSolution) {

			if (!isValidSolution(challenge, proposedSolution)) {
				throw new Exception("The proposed solution was not valid");
			}

			Solution optimalSolution = OptimalSoultion(challenge);
			return "How the heck would I know?";

			//if (proposedSolution.Material != optimalSolution.Material) {
			//    return "Pick a better material - remember low thermal conductivity is good, " +
			//        "but higher yield strength will allow you to reduce cross sectional area and " +
			//        "thereby reduce the heat load.  Choose a material with a good balance between these two factors.";
			//        // Do we want to say anything about the cost of the materials here???
			//} else if (proposedSolution.StrutLength < optimalSolution.StrutLength) {
			//    return "Make your strut longer - always make your strut as long as physical constraints " +
			//        "allow as this will reduce your heat load.";
			//        // Making the strut longer does increase its cost, but that's generally not important. 
			//        // should we discuss that here???
			//} else if (proposedSolution.StrutCrossSection > optimalSolution.StrutCrossSection) {
			//    return "Reduce your strut's cross section - always make your cross sectional area as small " +
			//        "as possible consistent with adequate strength to support your payload.  This will " +
			//        "reduce your heat load.";
			//        // Reducing the strut's cross section also makes it cheaper, but that isn't usually important.
			//        // Should we discuss that here???
			//} else if (proposedSolution.Cooler != optimalSolution.Cooler) {
			//    return "Pick a smaller cooler - always choose the smallest cooler which will allow you to reach " +
			//        "your temperature goal.  Smaller coolers are cheaper.";
			//} else if (proposedSolution.CoolerPowerFactor > optimalSolution.CoolerPowerFactor) {
			//    return "Reduce your cooler's power factor - always reduce your cooler's power factor as much as " +
			//        "possible consistent with meeting your temperature goal.  This will reduce your input power " +
			//        "and thereby reduce your operating costs.";
			//        // Not all challenges have low input power as a goal, but you could "tweak" this factor anyway.
			//        // Should we suggest that, or just say that the solution is already optimal if input power is not
			//        // part of the challenge statement???
			//} else {
			//    return "Your proposed solution already is optimal!";
			//}
		}

		public string GetCorrectionAdvice(Problem problem, Solution proposedSolution) {
			// How does this code differ from the above code which assumes that the proposed solution
			// is correct???
			return "";
		}

		private bool isValidSolution(Problem problem, Solution proposedSolution) {
			// Actual solution checking code needs to be inserted here...
			return true;
		}
	}

	/// <summary>
	/// Definition of a "soulution" to a Level 1 challenge.  Note that what we're really defining here
	/// is a proposed soultion, i.e. soultions may or may not be valid.
	/// </summary>
	public class Solution {
		public string ProblemName;
		public string CoolerName;
		public double CoolerPowerFactor;
		public string MaterialName;
		public double StrutCrossSection;
		public double StrutLength;
		public double Cost;

		public Solution() {}

		public Solution(string problemName, string coolerName, double powerFactor, string materialName, double strutCrossSection, double strutLength, double cost) {
			this.ProblemName = problemName;
			this.CoolerName = coolerName;
			this.CoolerPowerFactor = powerFactor;
			this.MaterialName = materialName;
			this.StrutCrossSection = strutCrossSection;
			this.StrutLength = strutLength;
			this.Cost = cost;
		}
	}
}
