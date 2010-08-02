using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;

namespace CryoLib {
	public class CoolerCollection : List<Cooler> {

        /***
         * Override the Find method with a custom deligate
         **/
        public Cooler Find(int id)
        {
            return this.Find(
                delegate(Cooler obj)
                {
                    return obj.ID == id;
                }
            );
        }

        /**
         * Apply serialization settings to each object in the collection
         **/
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
