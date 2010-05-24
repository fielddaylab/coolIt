using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryoLib;
using System.IO;

namespace Version_02_App {
	public partial class MainForm : Form {
		SteadyStateSimulator steadyStateSim = new SteadyStateSimulator();

		public MainForm() {
			InitializeComponent();

			// Read in data on the materials
			string materialFileName = Path.Combine(Resources.DataDir, "Materials.xml");
			string materialSchema = Path.Combine(Resources.SchemaDir, "Materials.xsd");
			MaterialsCollection materials = new MaterialsCollection(materialFileName, materialSchema);
			for( int i=0; i<materials.Count; i++ ) {
				materialsListBox.Items.Add( materials[i] );
			}
			materialsListBox.SelectedIndex = 0;

			// Read in data on the coolers
			string coolerFileName = Path.Combine(Resources.DataDir, "Coolers.xml");
			string coolerSchema = Path.Combine(Resources.SchemaDir, "Coolers.xsd");
			CoolerModelCollection coolers = new CoolerModelCollection(coolerFileName, coolerSchema );
			for (int i = 0; i < coolers.Count; i++) {
				coolersListBox.Items.Add(coolers[i]);
			}
			coolersListBox.SelectedIndex = 0;

			// Ready to go - enable user to pull the trigger
			simulateButton.Enabled = true;
		}

		/// <summary>
		/// Figure out what kind of strut the user has selected and
		/// return it.
		/// </summary>
		/// <returns>The selected strut</returns>
		private StrutType getStrut() {
			double length, crossSection;

			try {
				length = double.Parse(lengthTextBox.Text);
				if (length < 0.0) {
					throw new ArgumentException("Length must be greater than zero");
				}
			} catch (Exception e) {
				throw new ArgumentException("Invalid strut length", e);
			}

			try {
				crossSection = double.Parse(crossSectionTextBox.Text);
				if (crossSection < 0.0) {
					throw new ArgumentException("Cross section must be greater than zero");
				}
			} catch (Exception e) {
				throw new ArgumentException("Invalid strut cross section", e);
			}

			return new StrutType( length, crossSection, (Material)materialsListBox.SelectedItem );
		}

		/// <summary>
		/// Figure out what kind of cooler the user has selected and return it
		/// </summary>
		/// <returns>The selected cooler</returns>
		private CoolerModel getCooler() {
			return (CoolerModel)coolersListBox.SelectedItem;
		}

		/// <summary>
		/// Simulate the steady-state problem with the given strut
		/// and cooler.  Output the results.
		/// </summary>
		/// <param name="strut"></param>
		/// <param name="cooler"></param>
		private void simulate( StrutType strut, CoolerModel cooler ) {
			Cursor savedCursor = this.Cursor;
			try {
				this.Cursor = Cursors.WaitCursor;

				this.Refresh();


				double temp = steadyStateSim.simulate(strut.Length, strut.CrossSectionalArea, strut.Material, cooler);

				answerBox.Text = temp.ToString();
			} finally {
				this.Cursor = savedCursor;
			}
		}

		/// <summary>
		/// Run a new simulation whenever the user clicks this button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void simulateButton_Click(object sender, EventArgs e) {
			StrutType strut;
			CoolerModel cooler;
			answerBox.Text = "";
			try {
				strut = getStrut();
				cooler = getCooler();
			} catch (ArgumentException ae) {
				MessageBox.Show(ae.ToString());
				return;
			}
			simulate( strut, cooler );
		}

		private void materialsListBox_SelectedIndexChanged(object sender, EventArgs e) {
			materialDataBox.Text = ((Material)materialsListBox.SelectedItem).Describe();
			answerBox.Text = "";
		}

		private void coolersListBox_SelectedIndexChanged(object sender, EventArgs e) {
			coolerDataBox.Text = ((CoolerModel)coolersListBox.SelectedItem).Describe();
			answerBox.Text = "";
		}

		private void lengthTextBox_TextChanged(object sender, EventArgs e) {
			answerBox.Text = "";
		}

		private void crossSectionTextBox_TextChanged(object sender, EventArgs e) {
			answerBox.Text = "";
		}


	}
}