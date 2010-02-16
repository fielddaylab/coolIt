using System;
using System.Collections.Generic;
using System.Text;
using CryoLib;

namespace DesktopClient {
	public class SimulatorStub {
		protected ServiceAdapter webServiceAdapter;
		protected State state;

		public event EventHandler SimulationChangedEvent;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="adapter"></param>
		public SimulatorStub( ServiceAdapter adapter ) {
			// Connect up to the Web Service which does all the real work
			this.webServiceAdapter = adapter;
		}
		
		/// <summary>
		/// Set up to handle change events from the Strut and Cooler pickers.
		/// 
		/// Would like to do this in the constructor, but the pickers need a reference to this object so they
		/// can get their Materials and Coolers lists.  Since they need that reference, they cannot be constructed
		/// until after this object is constructed.  Therefore this routine starts everything going.
		/// </summary>
		/// <param name="strutPicker"></param>
		/// <param name="coolerPicker"></param>
		public void SetControllers( StrutPicker strutPicker, CoolerPicker coolerPicker ) {
			// Set initial cooler and strut choices into the simulator
			StrutType strut = strutPicker.Strut;
			CoolerType cooler = coolerPicker.Cooler;
			webServiceAdapter.SetStrut(strut.Material.Name, strut.Length, strut.CrossSectionalArea);
			webServiceAdapter.SetCooler(cooler.Name, coolerPicker.PowerFactor);

			// Run the simulator for the first time
			simulate();

			// Set up to handle change events from the controllers
			strutPicker.RaiseStrutChangedEvent += new EventHandler(handle_StrutChangedEvent);
			coolerPicker.RaiseCoolerChangedEvent += new EventHandler(handle_CoolerChangedEvent);
		}

		/// <summary>
		/// Return a list of available materials.  We get this information from the web service.
		/// </summary>
		/// <returns></returns>
		public Material[] GetMaterials() {
			return webServiceAdapter.GetMaterials();
		}

		/// <summary>
		/// Return a list of available coolers.  We get this information from the web service.
		/// </summary>
		/// <returns></returns>
		public CoolerType[] GetCoolers() {
			return webServiceAdapter.GetCoolers();
		}

		/// <summary>
		/// Return a list of available problems.  We get this information from the web service.
		/// </summary>
		/// <returns></returns>
		public Problem[] GetProblems() {
			return webServiceAdapter.GetProblems();
		}


		/// <summary>
		/// Return the current state of the simulation - read only.
		/// </summary>
		public State State {
			get { return state; }
		}

		public void SetProblem(string problemName) {
			webServiceAdapter.SetProblem(problemName);
			simulate();
		}


		/// <summary>
		/// User has changed a cooler or one of its settings.
		/// </summary>
		/// <param name="sender">The CoolerPicker which generated this event</param>
		/// <param name="e">(unused)</param>
		void handle_CoolerChangedEvent(object sender, EventArgs e) {
			CoolerType cooler = ((CoolerPicker)sender).Cooler;
			webServiceAdapter.SetCooler(cooler.Name, ((CoolerPicker)sender).PowerFactor);
			simulate();
		}

		/// <summary>
		/// User has changed a strut or one of its settings.
		/// </summary>
		/// <param name="sender">The StrucPicker which generated this event</param>
		/// <param name="e">(unused)</param>
		void handle_StrutChangedEvent(object sender, EventArgs e) {
			StrutType strut = ((StrutPicker)sender).Strut;
			webServiceAdapter.SetStrut(strut.Material.Name, strut.Length, strut.CrossSectionalArea);
			simulate();
		}

		/// <summary>
		/// Run the simulator with current conditions
		/// </summary>
		protected void simulate() {
			// run the simulator
			state = webServiceAdapter.Run();
			if (state == null) {
				return;
			}

			// let our subscribers know that things have changed
			OnSimulationChangedEvent(new EventArgs());
		}

		/// <summary>
		/// Notify all subscribers of a change
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnSimulationChangedEvent(EventArgs e) {
			EventHandler handler = SimulationChangedEvent;

			if (handler != null) {
				handler(this, e);
			}
		}
	}
}
