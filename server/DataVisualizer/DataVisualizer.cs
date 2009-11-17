using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NPlot;

namespace DataVisualizer {
	public partial class DataVisualizer : UserControl {
		protected double[] xData;
		protected double[] yData;
		protected string xAxisLabel;
		protected string yAxisLabel;
		protected string plotLabel;
		protected double yMax;
		protected bool yMaxValid = false;

		public DataVisualizer() {
			InitializeComponent();
		}

		public double Y_Max {
			set {
				this.yMax = value;
				yMaxValid = true;
			}
		}

		public void Redraw() {
			updatePlot();
			updateGrid();
		}


		public double[] XData {
			set {
				this.xData = value;
			}
		}

		public double[] YData {
			set {
				this.yData = value;
			}
		}

		public string XAxisLabel {
			set {
				this.xAxisLabel = value;
			}
		}

		public string YAxisLabel {
			set {
				this.yAxisLabel = value;
			}
		}

		public string PlotLabel {
			set {
				this.plotLabel = value;
			}
		}

		protected void updatePlot() {
			plotSurface.Clear();

			LinePlot lp = new LinePlot();
			lp.AbscissaData = xData;
			lp.OrdinateData = yData;
			plotSurface.Add(lp);

			plotSurface.Title = plotLabel;

			plotSurface.XAxis1.WorldMin = 0.0;
			plotSurface.XAxis1.WorldMax = 300.0;
			plotSurface.XAxis1.Label = xAxisLabel;

			plotSurface.YAxis1.WorldMin = 0.0;
			if (yMaxValid) {
				plotSurface.YAxis1.WorldMax = yMax;
			}
			plotSurface.YAxis1.Label = yAxisLabel;

			plotSurface.Refresh();
		}

		protected void updateGrid() {
			gridView.ColumnCount = 2;
			gridView.Columns[0].Name = xAxisLabel;
			gridView.Columns[1].Name = yAxisLabel;
			gridView.Columns[1].Width = 150;

			gridView.Rows.Clear();

			string[] row = new string[2];
			for (int i = 0; i < xData.Length; i++) {
				row[0] = xData[i].ToString();
				row[1] = yData[i].ToString();
				gridView.Rows.Add(row);
			}
		}



	}
}