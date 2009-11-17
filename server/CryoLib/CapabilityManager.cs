using System;
using System.Collections.Generic;
using System.Text;

namespace CryoLib {
	public class CapabilityManager {

		private List<CAPABILITY> capabilities;
		private MathGateCollection gates;

		public CapabilityManager(MathGateCollection gates) {
			this.gates = gates;
			this.capabilities = new List<CAPABILITY>();
		}

		public bool HasCapability( CAPABILITY desiredCapability ) {
			if( capabilities.Contains(desiredCapability) ) {
				return true;
			} else {
				return false;
			}
		}

		public bool TryMathGate(string name, double[] answers) {
			MathGate gate = gates[name];
			if (gate.IsSolution(answers)) {
				capabilities.Add(gate.Capability);
				return true;
			} else {
				return false;
			}
		}
	}
}
