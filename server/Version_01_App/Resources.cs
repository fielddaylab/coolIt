using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Version_01_App {
	public class Resources {
		public static string DataDir {
			get {
				DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
				if (di.Name == "Debug") {
					return Path.Combine(di.Parent.Parent.FullName, "Data");
				} else {
					return Path.Combine(di.FullName, "Data");
				}
			}
		}

		public static string AppDir {
			get {
				DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
				if (di.Name == "Debug") {
					return di.Parent.Parent.FullName;
				} else {
					return di.FullName;
				}

			}
		}


	}
}
