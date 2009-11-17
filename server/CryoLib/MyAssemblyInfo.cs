using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace CryoLib {
	public class MyAssemblyInfo {

		private string[] versionParts;

		/// <summary>
		/// Default constructor.  Provides information about the assembly where this class is located.
		/// </summary>
		public MyAssemblyInfo() : this(Assembly.GetExecutingAssembly() ) { }

		/// <summary>
		/// Constructor.  Provides information about the assembly that's passed in.
		/// </summary>
		/// <param name="assembly"></param>
		public MyAssemblyInfo(Assembly assembly) {
			string[] nameComponents = assembly.FullName.Split(new Char[] { ',' });
			string tmp = nameComponents[1].Split(new Char[] { '=' })[1];
			versionParts = tmp.Split(new char[] { '.' });
		}

		public MyAssemblyInfo(string Major, string Minor, string Build, string Revision) {
			versionParts = new string[4];
			this.Major = Major;
			this.Minor = Minor;
			this.Build = Build;
			this.Revision = Revision;
		}


		public string Major {
			get { return versionParts[0]; }
			set { versionParts[0] = value; }
		}

		public string Minor {
			get { return versionParts[1]; }
			set { versionParts[1] = value; }
		}

		public string Build {
			get { return versionParts[2]; }
			set { versionParts[2] = value; }
		}

		public string Revision {
			get { return versionParts[3]; }
			set { versionParts[3] = value; }
		}

		public string FullVersionNumber {
			get {
				return string.Format("{0}.{1}.{2}.{3}",
					versionParts[0],
					versionParts[1],
					versionParts[2],
					versionParts[3]);
			}
		}
	}
}
