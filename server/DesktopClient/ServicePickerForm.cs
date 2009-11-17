using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopClient {
	public partial class ServicePickerForm : Form {
		public ServicePickerForm( List<ServiceProvider> providers ) {
			InitializeComponent();

			foreach (ServiceProvider p in providers) {
				serviceProviderListBox.Items.Add(p);
			}
			if (serviceProviderListBox.Items.Count > 0) {
				serviceProviderListBox.SelectedIndex = 0;
			} else {
				throw new Exception("Can't find any CoolIt service providers");
			}
		}

		public ServiceProvider Provider {
			get { return (ServiceProvider)serviceProviderListBox.SelectedItem; }
		}

		private void okButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}

		private void abortButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Abort;
			Close();
		}

	}
}