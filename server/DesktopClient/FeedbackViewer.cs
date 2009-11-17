using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryoLib;

namespace DesktopClient {
	public partial class FeedbackViewer : Form {
		private string webServicebase;
		private string challengeBase;

		public FeedbackViewer( string webServiceBase, string challengeBase ) {
			this.webServicebase = webServiceBase;
			this.challengeBase = challengeBase;
			InitializeComponent();
		}

		public void Show(Feedback feedback) {
			this.Visible = true;
			if (feedback.CutScreen != null && feedback.CutScreen != "") {
				string url = string.Format("{0}/{1}/{2}.jpg", webServicebase, challengeBase, feedback.CutScreen);
				pictureBox1.Load(url);
			}
			if (feedback.Text != null && feedback.Text != "") {
				textBox1.Text = feedback.Text;
			}
			this.Refresh();
		}
	}
}