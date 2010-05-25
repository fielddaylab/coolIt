using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;

namespace CryoLib {
	public class StrutTypeCollection : List<StrutType> {

        public StrutType this[string name] {
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
                foreach (StrutType st in this)
                {
                    st.ShowOutputs = value;
                }
            }
        }
        #region Constructors
        public StrutTypeCollection()
        {

        }

        public StrutTypeCollection(XPathNavigator navigator)
        {
            if (!navigator.MoveToNext("strutTypes", ""))
            {
                throw new Exception("XML Parsing error");
            }
            if (!navigator.MoveToChild("strutType", ""))
            {
                throw new Exception("XML Parsing error");
            }

            do
            {
                StrutType strut = new StrutType(navigator.Clone());
                this.Add(strut);
            } while (navigator.MoveToNext());
        }
        #endregion
    }
}
