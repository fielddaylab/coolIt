using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;

namespace CryoLib {
	public class ConstraintCollection : List<Constraint> {

        public Constraint  this[string name] {
			get {
				for (int i = 0; i < Count; i++) {
					if (this[i].Value + "." + this[i].Op == name) {
						return this[i];
					}
				}
				string msg = string.Format("Error: \"{0}\" not found", name);
				throw new Exception(msg);
			}
		}

        public ConstraintCollection()
        {

        }

        public ConstraintCollection(XPathNavigator navigator)
        {
            if (!navigator.MoveToNext("constraints", ""))
            {
                throw new Exception("XML Parsing error");
            }
            if (!navigator.MoveToChild("constraint", ""))
            {
                throw new Exception("XML Parsing error");
            }

            do
            {
                Constraint Constraint = new Constraint(navigator.Clone());
                this.Add(Constraint);
            } while (navigator.MoveToNext());
        }
	}
}
