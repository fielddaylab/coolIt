namespace DesktopClient {
	partial class ServicePickerForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label8 = new System.Windows.Forms.Label();
			this.serviceProviderListBox = new System.Windows.Forms.ListBox();
			this.okButton = new System.Windows.Forms.Button();
			this.abortButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(13, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(241, 18);
			this.label8.TabIndex = 23;
			this.label8.Text = "CoolIt Version 02 Service Providers";
			// 
			// serviceProviderListBox
			// 
			this.serviceProviderListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.serviceProviderListBox.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.serviceProviderListBox.FormattingEnabled = true;
			this.serviceProviderListBox.ItemHeight = 17;
			this.serviceProviderListBox.Location = new System.Drawing.Point(16, 40);
			this.serviceProviderListBox.Name = "serviceProviderListBox";
			this.serviceProviderListBox.Size = new System.Drawing.Size(811, 106);
			this.serviceProviderListBox.TabIndex = 22;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(843, 127);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 21;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// abortButton
			// 
			this.abortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.abortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.abortButton.Location = new System.Drawing.Point(843, 94);
			this.abortButton.Name = "abortButton";
			this.abortButton.Size = new System.Drawing.Size(75, 23);
			this.abortButton.TabIndex = 24;
			this.abortButton.Text = "Abort";
			this.abortButton.UseVisualStyleBackColor = true;
			this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
			// 
			// ServicePickerForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.abortButton;
			this.ClientSize = new System.Drawing.Size(930, 165);
			this.Controls.Add(this.abortButton);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.serviceProviderListBox);
			this.Controls.Add(this.okButton);
			this.Name = "ServicePickerForm";
			this.Text = "ConnectForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListBox serviceProviderListBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button abortButton;
	}
}