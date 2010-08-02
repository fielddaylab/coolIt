using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;

namespace CryoLib {
	public class StrutTypeCollection : List<StrutType> {

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

        /***
         * Override the Find method with a custom deligate
         **/
        public StrutType Find(int id)
        {
            return this.Find(
                delegate(StrutType obj)
                {
                    return obj.ID == id;
                }
            );
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
