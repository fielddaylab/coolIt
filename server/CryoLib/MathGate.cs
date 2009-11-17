using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace CryoLib {
	public class MathGate {
		private string name;
		private int id;
		private MathGateProblem [] problems;
		private CAPABILITY capability;

		public String Name {
			get { return name; }
			set { name = value; }
		}

		public int ID {
			get { return id; }
			set { id = value; }
		}

		public MathGateProblem[] Problems {
			get { return problems; }
			set { problems = value; }
		}

		public CAPABILITY Capability {
			get { return capability; }
			set { capability = value; }
		}

		public MathGate(string name, int id, MathGateProblem[] problems, CAPABILITY capability) {
			this.name = name;
			this.id = id;
			this.problems = problems;
			this.capability = capability;
		}

		public MathGate(XPathNavigator navigator) {
			List<MathGateProblem> problemList = new List<MathGateProblem>();
			navigator.MoveToChild("Name", "");
			this.name = navigator.Value;

			navigator.MoveToNext("ID", "");
			this.id = navigator.ValueAsInt;

			navigator.MoveToNext();
			do {
				MathGateProblem p = new MathGateProblem(navigator.Clone());
				problemList.Add(p);
			} while (navigator.MoveToNext("Problem", ""));
			problems = problemList.ToArray();

			navigator.MoveToNext();
			switch (navigator.Value) {
				case "CP_VS_HEAT_LEAK_GRAPH":
					capability = CAPABILITY.CP_VS_HEAT_LEAK_GRAPH;
					break;
				default:
					string msg = string.Format("Unexpected capability \"{0}\"", navigator.Value);
					throw new Exception( msg );
			}
		}

		/// <summary>
		/// Determine whether the given list of values represent valid solutions to the problems
		/// in the gate.
		/// </summary>
		/// <param name="values">List of proposed answers</param>
		/// <returns>True if all the answers are valid and false otherwise</returns>
		public bool IsSolution(double[] values) {
			if (values.Length != problems.Length) {
				return false;
			}
			for (int i = 0; i < values.Length; i++) {
				if( !problems[i].IsSolution(values[i]) ) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// No-argument (default) constructor.
		/// </summary>
		public MathGate() {
		}

	}

	public class MathGateProblem {
		private string problemDescription;
		private double correctAnswer;
		private double precisionRequired;

		[XmlElement]
		public string Description {
			get { return problemDescription; }
			set { problemDescription = value; }
		}

		[XmlElement]
		public double CorrectAnswer {
			get { return correctAnswer; }
			set { correctAnswer = value; }
		}

		[XmlElement]
		public double PrecisionRequired {
			get { return precisionRequired; }
			set { precisionRequired = value; }
		}

		public MathGateProblem(string problemDescription, double correctAnswer, double precisionRequired) {
			this.problemDescription = problemDescription;
			this.correctAnswer = correctAnswer;
			this.precisionRequired = precisionRequired;
		}

		public MathGateProblem(XPathNavigator navigator) {
			navigator.MoveToChild("ProblemDescription", "");
			problemDescription = navigator.Value;

			navigator.MoveToNext();
			correctAnswer = navigator.ValueAsDouble;

			navigator.MoveToNext();
			precisionRequired = navigator.ValueAsDouble;

		}

		/// <summary>
		/// Determine whether the given value is a solution to the problem.
		/// </summary>
		/// <param name="value">The proposed answer</param>
		/// <returns>True if the answer is valid and false otherwise</returns>
		public bool IsSolution(double value) {
			return correctAnswer - precisionRequired <= value && correctAnswer + precisionRequired >= value;
		}

		/// <summary>
		/// No-argument (default) constructor.
		/// </summary>
		public MathGateProblem() {
		}
	}

	public enum CAPABILITY {
		CP_VS_HEAT_LEAK_GRAPH,
	}
}
