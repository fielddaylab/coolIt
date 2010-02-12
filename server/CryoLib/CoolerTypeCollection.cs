using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace CryoLib {
    /**
    * Class that represents a collection of the different kinds of coolers (CoolerType.cs)
    * available for selection
    * and the properties of each one
    * 
    * Loaded from the Coolers.xml definitions
    **/
	public class CoolerTypeCollection : CryoObjectCollection {

		public CoolerTypeCollection(string dataFile, string schemaFile) {
			XPathNavigator navigator = openDocumentForReading(dataFile, schemaFile);
			if (!navigator.MoveToChild("coolers", "")) {
				throw new Exception("XML Parsing error");
			}
			if (!navigator.MoveToChild("cooler", "")) {
				throw new Exception("XML Parsing error");
			}

			do {
				CoolerType cooler = new CoolerType(navigator.Clone());
				this.Add(cooler);
			} while (navigator.MoveToNext());

		}



	}
}
