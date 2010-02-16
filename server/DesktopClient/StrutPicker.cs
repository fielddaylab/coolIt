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

        private StrutTypeCollection struts = new StrutTypeCollection();
        private StrutType selectedStrut = null;

		public StrutPicker( SimulatorStub simulator ) {
			InitializeComponent();

			Material[] materials = simulator.GetMaterials();
			materialsListBox.Items.Clear();
			for (int i = 0; i < materials.Length; i++) {
				materialsListBox.Items.Add(materials[i]);
			}
			materialsListBox.SelectedIndex = 0;

            //Load the drop down with the list of struts
            setStrutSelector();

			updatePrice();

			this.FormClosing += new FormClosingEventHandler(StrutPicker_FormClosing);
		}

        private void setStrutSelector()
        {
            if (this.struts.Count > 0)
            {
                cbStruts.Enabled = true;
                cbStruts.DataSource = this.struts;
                cbStruts.DisplayMember = "ID";
            }
            else
            {
                cbStruts.Enabled = false;
            }
        }

        /**
         * The properties of the struts that are defined in the problem
         **/
        public StrutTypeCollection Struts
        {
            get
            {
                return this.struts;
            }
            set
            {
                this.struts = value;
                setStrutSelector();
            }
        }

		private void adjustTrackbar(TrackBar trackBar) {
			trackBar.Minimum = 0;
			trackBar.Maximum = TRACKBAR_RANGE;
		}


		void StrutPicker_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
			Hide();
		}

        //TODO:  Need to handle this properly with the new picker
		public StrutType Strut {
			get {
				return new StrutType(getLength(), getCrossSection(), (Material)materialsListBox.SelectedItem);
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

        private void cbStruts_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStrut = (StrutType)cbStruts.SelectedItem;

            updateControlsByStrut();
        }

        private void updateControlsByStrut()
        {
            //TODO:  Fix trackbars to handle dynmaic strut selection
            minStrutLength = selectedStrut.MinStrutLength;
            maxStrutLength = selectedStrut.MaxStrutLength;
            adjustTrackbar(lengthTrackBar);
            lengthTrackBar.Value = (int)((maxStrutLength - minStrutLength) / 2 * TRACKBAR_RANGE);
            lengthTrackBar.TickFrequency = TRACKBAR_RANGE / 10;

            adjustTrackbar(crossSectionTrackBar);
            maxCrossSection = selectedStrut.MaxStrutCrossSection;
            minCrossSection = selectedStrut.MinStrutCrossSection;
            crossSectionTrackBar.Value = (int)((maxCrossSection - minCrossSection) / 2 * TRACKBAR_RANGE);
            crossSectionTrackBar.TickFrequency = TRACKBAR_RANGE / 10;

        }
	}
}