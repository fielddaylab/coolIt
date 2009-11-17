using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace Version_01_App {
	public class CoolerCollection : CryoObjectCollection {



		public CoolerCollection(string xmlFileName) {
			XPathNavigator navigator = openDocumentForReading(xmlFileName);
			if (!navigator.MoveToChild("coolers", "")) {
				throw new Exception("XML Parsing error");
			}
			if (!navigator.MoveToChild("cooler", "")) {
				throw new Exception("XML Parsing error");
			}

			do {
				Cooler cooler = new Cooler(navigator.Clone());
				objectList.Add(cooler);
			} while (navigator.MoveToNext());

		}

	}
}
