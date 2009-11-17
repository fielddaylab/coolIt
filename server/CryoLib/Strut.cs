using System;
using System.Collections.Generic;
using System.Text;

namespace CryoLib {
	public class Strut {
		private double length;
		private double crossSectionalArea;
		private Material material;

		public double Length {
			get { return length; }
		}

		public double CrossSectionalArea {
			get { return crossSectionalArea; }
		}

		public Material Material {
			get { return material; }
		}

		public Strut(double length, double crossSectionalArea, Material material) {
			this.length = length;
			this.crossSectionalArea = crossSectionalArea;
			this.material = material;
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("Length: {0}\n", length);
			sb.AppendFormat("CrossSectionalArea: {0}\n", crossSectionalArea);
			sb.AppendFormat("Material: {0}", material.Describe());
			return sb.ToString();
		}
	}
}
