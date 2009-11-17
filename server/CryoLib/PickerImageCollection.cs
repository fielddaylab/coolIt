using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace CryoLib {
	public class PickerImageCollection {
		private string baseName;
		private int length;
		private int width;

		public string BaseName {
			get { return baseName; }
			set { baseName = value; }
		}

		public int Length {
			get { return length; }
			set { length = value; }
		}

		public int Width {
			get { return width; }
			set { width = value; }
		}

		public string getImage(int x, int y) {
			string answer = string.Format("{0:d4}_{1:d4}_{2:d4}", baseName, x, y);
			return answer;
		}

		public PickerImageCollection(string baseName, int length, int width) {
			this.baseName = baseName;
			this.length = length;
			this.width = width;
		}

		public PickerImageCollection(XPathNavigator navigator) {
			width = int.Parse(navigator.GetAttribute("width", ""));
			length = int.Parse(navigator.GetAttribute("length", ""));
			navigator.MoveToChild("baseName", "");
			baseName = navigator.Value;
		}

		/// <summary>
		/// This parameterless constructor if required for XML serialization.
		/// </summary>
		public PickerImageCollection() { }

	

	}
}
