using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryoLib;
using NPlot;

namespace DesktopClient {
	public partial class HeatLeakVisualizer : Form {

		private Material[] materials;
		private CoolerType[] coolers;
		private State state;
		private SimulatorStub simulator;

		public HeatLeakVisualizer( SimulatorStub simulator ) {
			InitializeComponent();

			this.simulator = simulator;
			this.materials = simulator.GetMaterials();
			this.coolers = simulator.GetCoolers();

			simulator.SimulationChangedEvent += new EventHandler(simulator_SimulationChangedEvent);
			update();
		}

		void simulator_SimulationChangedEvent(object sender, EventArgs e) {
			update();
		}

		private void update() {
			plot.Clear();

			double maxHeatLeak = updateHeatLeak();
			double maxCoolingPower = updateCoolingPower();

			plot.Title = "Heat Leak Visualizer";
			plot.XAxis1.WorldMin = 0.0;
			plot.XAxis1.WorldMax = 300.0;
			plot.XAxis1.Label = "Temperature (Deg K)";

			plot.YAxis1.Label = "Heat Leak (Watts)";
			plot.YAxis1.Color = Color.Green;
			plot.YAxis1.WorldMin = 0.0;

			plot.YAxis2.Label = "Cooling Power( Watts)";
			plot.YAxis2.Color = Color.Orange;
			plot.YAxis2.WorldMin = 0.0;


			plot.YAxis1.WorldMin = 0.0;
			if (maxCoolingPower > maxHeatLeak) {
				plot.YAxis1.WorldMax = maxCoolingPower;
				plot.YAxis2.WorldMax = maxCoolingPower;
			} else {
				plot.YAxis1.WorldMax = maxHeatLeak;
				plot.YAxis2.WorldMax = maxHeatLeak;
			}

			plot.Refresh();
		}

		private double updateCoolingPower() {
			state = simulator.State;
			CoolerType cooler = null;
			for (int i = 0; i < coolers.Length; i++) {
				if (coolers[i].Name == state.coolerName) {
					cooler = coolers[i];
					break;
				}
			}
			if (cooler == null) {
				string msg = string.Format("Can't find cooler \"{0}\"", state.coolerName);
				throw new Exception(msg);
			}
			double[] x = new double[2];
			double[] y = new double[2];
			double max = cooler.CPM[1].data;
			x[0] = 300 - (300 - cooler.CPM[0].temp) * state.powerFactor;
			x[1] = 300;
			for (int i = 0; i < 2; i++) {
				y[i] = cooler.OutputPower(cooler.CPM[i].temp, state.powerFactor);
			}


			LinePlot lp = new LinePlot();
			lp.Pen = Pens.Orange;
			lp.AbscissaData = x;
			lp.OrdinateData = y;
			
			plot.Add(lp, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Right);

			return max;
		}

		private double updateHeatLeak() {
			state = simulator.State;
			Material material = null;
			for (int i = 0; i < materials.Length; i++) {
				if (materials[i].Name == state.materialName) {
					material = materials[i];
					break;
				}
			}
			if (material == null) {
				string msg = string.Format("Can't find material \"{0}\"", state.materialName);
				throw new Exception(msg);
			}

			List<DataPoint> materialData = material.IntegratedThermalConductivity;
			if (materialData == null) {
				materialData = new List<DataPoint>();
			}
			double[] x = new double[materialData.Count];
			double[] y = new double[materialData.Count];


			double max = 0.0;
			for (int i = 0; i < materialData.Count; i++) {
				x[i] = materialData[i].temp;
				double thermalConductivity = materialData[i].data;
				double crossSectionalArea = state.crossSection;
				double deltaT = 300.0 - materialData[i].temp;
				double length = state.length;
				//double heatLeak = thermalConductivity * crossSectionalArea * deltaT / length;
				double heatLeak = thermalConductivity * crossSectionalArea / length;
				heatLeak *= state.numStruts;
				y[i] = heatLeak;
				if (y[i] > max) {
					max = y[i];
				}
			}
			LinePlot lp = new LinePlot();
			lp.Pen = Pens.Green;
			lp.AbscissaData = x;
			lp.OrdinateData = y;
			plot.Add(lp);

			return max;
		}

	}
}