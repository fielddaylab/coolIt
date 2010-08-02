using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace CryoLib {
public class MaterialsCollection : CryoObjectCollection {

	public MaterialsCollection(string dataFile, string schemaFile ) {
		XPathNavigator navigator = openDocumentForReading(dataFile, schemaFile );
		if (!navigator.MoveToChild("materials", "")) {
			throw new Exception("XML Parsing error");
		}
		if (!navigator.MoveToChild("material", "")) {
			throw new Exception("XML Parsing error");
		}

		do {
			Material material = new Material( navigator.Clone() );
			if (material.IntegratedThermalConductivity != null && material.yieldStrength > 0.0) {
				objectList.Add(material);
			}
		} while (navigator.MoveToNext() );

	}

	public Material[] SortedByGoodness(double temperature) {
		SortedList< double, Material > data = new SortedList<double,Material>();
		for (int i = 0; i < objectList.Count; i++) {
			Material m = (Material)objectList[i];
			double g = m.Goodness( temperature );
			if( g > 0.0 ) {
				data.Add( g, m );
			}
		}
		Material[] answer = new Material[data.Count];
		for (int i = 0; i < data.Count; i++) {
			answer[i] = data.Values[i];
		}
		return answer;
	}



}
}
