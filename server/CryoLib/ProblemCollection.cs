using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;

namespace CryoLib {
	public class ProblemCollection : List<Problem> {

		public Problem  this[string name] {
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

		public ProblemCollection(string dataFile, string schemaFile) {
			XPathNavigator navigator = openDocumentForReading(dataFile, schemaFile);
			if (!navigator.MoveToChild("problems", "")) {
				throw new Exception("XML Parsing error");
			}
			if (!navigator.MoveToChild("problem", "")) {
				throw new Exception("XML Parsing error");
			}

			do {
				Problem problem = new Problem(navigator.Clone());
				this.Add(problem);
			} while (navigator.MoveToNext());

		}

        public Problem Find(int id)
        {
            return this.Find(
                delegate(Problem obj)
                {
                    return obj.ID == id;
                }
            );
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

			XmlReader reader = XmlReader.Create(dataFile, settings);
			//XmlReader reader = XmlReader.Create(dataFile);

			XPathDocument doc = new XPathDocument(reader);
			XPathNavigator answer = doc.CreateNavigator();
			return answer;
		}

		private static void ValidationCallback(object sender, ValidationEventArgs args) {
			string msg = string.Format("Validation Error: {0}", args.Message);
			throw new Exception(msg);
		}
	}
}
