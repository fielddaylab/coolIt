using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace CryoLib {
public abstract class CryoObjectCollection : List<CryoObject> {

	public CryoObject this[string name] {
		get {
			return this.Find(
                delegate(CryoObject obj)
                {
                    return obj.Name == name;
                });
		}
	}

    public CryoObject Find(int id)
    {
        return this.Find(
            delegate(CryoObject obj)
            {
                return obj.id == id;
            }
        );
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
