using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net.Config;

namespace TestDriver {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			log4net.Config.XmlConfigurator.Configure();
			Application.Run(new Form1());

		}
	}
}