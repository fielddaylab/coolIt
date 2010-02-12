using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;

namespace CryoLib {
	public class StrutCollection : List<Strut> {

        public Strut this[string name] {
			get {
				for (int i = 0; i < Count; i++) {
					if (this[i].ID == name) {
						return this[i];
					}
				}
				string msg = string.Format("Error: \"{0}\" not found", name);
				throw new Exception(msg);
			}
		}

        public StrutCollection()
        {

        }

        public StrutCollection(XPathNavigator navigator)
        {
            if (!navigator.MoveToNext("struts", ""))
            {
                throw new Exception("XML Parsing error");
            }
            if (!navigator.MoveToChild("strut", ""))
            {
                throw new Exception("XML Parsing error");
            }

            do
            {
                Strut strut = new Strut(navigator.Clone());
                this.Add(strut);
            } while (navigator.MoveToNext());
        }
	}
}
