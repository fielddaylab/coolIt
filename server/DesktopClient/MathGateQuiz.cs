using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryoLib;

namespace DesktopClient {
	public partial class MathGateQuiz : Form {

		private BindingSource bindingSource;
		ProblemAndAnswer[] problems;

		public MathGateQuiz( MathGate gate ) {
			InitializeComponent();

			problems = new ProblemAndAnswer[gate.Problems.Length];
			for (int i = 0; i < problems.Length; i++) {
				problems[i] = new ProblemAndAnswer(gate.Problems[i]);
			}

			bindingSource = new BindingSource();
			bindingSource.DataSource = problems;
			navigator.BindingSource = bindingSource;
			descriptionTextBox.DataBindings.Add("Text", bindingSource, "Description");
			precisionTextBox.DataBindings.Add("Text", bindingSource, "PrecisionRequired");
			answerTextBox.DataBindings.Add("Text", bindingSource, "ProposedAnswer");
		}

		public double[] Answers {
			get {
				double[] answers = new double[problems.Length];
				for (int i = 0; i < problems.Length; i++) {
					answers[i] = double.Parse(problems[i].ProposedAnswer);
				}
				return answers;
			}
		}

		private void answerTextBox_TextChanged(object sender, EventArgs e) {
			foreach (ProblemAndAnswer p in problems) {
				if (p.ProposedAnswer == "") {
					submitButton.Enabled = false;
					return;
				}
			}
			submitButton.Enabled = true;
		}

		private void submitButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
		}
	}

	public class ProblemAndAnswer : MathGateProblem {
		private string proposedAnswer;

		public string ProposedAnswer {
			get { return proposedAnswer; }
			set { proposedAnswer = value; }
		}

		public ProblemAndAnswer(MathGateProblem problem) {
			this.Description = problem.Description;
			this.CorrectAnswer = problem.CorrectAnswer;
			this.PrecisionRequired = problem.PrecisionRequired;
			this.proposedAnswer = "";
		}
	}
}