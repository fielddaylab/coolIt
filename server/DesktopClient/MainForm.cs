using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryoLib;
using System.IO;

namespace DesktopClient {
	public partial class MainForm : Form {
		private SketchPad sp = null;
		private CoolerPicker coolerPicker;
		private StrutPicker strutPicker;
		private ChallengePicker challengePicker;
		private SimulatorStub simulator;
		private ServiceAdapter coolItWebService;
		private Problem challenge;
		private double bankBalance = 1500.0;
		private State curState;
		private MathGate[] mathGates;
		const double ZERO = 0.0;

		/// <summary>
		/// Constructor
		/// </summary>
		public MainForm() {
			InitializeComponent();

			// Connect to the CoolIt web service
			coolItWebService = connect();
			if (coolItWebService == null) {
				return;
			}
			login();

			// Create a local simulator stub and connect it to the Web Service.
			// From now on we treat this as though it were the whole simulator.  The fact that it
			// calls a Web Service to do its work is transparent from here on.
			simulator = new SimulatorStub(coolItWebService);

			// Subscribe to Simulation Changed events so we can update our temp monitor, cost monitor, ...
			simulator.SimulationChangedEvent += new EventHandler(handle_SimulationChangedEvent);

			// Create the cooler and strut pickers and tell the simulator about them so it can subscribe to
			// their change events.
			strutPicker = new StrutPicker(simulator);
			coolerPicker = new CoolerPicker(simulator);
			challengePicker = new ChallengePicker(simulator);
			simulator.SetControllers(strutPicker, coolerPicker);

			string title = string.Format("CoolIt Desktop Client - Version {0}.{1}",
				coolItWebService.DesktopClientVersion.Major,
				coolItWebService.DesktopClientVersion.Minor);
			this.Text = title;

			bankBalanceTextBox.Text = bankBalance.ToString("C");

			mathGates = coolItWebService.GetMathGates();

			pickChallenge();
		}

		/// <summary>
		/// Some simulation value has changed.  Update our viewers.
		/// </summary>
		/// <param name="sender">The simulator which sent this event</param>
		/// <param name="e">(unused)</param>
		void handle_SimulationChangedEvent(object sender, EventArgs e) {
			curState = ((SimulatorStub)sender).State;

			if (curState.temperature >= 0.0) {
				temperatureBox.Text = curState.temperature.ToString("F2");
			} else {
				temperatureBox.Text = "(undefined)";
			}
			if (challenge != null && curState.temperature <= challenge.TargetTemperature) {
				temperatureBox.ForeColor = Color.Green;
			} else {
				temperatureBox.ForeColor = Color.Red;
			}

			costBox.Text = curState.cost.ToString("C");
			if (curState.inputPower >= 0.0) {
				inputPowerBox.Text = curState.inputPower.ToString("F2");
			} else {
				inputPowerBox.Text = "(undefined)";
			}
			if (challenge != null && curState.inputPower <= challenge.InputPowerLimit) {
				inputPowerBox.ForeColor = Color.Green;
			} else {
				inputPowerBox.ForeColor = Color.Red;
			}

			if (curState.stressLimit > 0.0) {
				stressLimitTextBox.Text = string.Format("{0:F3}", curState.stressLimit);
			} else {
				stressLimitTextBox.Text = "(unknown)";
			}
			if (challenge != null && curState.stressLimit >= challenge.StrengthRequirement) {
				stressLimitTextBox.ForeColor = Color.Green;
			} else {
				stressLimitTextBox.ForeColor = Color.Red;
			}

			
			
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("Coolit Desktop Client\n");
			sb.AppendFormat("Copyright 2007 - 2009 by the University of Wisconsin Board of Regents\n\n");
			sb.AppendFormat("Desktop Client Version: {0}\n", coolItWebService.DesktopClientVersion.FullVersionNumber);
			sb.AppendFormat("Cryolib Version: {0}\n", coolItWebService.CryolibVersion.FullVersionNumber);
			sb.AppendFormat("CoolIt Web Service Version: {0}\n", coolItWebService.WebServiceVersion.FullVersionNumber);
			sb.AppendFormat("CoolIt Web Service Location: {0}\n\n", coolItWebService.WebServiceURL);
			sb.AppendLine("Game Designers:");
			sb.AppendLine("    John Pfotenhauer");
			sb.AppendLine("    Greg Nellis");
			sb.AppendLine("    David Gagnon");
			sb.AppendLine("    Mike Litzkow");
			sb.AppendLine("    Chris Blakesley");
			sb.AppendLine("");
			sb.AppendLine("Funding by Engage Phase III - 2007, 2008");
			MessageBox.Show(sb.ToString());
		}

		private ServiceAdapter connect() {

					// Do it this way for production - force use of the real server
			//ServiceProvider provider = ServiceAdapter.Providers[2];	// This is ATSWINDEV
			//return new ServiceAdapter(provider);

					// Do it this way for debugging - so you can pick the service provider
			ServicePickerForm spf = new ServicePickerForm(ServiceAdapter.Providers);
			for (; ; ) {
				switch (spf.ShowDialog()) {
					case DialogResult.Abort:
						return null;
					case DialogResult.OK:
						Cursor savedCursor = this.Cursor;
						try {
							this.Cursor = Cursors.WaitCursor;
							return new ServiceAdapter(spf.Provider);
						} catch (Exception ex) {
							MessageBox.Show(ex.Message);
							break;
						} finally {
							this.Cursor = savedCursor;
						}
				}
			}
		}

		private void sketchToolStripMenuItem_Click(object sender, EventArgs e) {
			sp = new SketchPad( simulator );
			sp.Show();
		}

		private void coolersToolStripMenuItem_Click(object sender, EventArgs e) {
			coolerPicker.Show();
		}

		private void strutsToolStripMenuItem_Click(object sender, EventArgs e) {
			strutPicker.Show();
		}

		private void button1_Click(object sender, EventArgs e) {
			strutPicker.Show();
		}

		private void button2_Click(object sender, EventArgs e) {
			coolerPicker.Show();
		}

		private void problemToolStripMenuItem_Click(object sender, EventArgs e) {
			pickChallenge();
		}

		private void login() {
			LoginForm lf = new LoginForm(coolItWebService);
			//while (lf.ShowDialog() != DialogResult.OK) { }
			lf.ShowDialog();
		}

		private void pickChallenge() {
			if (challengePicker.ShowDialog() != DialogResult.OK) {
				return;
			}
			if (challenge != challengePicker.Problem) {
				challenge = challengePicker.Problem;
				string url = string.Format("{0}/{1}/{2}.jpg", ServiceAdapter.ImageBaseUrl, challenge.ImageCollection.BaseURI, challenge.ImageCollection.Intro);
				pictureBox1.Load(url);
				challengeNameTextBox.Text = challenge.Name;
				if( challenge.Solved ) {
					incentiveTextBox.Text = ZERO.ToString("C");
				} else {
					incentiveTextBox.Text = challenge.MonetaryIncentive.ToString( "C" );
				}
				simulator.SetProblem(challenge.Name);
				strutPicker.MinStrutLength = challenge.MinStrutLength;
				strutPicker.MaxStrutLength = challenge.MaxStrutLength;
				strutPicker.MinStrutCrossSection = challenge.MinStrutCrossSection;
				strutPicker.MaxStrutCrossSection = challenge.MaxStrutCrossSection;

			}
		}

		private void MainForm_Shown(object sender, EventArgs e) {
			// We should have gotten connected to the CoolIt Web Service in our constructor.  If not,
			// it means the user aborted the connection process, so we should exit.
			if (coolItWebService == null) {
				Application.Exit();
			}
		}

		private void commitButton_Click(object sender, EventArgs e) {
			Feedback feedback = coolItWebService.GetFeedback();
			FeedbackViewer fv = new FeedbackViewer(ServiceAdapter.ImageBaseUrl, challenge.ImageCollection.BaseURI);
			fv.Show(feedback);

			if (curState.isValidSolution) {
				if (!challenge.Solved) {
					bankBalance += challenge.MonetaryIncentive;
					bankBalanceTextBox.Text = bankBalance.ToString("C");
					challenge.Solved = true;
					incentiveTextBox.Text = ZERO.ToString("C");
				}
			}
		}

		private void stressLimitTextBox_KeyPress(object sender, KeyPressEventArgs e) {
			e.Handled = true;
		}

		private void sketchPadToolStripMenuItem_Click(object sender, EventArgs e) {
			SketchPad sk = new SketchPad(simulator);
			sk.Show();
		}

		private void heatLeakVisualizerToolStripMenuItem_Click(object sender, EventArgs e) {

			if( coolItWebService.HasCapability(CAPABILITY.CP_VS_HEAT_LEAK_GRAPH) ) {
				HeatLeakVisualizer vis = new HeatLeakVisualizer(simulator);
				vis.Show();
				return;
			} else {
				if (MessageBox.Show("Do you want to try the Math Gate now?", "Math Gate", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					MathGateQuiz gateQuiz = new MathGateQuiz(mathGates[0]);
					if (gateQuiz.ShowDialog() == DialogResult.OK) {
						// Get values from the form and validate against the web service
						if (coolItWebService.TryMathGate("Level 1", gateQuiz.Answers )) {
							HeatLeakVisualizer vis = new HeatLeakVisualizer(simulator);
							vis.Show();
						} else {
							MessageBox.Show("Sorry - you failed the Math Gate");
						}
					}
				}
			}
		}


	}
}