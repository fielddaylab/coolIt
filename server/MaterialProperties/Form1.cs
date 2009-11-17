using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NPlot;
using CryoLib;
using System.IO;
using System.Xml;

namespace MaterialProperties {
	public partial class Form1 : Form {

		protected MaterialPropertyCalcCollection calcs;

		public Form1() {
			int materialsCount = 0;
			int usableMaterialsCount = 0;

			InitializeComponent();
			string materialCurvesFile = Path.Combine(Resources.DataDir, "MaterialCurves.xml");
			string materialCurvesSchema = Path.Combine(Resources.SchemaDir, "MaterialCurveDescriptions.xsd");
			calcs = new MaterialPropertyCalcCollection(
										materialCurvesFile,
										materialCurvesSchema
										);

			foreach (MaterialPropertyCalc calc in calcs.List) {
				materialListBox.Items.Add(calc);
				materialsCount++;
				if (calc.Usable) {
					usableMaterialsCount++;
				}
			}

			dataGridView.ColumnCount = 4;
			dataGridView.Columns[0].Name = "Temp";
			dataGridView.Columns[1].Name = "Conductivity";
			dataGridView.Columns[1].Width = 150;
			dataGridView.Columns[2].Name = "Extrapolated Conductivity";
			dataGridView.Columns[2].Width = 150;
			dataGridView.Columns[3].Name = "Integrated Conductivity";
			dataGridView.Columns[3].Width = 150;

			materialListBox.SelectedIndex = 0;
			materialsCountLabel.Text = string.Format("{0} materials ({1} usable)", materialsCount, usableMaterialsCount);
		}

		private void updateGridView(MaterialPropertyCalc calc) {
			dataGridView.Rows.Clear();

			string[] row = new string[4];
			for (int i = 0; i < calc.Temperature.Length; i++) {
				row[0] = calc.Temperature[i].ToString();
				if (i <= calc.MaxX) {
					row[1] = calc.ThermalConductivity[i].ToString();
					row[2] = "";
				} else {
					row[1] = "";
					row[2] = calc.ThermalConductivity[i].ToString();
				}
				if (calc.IntegratedThermalConductivity == null) {
					row[3] = "";
				} else {
					row[3] = calc.IntegratedThermalConductivity[i].ToString();
				}

				dataGridView.Rows.Add(row);
			}
		}

		private void plot(MaterialPropertyCalc calc) {
			// All the colors for this graph are set here
			Color allConductivityColor = Color.Red;
			Color officialConductivityColor = Color.Black;
			Color integratedColor = Color.Blue;

			// General set-up - label, X axis, ...
			plotSurface.Clear();
			plotSurface.Title = calc.Name;
			plotSurface.XAxis1 = new LinearAxis();
			plotSurface.XAxis1.Label = "Temp(Deg K)";
			plotSurface.XAxis1.WorldMin = 0.0;
			plotSurface.XAxis1.WorldMax = 350.0;

			// Plot all the thermal conductivity data - even that which is extrapolated outside the
			// "officially" valid range
			PointPlot allConductivityPlot = genPlot(calc.Temperature, calc.ThermalConductivity, allConductivityColor);
			plotSurface.Add(allConductivityPlot);

			// Plot only the "officially" valid thermal conductivity data.
			PointPlot officialConductivityPlot = genPlot(calc.OfficialTemperature, calc.OfficialThermalConductivity, officialConductivityColor);
			plotSurface.Add(officialConductivityPlot);

			// Add the axis for thermal conductivity (both official and extrapolated)
			plotSurface.YAxis1.Label = "Thermal Conductivity (W/mK)";
			plotSurface.YAxis1.WorldMin = 0.0;

			// Plot the integrated thermal conductivity data
			PointPlot integratedConductivityPlot = genPlot(calc.Temperature, calc.IntegratedThermalConductivity, integratedColor);
			plotSurface.Add(integratedConductivityPlot, PlotSurface2D.XAxisPosition.Bottom, PlotSurface2D.YAxisPosition.Right);

			// Add an appropriately scaled axis on the right side of the graph for the integrated conductivity data
			LinearAxis integratedConductivityAxis = new LinearAxis();
			integratedConductivityAxis.WorldMin = 0.0;
			integratedConductivityAxis.WorldMax = calc.IntegratedThermalConductivity[0];
			integratedConductivityAxis.LabelColor = integratedColor;
			integratedConductivityAxis.Label = "Integrated Thermal Conductivity (W/m)";
			plotSurface.YAxis2 = integratedConductivityAxis;

			plotSurface.Refresh();
		}

		private PointPlot genPlot(double[] xData, double[] yData, Color color) {
			PointPlot answer = new PointPlot();
			answer.Marker = genMarker(color);
			answer.AbscissaData = xData;
			answer.OrdinateData = yData;
			return answer;
		}

		private Marker genMarker(Color color) {
			Marker answer = new Marker(Marker.MarkerType.Circle);
			answer.Filled = true;
			answer.Pen = new Pen(color);
			answer.FillBrush = new SolidBrush(color);
			return answer;
		}

		private void materialListBox_SelectedIndexChanged(object sender, EventArgs e) {
			MaterialPropertyCalc calc = (MaterialPropertyCalc)materialListBox.SelectedItem;
			plot(calc);
			updateGridView(calc);
			nameTextBox.Text = calc.Name;
			idTextBox.Text = calc.Id.ToString();
			notUsableLabel.Visible = !calc.Usable;
			integratedCondCheckbox.Checked = calc.IntegratedThermalConductivity != null;
			
			if (calc.Price < 0.0) {
				rawPriceTextBox.Text = "(unknown)";
				rawPriceTextBox.ForeColor = Color.Red;
			} else {
				rawPriceTextBox.Text = String.Format("{0:C}", calc.Price);
				rawPriceTextBox.ForeColor = Color.Black;
			}
			if (calc.ScaledPrice < 0.0) {
				scaledPriceTextBox.Text = "(unknown)";
			} else {
				scaledPriceTextBox.Text = calc.ScaledPrice.ToString("C");
			}
			if (calc.TensileStrength > 0.0) {
				tensileStrengthTextBox.Text = string.Format("{0} MPa", calc.TensileStrength);
				tensileStrengthTextBox.ForeColor = Color.Black;
			} else {
				tensileStrengthTextBox.Text = "(unknown)";
				tensileStrengthTextBox.ForeColor = Color.Red;
			}
			if (calc.ShearStrength > 0.0) {
				shearStrengthTextBox.Text = string.Format("{0} MPa", calc.ShearStrength);
			} else {
				shearStrengthTextBox.Text = "(unknown)";
			}
			if (calc.CompressionStrength > 0.0) {
				compressionStrengthTextBox.Text = string.Format("{0} Mpa", calc.CompressionStrength);
			} else {
				compressionStrengthTextBox.Text = "(unknown)";
			}
			if (calc.YoungsModulus > 0.0) {
				youngsModulusTextBox.Text = string.Format("{0} GPa", calc.YoungsModulus);
			} else {
				youngsModulusTextBox.Text = "(unknown)";
			}

		}

		private void generateXmlButton_Click(object sender, EventArgs e) {
			XmlDocument doc = new XmlDocument();
			XmlElement materialsElem = calcs.ToXml(doc);
			doc.AppendChild(materialsElem);


			SaveFileDialog sfd = new SaveFileDialog();
			sfd.AddExtension = true;
			sfd.DefaultExt = ".xml";
			sfd.OverwritePrompt = true;
			sfd.Filter = "xml files (*.xml)|*.xml|all files (*.*)|*.*";
			if (sfd.ShowDialog() != DialogResult.OK) {
				return;
			}

			XmlTextWriter xtw = new XmlTextWriter(sfd.FileName, Encoding.UTF8);
			xtw.Formatting = Formatting.Indented;
			xtw.Indentation = 4;
			xtw.IndentChar = ' ';
			doc.Save(xtw);
		}

	}
}