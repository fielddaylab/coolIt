using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence {
	public class P_Cooler {
		private int id;
		private string name;

		public virtual int Id {
			get { return id; }
			set { id = value; }
		}

		public virtual string Name {
			get { return name; }
			set { name = value; }
		}

		public P_Cooler() {}
	}
}
