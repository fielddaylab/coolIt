using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryoLib;

namespace DesktopClient {
	public partial class StrutPicker : Form {
		public event EventHandler RaiseStrutChangedEvent;
		private double maxStrutLength = 1.0;
		private double minStrutLength = 0.01;
		private double minCrossSection = 0.001;
		private double maxCrossSection = 0.1;
		const int TRACKBAR_RANGE = 1000;
		

		public StrutPicker( SimulatorStub simulator ) {
			InitializeComponent();

			Material[] materials = simulator.GetMaterials();
			materialsListBox.Items.Clear();
			for (int i = 0; i < materials.Length; i++) {
				materialsListBox.Items.Add(materials[i]);
			}
			materialsListBox.SelectedIndex = 0;

			adjustTrackbar(lengthTrackBar, minStrutLength, maxStrutLength);
			lengthTrackBar.Value = (int)((maxStrutLength - minStrutLength) / 2 * TRACKBAR_RANGE);
			lengthTrackBar.TickFrequency = TRACKBAR_RANGE / 10;

			adjustTrackbar(crossSectionTrackBar, minCrossSection, maxCrossSection);
			crossSectionTrackBar.Value = (int)((maxCrossSection - minCrossSection) / 2 * TRACKBAR_RANGE);
			crossSectionTrackBar.TickFrequency = TRACKBAR_RANGE / 10;

			updatePrice();

			this.FormClosing += new FormClosingEventHandler(StrutPicker_FormClosing);
		}

		public double MinStrutLength {
			get { return minStrutLength; }
			set {
				minStrutLength = value;
				adjustTrackbar(lengthTrackBar, minStrutLength, maxStrutLength);
			}
		}

		public double MaxStrutLength {
			get { return maxStrutLength; }
			set {
				maxStrutLength = value;
				adjustTrackbar(lengthTrackBar, minStrutLength, maxStrutLength);
			}
		}

		public double MinStrutCrossSection {
			get { return minCrossSection; }
			set {
				minCrossSection = value;
				adjustTrackbar(crossSectionTrackBar, minCrossSection, maxCrossSection);
			}
		}

		public double MaxStrutCrossSection {
			get { return maxCrossSection; }
			set {
				maxCrossSection = value;
				adjustTrackbar(crossSectionTrackBar, minCrossSection, maxCrossSection);
			}
		}

		private void adjustTrackbar(TrackBar trackBar, double min, double max) {
			trackBar.Minimum = 0;
			trackBar.Maximum = TRACKBAR_RANGE;
		}


		void StrutPicker_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
			Hide();
		}

		public Strut Strut {
			get {
				return new Strut(getLength(), getCrossSection(), (Material)materialsListBox.SelectedItem);
			}
		}

		private double getLength() {
			return Double.Parse(lengthTextBox.Text) / 100D;			// convert from cm to m
		}

		private double getCrossSection() {
			return Double.Parse(crossSectionTextBox.Text) / 10000D;	// convert from cm^2 to m^2
		}

		protected virtual void OnRaiseStrutChangedEvent(EventArgs e) {
			EventHandler handler = RaiseStrutChangedEvent;

			if (handler != null) {
				handler(this, e);
			}
		}

		private void lengthTrackBar_ValueChanged(object sender, EventArgs e) {
			double adjValue = (double)lengthTrackBar.Value / TRACKBAR_RANGE * (maxStrutLength - minStrutLength) + minStrutLength;
			lengthTextBox.Text = (adjValue * 100).ToString(); // convert from m to cm
		}

		private void crossSectionTrackBar_ValueChanged(object sender, EventArgs e) {
			double adjValue = (double)crossSectionTrackBar.Value / TRACKBAR_RANGE * (maxCrossSection - minCrossSection) + minCrossSection;
			crossSectionTextBox.Text = (adjValue * 10000).ToString();	// convert from m^2 to cm^2
		}

		private void plotMaterial() {
			Material material = (Material)materialsListBox.SelectedItem;

			double[] x = new double[material.MP.Count];
			double[] y = new double[material.MP.Count];
			for (int i = 0; i < material.MP.Count; i++) {
				x[i] = material.MP[i].temp;
				y[i] = material.MP[i].data;
			}

			materialVisualizer.XAxisLabel = "Temp (Deg K)";
			materialVisualizer.YAxisLabel = "Thermal Conductivity (W/mK)";
			materialVisualizer.PlotLabel = material.Name;
			materialVisualizer.XData = x;
			materialVisualizer.YData = y;
			materialVisualizer.Redraw();

		}

		private void lengthTextBox_TextChanged(object sender, EventArgs e) {
			updatePrice();
			OnRaiseStrutChangedEvent(new EventArgs());
		}

		private void crossSectionTextBox_TextChanged(object sender, EventArgs e) {
			updatePrice();
			updateStressLimit();
			OnRaiseStrutChangedEvent(new EventArgs());
		}

		private void materialsListBox_SelectedIndexChanged(object sender, EventArgs e) {
			OnRaiseStrutChangedEvent(new EventArgs());
			plotMaterial();
			updateStressLimit();
			updatePrice();
		}

		private void updatePrice() {
			Material material = (Material)materialsListBox.SelectedItem;

			// material.price is in $ / m^3, but we want $ / cm^3
			double ccPrice = material.price / 1000000;
			costPerUnitTextBox.Text = ccPrice.ToString("C");

			double strutPrice = material.price * getLength() * getCrossSection();
			priceTextBox.Text = strutPrice.ToString("C");
		}

		private void updateStressLimit() {
			Material material = (Material)materialsListBox.SelectedItem;
			if (material.yieldStrength >= 0.0) {
				yieldStrengthTextBox.Text = material.yieldStrength.ToString();
				double stressLimit = material.yieldStrength * getCrossSection(); // Unit is megaNewton (MN)
				stressLimitTextBox.Text = stressLimit.ToString();
			} else {
				yieldStrengthTextBox.Text = "(unknown)";
				stressLimitTextBox.Text = "(unknown)";
			}
		}


	}
}