using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryoLib;

namespace DesktopClient {
	public partial class CoolerPicker : Form {

		private PlotType plotType = PlotType.OUTPUT_POWER;

		public event EventHandler RaiseCoolerChangedEvent;
		const int TRACKBAR_PRECISION = 1000;

		public CoolerPicker( SimulatorStub simulator ) {
			InitializeComponent();

			Cooler[] coolers = simulator.GetCoolers();
			coolersListBox.Items.Clear();
			for (int i = 0; i < coolers.Length; i++) {
				coolersListBox.Items.Add(coolers[i]);
			}
			coolersListBox.SelectedIndex = 0;

			powerFactorTrackBar.Minimum = 1;
			powerFactorTrackBar.Maximum = TRACKBAR_PRECISION;
			powerFactorTrackBar.Value = TRACKBAR_PRECISION;
			powerFactorTrackBar.TickFrequency = TRACKBAR_PRECISION / 10;

			this.FormClosing += new FormClosingEventHandler(CoolerPicker_FormClosing);
		}

		void CoolerPicker_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
			Hide();
		}

		public Cooler Cooler {
			get { return (Cooler)coolersListBox.SelectedItem; }
		}

		public double PowerFactor {
			get { return getPowerFactor(); }
		}

		public double Price {
			get {
				Cooler cooler = (Cooler)coolersListBox.SelectedItem;
				return (double)cooler.price;
			}
		}

		protected virtual void OnRaiseCoolerChangedEvent(EventArgs e) {
			EventHandler handler = RaiseCoolerChangedEvent;

			if (handler != null) {
				handler(this, e);
			}
		}

		private void powerFactorTrackBar_ValueChanged(object sender, EventArgs e) {
			powerFactorTextBox.Text = (powerFactorTrackBar.Value / (double)TRACKBAR_PRECISION).ToString();
		}

		private double getPowerFactor() {
			return double.Parse(powerFactorTextBox.Text);
		}

		private void plotCooler() {
			if (plotType == PlotType.INPUT_POWER) {
				plotInputPower();
			} else {
				plotOutputPower();
			}
		}

		//private void plotOutputPower() {
		//    Cooler cooler = (Cooler)coolersListBox.SelectedItem;
		//    if (cooler == null) {
		//        return;
		//    }

		//    double powerFactor = getPowerFactor();
		//    double yMax = 0.0;

		//    double[] x = new double[cooler.CPM.Count];
		//    double[] y = new double[cooler.CPM.Count];
		//    for (int i = 0; i < cooler.CPM.Count; i++) {
		//        if (cooler.CPM[i].data > yMax) {
		//            yMax = cooler.CPM[i].data;
		//        }
		//        x[i] = 300.0 - (300.0 - cooler.CPM[i].temp) * powerFactor;
		//        y[i] = cooler.CPM[i].data * powerFactor;
		//    }

		//    coolerVisualizer.XAxisLabel = "Temp (Deg K)";
		//    coolerVisualizer.YAxisLabel = "Output Cooling Power";
		//    coolerVisualizer.PlotLabel = cooler.Name;
		//    coolerVisualizer.XData = x;
		//    coolerVisualizer.YData = y;
		//    coolerVisualizer.Y_Max = yMax;

		//    coolerVisualizer.Redraw();
		//}

		private void plotOutputPower() {
			Cooler cooler = (Cooler)coolersListBox.SelectedItem;
			if (cooler == null) {
				return;
			}

			double powerFactor = getPowerFactor();
			double yMax = 0.0;

			double[] x = new double[301];
			double[] y = new double[301];

			for (int i = 0; i <= 300; i++) {
				x[i] = (double)i;
				y[i] = cooler.OutputPower(x[i], powerFactor);
				if (y[i] < 0.0) {
					y[i] = 0.0;
				}
				if (y[i] > yMax) {
					yMax = y[i];
				}
			}

			coolerVisualizer.XAxisLabel = "Temp (Deg K)";
			coolerVisualizer.YAxisLabel = "Cooling Power (Watts)";
			coolerVisualizer.PlotLabel = cooler.Name;
			coolerVisualizer.XData = x;
			coolerVisualizer.YData = y;
			coolerVisualizer.Y_Max = cooler.MaxOutputPower;

			coolerVisualizer.Redraw();
		}

		private void plotInputPower() {
			Cooler cooler = (Cooler)coolersListBox.SelectedItem;
			if (cooler == null) {
				return;
			}

			double powerFactor = getPowerFactor();
			double yMax = 0.0;

			double[] x = new double[301];
			double[] y = new double[301];

			for (int i = 0; i <= 300; i++) {
				x[i] = (double)i;
				y[i] = cooler.InputPower(x[i], powerFactor);
				if (y[i] < 0.0) {
					y[i] = 0.0;
				}
				if (y[i] > yMax) {
					yMax = y[i];
				}
			}

			coolerVisualizer.XAxisLabel = "Temp (Deg K)";
			coolerVisualizer.YAxisLabel = "Input Power (Watts)";
			coolerVisualizer.PlotLabel = cooler.Name;
			coolerVisualizer.XData = x;
			coolerVisualizer.YData = y;
			coolerVisualizer.Y_Max = cooler.MaxInputPower;

			coolerVisualizer.Redraw();
		}


		private void powerFactorTextBox_TextChanged(object sender, EventArgs e) {
			plotCooler();
			OnRaiseCoolerChangedEvent(new EventArgs());
		}

		private void coolersListBox_SelectedIndexChanged(object sender, EventArgs e) {
			plotCooler();
			OnRaiseCoolerChangedEvent(new EventArgs());
		}

		private void closeButton_Click(object sender, EventArgs e) {
			Hide();
		}

		private void outputPowerRadioButton_CheckedChanged(object sender, EventArgs e) {
			if (outputPowerRadioButton.Checked) {
				plotType = PlotType.OUTPUT_POWER;
				plotCooler();
			}
		}

		private void inputPowerRadioButton_CheckedChanged(object sender, EventArgs e) {
			if (inputPowerRadioButton.Checked) {
				plotType = PlotType.INPUT_POWER;
				plotCooler();
			}
		}

		private enum PlotType { INPUT_POWER, OUTPUT_POWER }


	}
}