using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;

namespace CryoLib {
	public class CoolerCollection : List<Cooler> {

        public Cooler this[string name] {
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


        public bool ShowOutputs
        {
            set
            {
                foreach (Cooler st in this)
                {
                    st.ShowOutputs = value;
                }
            }
        }

        public CoolerCollection()
        {

        }

        public CoolerCollection(XPathNavigator navigator)
        {
            if (!navigator.MoveToNext("coolers", ""))
            {
                throw new Exception("XML Parsing error");
            }
            if (!navigator.MoveToChild("cooler", ""))
            {
                throw new Exception("XML Parsing error");
            }

            do
            {
                Cooler cooler = new Cooler(navigator.Clone());
                this.Add(cooler);
            } while (navigator.MoveToNext());
        }
	}
}
