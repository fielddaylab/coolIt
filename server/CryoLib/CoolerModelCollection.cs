using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace CryoLib {
    /**
    * Class that represents a collection of the different kinds of coolers (CoolerModel.cs)
    * available for selection
    * and the properties of each one
    * 
    * Loaded from the Coolers.xml definitions
    **/
	public class CoolerModelCollection : CryoObjectCollection {

		public CoolerModelCollection(string dataFile, string schemaFile) {
			XPathNavigator navigator = openDocumentForReading(dataFile, schemaFile);
			if (!navigator.MoveToChild("coolerModels", "")) {
				throw new Exception("XML Parsing error");
			}
			if (!navigator.MoveToChild("coolerModel", "")) {
				throw new Exception("XML Parsing error");
			}

			do {
				CoolerModel cooler = new CoolerModel(navigator.Clone());
				this.Add(cooler);
			} while (navigator.MoveToNext());

		}



	}
}
