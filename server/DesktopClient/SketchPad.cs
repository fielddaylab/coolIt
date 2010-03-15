using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NPlot;
using CryoLib;

namespace DesktopClient {
	public partial class SketchPad : Form {
		const double DEFAULT_Y_MIN = 0.0;
		const double DEFAULT_Y_MAX = 300.0;
		private double yMin = DEFAULT_Y_MIN;
		private double yMax = DEFAULT_Y_MAX;
		private bool autoScale;
		private List<DataPoint> data;

		public SketchPad( SimulatorStub sim ) {
			InitializeComponent();
			data = new List<DataPoint>();
			drawAxes();
			sim.SimulationChangedEvent += new EventHandler(handle_SimulationChangedEvent);
		}

		void handle_SimulationChangedEvent(object sender, EventArgs e) {
			Problem state = ((SimulatorStub)sender).State;
			if (powerFactorRadioButton.Checked) {
				addPoint(state.PowerFactor, state.Temperature);
			} else if (strutLengthRadioButton.Checked) {
                //TODO:  Fix this to handle multiple struts
				addPoint(state.Struts[0].Length, state.Temperature);
			} else {
                //TODO:  Fix this to handle multiple struts
				addPoint(state.Struts[0].CrossSectionalArea, state.Temperature);
			}
		}

		private void drawAxes() {
			if (powerFactorRadioButton.Checked) {
				initPlot(1.0, "Power Factor");
			} else if (strutLengthRadioButton.Checked) {
				initPlot(1.0, "Strut Length (M)");
			} else {
				initPlot(0.1, "Strut Cross Sectional Area (M ** 2)");
			}
		}


		private void initPlot(double maxX, string xLabel) {
			plotSurface.Clear();

			PointPlot pp = new PointPlot();
			Marker m = new Marker();
			double[] x = { 0.0, maxX };
			double[] y = { 0.0, 300.0 };
			pp.AbscissaData = x;
			pp.OrdinateData = y;

			plotSurface.Add(pp);

			plotSurface.XAxis1.Label = xLabel;
			plotSurface.XAxis1.WorldMin = 0.0;
			plotSurface.XAxis1.WorldMax = maxX;

			plotSurface.YAxis1.Label = "Temperature (Deg K)";
			plotSurface.YAxis1.WorldMin = yMin;
			plotSurface.YAxis1.WorldMax = yMax;

			plotSurface.Refresh();
		}

		//public void AddPoint(double pf, double length, double area, double temp) {
		//    if (powerFactorRadioButton.Checked) {
		//        addPoint(pf, temp);
		//    } else if (strutLengthRadioButton.Checked) {
		//        addPoint(length, temp);
		//    } else {
		//        addPoint(area, temp);
		//    }
		//}

		private void addPoint( double xVal, double temp ) {
			drawPoint( xVal, temp );
			data.Add( new DataPoint(temp, xVal) );

		}

		private void drawPoint(double xVal, double temp) {
			PointPlot pp = new PointPlot();
			double [] x = new double[1];
			x[0] = xVal;
			double [] y = new double[1];
			y[0] = temp;
			pp.AbscissaData = x;
			pp.OrdinateData = y;
			plotSurface.Add( pp );

			plotSurface.Refresh();
		}

		private void clearButton_Click(object sender, EventArgs e) {
			data = new List<DataPoint>();
			drawAxes();
		}

		private void closeButton_Click(object sender, EventArgs e) {
			Close();
		}

		private void checkbox_CheckedChanged(object sender, EventArgs e) {
			data = new List<DataPoint>();
			drawAxes();
		}

		private void autoScaleCheckbox_CheckedChanged(object sender, EventArgs e) {
			autoScale = autoScaleCheckbox.Checked;
			setScale();
			redraw();
		}

		private void redraw() {
			plotSurface.Clear();
			drawAxes();
			foreach (DataPoint p in data) {
				drawPoint(p.data, p.temp);
			}
		}

		private void setScale() {
			if (autoScale) {
				yMin = DEFAULT_Y_MAX;
				yMax = DEFAULT_Y_MIN;
				foreach (DataPoint p in data) {
					if (p.temp < yMin) {
						yMin = p.temp;
					}
					if (p.temp > yMax) {
						yMax = p.temp;
					}
				}
			} else {
				yMin = DEFAULT_Y_MIN;
				yMax = DEFAULT_Y_MAX;
			}



		}
	}
}