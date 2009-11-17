using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace Version_01_App {
public class MaterialsCollection : CryoObjectCollection {

	public MaterialsCollection(string xmlFileName) {
		XPathNavigator navigator = openDocumentForReading(xmlFileName);
		if (!navigator.MoveToChild("materials", "")) {
			throw new Exception("XML Parsing error");
		}
		if (!navigator.MoveToChild("material", "")) {
			throw new Exception("XML Parsing error");
		}

		do {
			Material material = new Material( navigator.Clone() );
			objectList.Add(material);
		} while (navigator.MoveToNext() );

	}

}
}
