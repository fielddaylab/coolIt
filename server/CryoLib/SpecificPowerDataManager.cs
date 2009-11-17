using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;

namespace CryoLib {
	public class SpecificPowerDataManager {

		private DataPoint[] data;

		public DataPoint [] Data {
			get { return data; }
		}

	
		public SpecificPowerDataManager(string dataFile, string schemaFile ) {
			XPathNavigator navigator = openDocumentForReading(dataFile, schemaFile );
			if (!navigator.MoveToChild("specificPowerData", "")) {
				throw new Exception("XML Parsing error");
			}
			if( !navigator.MoveToChild("dataPoint", "") ) {
				return;
			}

			List<DataPoint> pointList = new List<DataPoint>();
			do {
				DataPoint point = new DataPoint();
				navigator.MoveToChild("temperature", "" );
				point.temp = navigator.ValueAsDouble;
				navigator.MoveToNext();
				point.data = navigator.ValueAsDouble;
				navigator.MoveToNext();
				pointList.Add(point);
				navigator.MoveToParent();
			} while( navigator.MoveToNext() );

			data = new DataPoint[pointList.Count];
			pointList.CopyTo(data);
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
