using System;
using System.Collections.Generic;
using System.Text;

namespace CryoLib {
	public class SolutionChecker {

		private ProblemCollection problemCollection;

		public SolutionChecker(ProblemCollection problemCollection) {
			this.problemCollection = problemCollection;
		}

		public Feedback GetFeedback(State state, Solution optimalSolution ) {
			Feedback answer = new Feedback();
			Problem problem = problemCollection[state.problemName];

            //TODO:  This is going to need to be updated to handle multiple struts
            //if (state.length < problem.MinStrutLength || state.length > problem.MaxStrutLength) {
            //    answer.Text = "Internal Server Error";
            //    answer.CutScreen = "";
            //}

			// If any constraint is violated, the answer is not valid.  We give feedback based on the
			// "most important" constraint violated.  The importance is coded into the enumeration values for
			// the constraint VALUEs.  Here we order the constraints so we can check the most important ones
			// first.
            List<Constraint> orderedConstraints = problem.Constraints;
			orderedConstraints.Sort(Comparer<Constraint>.Default.Compare);
			
			// Since we already have the constraints in order of importance, we can just give feedback based on 
			// the first violation we find.
			foreach (Constraint constraint in orderedConstraints) {
				if (!checkConstraint(constraint, state)) {
					switch (constraint.Value) {
						case VALUE.FORCE_LIMIT:
							answer.Text = "The strut is not strong enough and breaks.";
							answer.CutScreen = problem.ImageCollection.FailStrutBreaks;
							return answer;
						case VALUE.INPUT_POWER:
							answer.Text = "The cooler requires too much power and your system melts down.";
							answer.CutScreen = problem.ImageCollection.FailPowerLimit;
							return answer;
						case VALUE.TEMP:
							answer.Text = "Your system does not get cold enough to satisfy the requirements.";
							answer.CutScreen = problem.ImageCollection.FailTooHot;
							return answer;
						case VALUE.COST:
							answer.Text = "Your system costs more than allowed by the requirements.";
							answer.CutScreen = "";
							return answer;
						case VALUE.STRUT_CROSS_SECTION:
							answer.Text = "Your support does not meet the cross section requirements.";
							answer.CutScreen = "";
							return answer;
						case VALUE.STRUT_LENGTH:
							answer.Text = "Your support does not meet the length requirements.";
							answer.CutScreen = "";
							return answer;
						default:
							string msg = string.Format("Unexpected constraint value ({0})", constraint.Value);
							throw new Exception(msg);
					}
				}
			}

			// If we get here, the answer is valid.  We need to compare the answer with the optimal to give
			// feedback.
			answer.CutScreen = problem.ImageCollection.Success;
			int percentDiff = (int)Math.Round( (state.cost - optimalSolution.Cost) / optimalSolution.Cost * 100 );
			if (percentDiff <= 5) {
				answer.Text = string.Format(
					"Congratulations. Your solution is valid and costs within {0}% of the optimal solution. Great Job!", percentDiff);
			} else if (percentDiff <= 50) {
				answer.Text = string.Format("Congratulations! Your solution is valid, but costs {0}% more than necessary.", percentDiff );
			} else {
				answer.Text = string.Format("Congratulations, your solution is valid, but costs significantly more than necessary ({0}%).", percentDiff );
			}
			return answer;
		}

		public bool CheckSolution(State state) {
			Problem problem = problemCollection[state.problemName];

            //TODO:  Update this to handle multiple struts
            //if (state.length < problem.MinStrutLength || state.length > problem.MaxStrutLength) {
            //    return false;
            //}

            //TODO:  Update this to handle multiple struts
			foreach (Constraint constraint in problem.Constraints) {
				if (!checkConstraint(constraint, state)) {
					return false;
				}
			}
			return true;
		}

		private bool checkConstraint(Constraint constraint, State state) {
			double valueToCheck;
			switch (constraint.Value) {
				case VALUE.COST:
					valueToCheck = state.cost;
					break;
				case VALUE.FORCE_LIMIT:
					valueToCheck = state.stressLimit;
					break;
				case VALUE.INPUT_POWER:
					valueToCheck = state.inputPower;
					break;
				case VALUE.TEMP:
					valueToCheck = state.temperature;
					break;
				case VALUE.STRUT_LENGTH:
					valueToCheck = state.length;
					break;
				case VALUE.STRUT_CROSS_SECTION:
					valueToCheck = state.crossSection;
					break;
				default:
					throw new Exception("Unknown VALUE type in constraint");
			}
			if (valueToCheck < 0) {
				return false;
			}
			return constraint.CheckValue(valueToCheck);
		}
	}

	public class Feedback {
		private string text;
		private string cutScreen;

		public Feedback(string text, string cutScreen) {
			this.text = text;
			this.cutScreen = cutScreen;
		}

		public Feedback() { }

		public string Text {
			get { return text; }
			set { text = value; }
		}

		public string CutScreen {
			get { return cutScreen; }
			set { cutScreen = value; }
		}

	}
}
