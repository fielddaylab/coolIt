using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace CryoLib {
public abstract class CryoObjectCollection {
	protected List<CryoObject> objectList = new List<CryoObject>();

	public List<CryoObject>.Enumerator GetEnumerator() {
		return objectList.GetEnumerator();
	}

	public CryoObject this[int index] {
		get { return objectList[index]; }
	}

	public CryoObject this[string name] {
		get {
			for (int i = 0; i < Count; i++) {
				if (this[i].Name == name) {
					return this[i];
				}
			}
			string msg = string.Format("Error: \"{0}\" not found", name );
			throw new Exception(msg);
		}
	}

	public int Count {
		get { return objectList.Count; }
	}

	protected XPathNavigator openDocumentForReading(string fileName) {
		return openDocumentForReading(fileName, null);
	}

	protected XPathNavigator openDocumentForReading(string dataFile, string schemaFile) {
		XmlSchemaSet sc = new XmlSchemaSet();

		XmlReaderSettings settings = new XmlReaderSettings();
		if (schemaFile == null ) {
			settings.ValidationType = ValidationType.None;
		} else {
			sc.Add(null, schemaFile);
			settings.ValidationType = ValidationType.Schema;
			settings.Schemas = sc;
			settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
		}

		//XmlReader reader = XmlReader.Create(dataFile);
		XmlReader reader = XmlReader.Create(dataFile, settings);
		XPathDocument doc = new XPathDocument(reader);
		return doc.CreateNavigator();
	}

	private static void ValidationCallback(object sender, ValidationEventArgs args) {
		string msg = string.Format("Validation Error: {0}", args.Message);
		throw new Exception(msg);
	}
}
}
