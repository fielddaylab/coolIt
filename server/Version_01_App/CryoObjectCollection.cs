using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace Version_01_App {
public abstract class CryoObjectCollection {
	protected List<CryoObject> objectList = new List<CryoObject>();

	public CryoObject this[int index] {
		get { return objectList[index]; }
	}

	public int Count {
		get { return objectList.Count; }
	}

	protected XPathNavigator openDocumentForReading(string fileName) {
		return openDocumentForReading(fileName, true);
	}

	protected XPathNavigator openDocumentForReading(string fileName, bool validate) {
		XmlSchemaSet sc = new XmlSchemaSet();

		XmlReaderSettings settings = new XmlReaderSettings();
		if (validate) {
			sc.Add(null, Path.Combine(Resources.AppDir, "Materials.xsd"));
			settings.ValidationType = ValidationType.Schema;
			settings.Schemas = sc;
			settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
		} else {
			settings.ValidationType = ValidationType.None;
		}

		XmlReader reader = XmlReader.Create(fileName);
		XPathDocument doc = new XPathDocument(reader);
		return doc.CreateNavigator();
	}

	private static void ValidationCallback(object sender, ValidationEventArgs args) {
		string msg = string.Format("Validation Error: {0}", args.Message);
		throw new Exception(msg);
	}
}
}
