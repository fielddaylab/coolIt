using System;
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;

namespace Version_01_App {
	public abstract class CryoObject {
		protected string name;

		/// <summary>
		/// This is intended to return a short simple string
		/// which would be suitable for use in situations where
		/// the default ToString() is used.  For example, this
		/// string should be reasonable to use in a ListBox.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return name;
		}

		/// <summary>
		/// The name of the object.  This may be the same as the ToString()
		/// result, or not.
		/// </summary>
		public string Name {
			get { return name; }
		}

		/// <summary>
		/// This is intended to return a longer string describing the
		/// object in some detail.
		/// </summary>
		/// <returns></returns>
		public abstract string Describe();

		/// <summary>
		/// Get some piece of data describing the object.  The kinds of data
		/// available depend on the kind of object.
		/// </summary>
		/// <param name="dataType"></param>
		/// <returns></returns>
		public abstract MWNumericArray getData(string dataType);

	}
}
