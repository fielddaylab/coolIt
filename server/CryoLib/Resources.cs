using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace CryoLib {
	public class Resources {
		private static string schemaDir;
		private static string dataDir;

		public static string SchemaDir {
			get { return schemaDir; }
		}

		public static string DataDir {
			get { return dataDir; }
		}

		static Resources() {
			Assembly assembly = Assembly.GetExecutingAssembly();
			FileInfo fi = new FileInfo(assembly.Location);
			string appDir;
			if (fi.Directory.Name == "Debug") {
				appDir = fi.Directory.Parent.Parent.FullName;
			} else {
				appDir = fi.Directory.FullName;
			}
			schemaDir = Path.Combine(appDir, "Schema");
			dataDir = Path.Combine(appDir, "Data");
		}

	}
}
