using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace CryoLib {
	public class MathGateCollection {

		protected List<MathGate> objectList = new List<MathGate>();

		public MathGate this[int index] {
			get { return objectList[index]; }
		}

		public MathGate this[string name] {
			get {
				for (int i = 0; i < Count; i++) {
					if (this[i].Name == name) {
						return this[i];
					}
				}
				string msg = string.Format("Error: \"{0}\" not found", name);
				throw new Exception(msg);
			}
		}

		public int Count {
			get { return objectList.Count; }
		}
		public MathGateCollection(string dataFile, string schemaFile) {
			XPathNavigator navigator = openDocumentForReading(dataFile, schemaFile);
			if (!navigator.MoveToChild("mathGates", "")) {
				throw new Exception("XML Parsing error");
			}
			if (!navigator.MoveToChild("mathGate", "")) {
				throw new Exception("XML Parsing error");
			}

			do {
				MathGate gate = new MathGate(navigator.Clone());
				objectList.Add(gate);
			} while (navigator.MoveToNext());

		}

		protected XPathNavigator openDocumentForReading(string fileName) {
			return openDocumentForReading(fileName, null);
		}

		protected XPathNavigator openDocumentForReading(string dataFile, string schemaFile) {
			XmlSchemaSet sc = new XmlSchemaSet();

			XmlReaderSettings settings = new XmlReaderSettings();
			if (schemaFile == null) {
				settings.ValidationType = ValidationType.None;
			} else {
				sc.Add(null, schemaFile);
				settings.ValidationType = ValidationType.Schema;
				settings.Schemas = sc;
				settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
			}

			XmlReader reader = XmlReader.Create(dataFile);
			XPathDocument doc = new XPathDocument(reader);
			return doc.CreateNavigator();
		}

		private static void ValidationCallback(object sender, ValidationEventArgs args) {
			string msg = string.Format("Validation Error: {0}", args.Message);
			throw new Exception(msg);
		}
	}
}
