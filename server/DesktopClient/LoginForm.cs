using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopClient {
	public partial class LoginForm : Form {
		private ServiceAdapter coolitWebService;

		public LoginForm( ServiceAdapter coolitWebService ) {
			this.coolitWebService = coolitWebService;
			InitializeComponent();
			DialogResult = DialogResult.No;
		}

		private void newAccountButton_Click(object sender, EventArgs e) {
			string emailAddr = emailTextBox.Text;
			if (coolitWebService.NewLogin(emailAddr)) {
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void existingAccountButton_Click(object sender, EventArgs e) {
			string emailAddr = emailTextBox.Text;
			if (coolitWebService.Login(emailAddr)) {
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			Close();
		}
	}
}