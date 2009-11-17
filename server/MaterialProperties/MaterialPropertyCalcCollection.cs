using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace MaterialProperties {
	public class MaterialPropertyCalcCollection {
		private double priceScalingOffset;
		private double priceScalingFactor;

		protected List<MaterialPropertyCalc> calcs = new List<MaterialPropertyCalc>();

		public List<MaterialPropertyCalc> List {
			get { return calcs; }
		}

		public MaterialPropertyCalcCollection(string dataFile, string schemaFile) {
			XPathNavigator navigator = openDocumentForReading(dataFile, schemaFile );
			if (!navigator.MoveToChild("materialData", "")) {
				throw new Exception("XML Parsing error");
			}

			readPriceScalingInfo( navigator.Clone() );


			if (!navigator.MoveToChild("materials", "")) {
				throw new Exception("XML Parsing error");
			}

			if (navigator.MoveToChild("material", "")) {
				do {
					MaterialPropertyCalc calc = new MaterialPropertyCalc(navigator.Clone());
					calc.SetPriceScale(priceScalingOffset, priceScalingFactor);
					calcs.Add( calc );
				} while (navigator.MoveToNext());
			}

		}

		private void readPriceScalingInfo(XPathNavigator navigator) {
			if (navigator.MoveToChild("priceScalingInfo", "")) {
				navigator.MoveToChild("offset", "");
				priceScalingOffset = navigator.ValueAsDouble;
				navigator.MoveToNext("scalingFactor", "");
				priceScalingFactor = navigator.ValueAsDouble;
			} else {
				priceScalingOffset = 0.0;
				priceScalingFactor = 1.0;
			}
		}
			

		public XmlElement ToXml(XmlDocument doc) {
			XmlElement materialsElem = doc.CreateElement("materials");
			foreach (MaterialPropertyCalc calc in calcs) {
				if (calc.Usable) {
					materialsElem.AppendChild(calc.ToXml(doc, priceScalingFactor, priceScalingOffset));
				}
			}
			return materialsElem;
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
