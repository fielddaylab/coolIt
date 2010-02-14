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

        public double getConstraintTarget( VALUE value, OP op, double defaultAnswer) {
			Constraint c = getConstraint(value, op);
			if (c == null) {
				return defaultAnswer;
			} else {
				return c.Target;
			}
		}

		public double getConstraintTarget( VALUE value, OP op ) {
			Constraint c = getConstraint(value, op);
			if (c == null) {
				string msg = String.Format("Can't find constraint for Value=\"{0}\" and Op=\"{1}\"",
					value, op);
				throw new Exception(msg);
			} else {
				return c.Target;
			}
		}

        public Constraint getConstraint(VALUE value, OP op)
        {
            // Problem constraints might say that Temp <= x or Temp < x, treat these the same here, same goes for
            // other constraint boundaries, e.g. strength >= x or strength > x.
            OP alternateOp;
            switch (op)
            {
                case OP.GE:
                    alternateOp = OP.GT;	// consider GT and GE equivalent
                    break;
                case OP.GT:
                    alternateOp = OP.GE;	// consider GT and GE equivalent
                    break;
                case OP.LE:
                    alternateOp = OP.LT;	// consider LT and LE equivalent
                    break;
                case OP.LT:
                    alternateOp = OP.LE;	// consider LT and LE equivalent
                    break;
                default:
                    alternateOp = op;		// this op has no equivalent
                    break;
            }
            foreach (Constraint c in this)
            {
                if (c.Value == value && (c.Op == op || c.Op == alternateOp))
                {
                    return c;
                }
            }

            return null;
        }
    }
}
