using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryoLib;

namespace DesktopClient {
	public partial class ChallengePicker : Form {

		private Problem curProblem;
		private PickerImageCollection strutPickerCollection;

		public ChallengePicker( SimulatorStub simulator ) {
			InitializeComponent();
			problemsListBox.Focus();
			Problem[] problems = simulator.GetProblems();
			problemsListBox.Items.Clear();
			for (int i = 0; i < problems.Length; i++) {
				problemsListBox.Items.Add(problems[i]);
			}
            problemsListBox.SelectedIndex = 0;
		}

		public Problem Problem {
			get { return (Problem)problemsListBox.SelectedItem; }
		}

		private void problemsListBox_SelectedIndexChanged(object sender, EventArgs e) {
			Problem p = (Problem)problemsListBox.SelectedItem;
			curProblem = p;
			descriptionTextBox.Text = p.Description;
			if (p.Solved) {
				alreadySolvedLabel.Text = "(already solved)";
			} else {
				alreadySolvedLabel.Text = "";
			}

			introRadioButton.Checked = true;
			radioButton_CheckedChanged(this, EventArgs.Empty);

			showConstraints(p);
            showStruts(p);
            showCoolers(p);

            strutNumberTextBox.Text = p.Struts.Count.ToString();

			monetaryIncentiveLabel.Text = p.MonetaryIncentive.ToString("C");

			strutPickerCollection = curProblem.ImageCollection.PickerImageCollection;
			string label = string.Format("Picker Image[{0},{1}]", strutPickerCollection.Width, strutPickerCollection.Length);
			pickerImageRadioButton.Text = label;
			widthUpDown.Value = 0;
			lengthUpDown.Value = 0;
			widthUpDown.Maximum = strutPickerCollection.Width - 1;
			lengthUpDown.Maximum = strutPickerCollection.Length - 1;
		}

        private void showStruts(Problem p)
        {
            dgStruts.DataSource = p.Struts;
        }

        private void showCoolers(Problem p)
        {
            dgCoolers.DataSource = p.Coolers;
        }

		private void showConstraints(Problem p) {
            loadConstraintsInGridView(constraintGridView, p.Constraints);
		}

        private void loadConstraintsInGridView(DataGridView dg, CryoLib.ConstraintCollection cons)
        {
        	dg.Rows.Clear();
			string[] rowVals = new string[4];
			foreach (CryoLib.Constraint constraint in cons) {
				rowVals[0] = constraint.Value.ToString();
				switch (constraint.Op) {
					case OP.EQ:
						rowVals[1] = "=";
						break;
					case OP.GE:
						rowVals[1] = ">=";
						break;
					case OP.GT:
						rowVals[1] = ">";
						break;
					case OP.LE:
						rowVals[1] = "<=";
						break;
					case OP.LT:
						rowVals[1] = "<";
						break;
					case OP.NE:
						rowVals[1] = "!=";
						break;
					default:
						rowVals[1] = constraint.Op.ToString();
						break;
				}
				rowVals[2] = constraint.Target.ToString();
				switch (constraint.Value) {
					case VALUE.COST:
						rowVals[3] = "Dollars ($)";
						break;
					case VALUE.STRENGTH:
						rowVals[3] = "megaNewtons (MN)";
						break;
					case VALUE.INPUT_POWER:
						rowVals[3] = "Watts (W)";
						break;
					case VALUE.STRUT_CROSS_SECTION:
						rowVals[3] = "meters squared (m^2)";
						break;
					case VALUE.STRUT_LENGTH:
						rowVals[3] = "meters (m)";
						break;
					case VALUE.TEMP:
						rowVals[3] = "Kelvin (K)";
						break;
					default:
						string msg = string.Format("Unexpected constraint value ({0})", constraint.Value);
						throw new Exception(msg);
				}
				dg.Rows.Add( rowVals );
			}
        }

		private void listBox_FocusChanged(object sender, EventArgs e) {
			ListBox box = (ListBox)sender;
			if (box.Focused) {
				box.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
			} else {
				box.BackColor = Color.FromKnownColor(KnownColor.Window);
			}
		}

		private void okButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void ProblemPicker_Shown(object sender, EventArgs e) {
			if (problemsListBox.Items.Count > 0) {
				Problem p = (Problem)problemsListBox.SelectedItem;
				if (p.Solved) {
					alreadySolvedLabel.Text = "(already solved)";
				} else {
					alreadySolvedLabel.Text = "";
				}
			}
		}

		private void radioButton_CheckedChanged(object sender, EventArgs e) {

			string img = curProblem.ImageCollection.Intro;

			if (introRadioButton.Checked) {
				img = curProblem.ImageCollection.Intro;
			} else if (successRadioButton.Checked) {
				img = curProblem.ImageCollection.Success;
			} else if (failPowerLimitRadioButton.Checked) {
				img = curProblem.ImageCollection.FailPowerLimit;
			} else if (failStrutBreaksRadioButton.Checked) {
				img = curProblem.ImageCollection.FailStrutBreaks;
			} else if (failTooHotRadioButton.Checked) {
				img = curProblem.ImageCollection.FailTooHot;
			} else if (pickerImageRadioButton.Checked) {
				img = strutPickerCollection.getImage(0, 0);
			}
			loadImage(img);

		}

		private void loadImage(string img) {
			string url = string.Format("{0}/{1}/{2}.jpg", ServiceAdapter.ImageBaseUrl, curProblem.ImageCollection.BaseURI, img );
			imageViewer.Load(url);
		}

		private void upDown_ValueChanged(object sender, EventArgs e) {
			string img = strutPickerCollection.getImage((int)widthUpDown.Value, (int)lengthUpDown.Value);
			loadImage(img);
		}

        /**
         * Show constraints for a given strut based on what strut is selected
         **/
        private void dgStruts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgStruts.SelectedRows.Count > 0)
            {
                StrutType selectedRow = (StrutType)dgStruts.SelectedRows[0].DataBoundItem;
                loadConstraintsInGridView(this.dgStrutConstraint, selectedRow.Constraints);
            }
        }

        /**
         * Show constraints for a given cooler based on what cooler is selected
         **/
        private void dgCooler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgCoolers.SelectedRows.Count > 0)
            {
                Cooler selectedRow = (Cooler)dgCoolers.SelectedRows[0].DataBoundItem;
                loadConstraintsInGridView(this.dgCoolerConstraint, selectedRow.Constraints);
            }
        }
	}
}