namespace DesktopClient {
	partial class CoolerPicker {
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
			this.coolerVisualizer = new DataVisualizer.DataVisualizer();
			this.powerFactorTrackBar = new System.Windows.Forms.TrackBar();
			this.powerFactorTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.coolersListBox = new System.Windows.Forms.ListBox();
			this.inputPowerRadioButton = new System.Windows.Forms.RadioButton();
			this.outputPowerRadioButton = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.powerFactorTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// coolerVisualizer
			// 
			this.coolerVisualizer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.coolerVisualizer.Location = new System.Drawing.Point(1, 127);
			this.coolerVisualizer.Name = "coolerVisualizer";
			this.coolerVisualizer.Size = new System.Drawing.Size(366, 276);
			this.coolerVisualizer.TabIndex = 35;
			// 
			// powerFactorTrackBar
			// 
			this.powerFactorTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.powerFactorTrackBar.BackColor = System.Drawing.SystemColors.Control;
			this.powerFactorTrackBar.Location = new System.Drawing.Point(148, 86);
			this.powerFactorTrackBar.Name = "powerFactorTrackBar";
			this.powerFactorTrackBar.Size = new System.Drawing.Size(160, 45);
			this.powerFactorTrackBar.TabIndex = 34;
			this.powerFactorTrackBar.ValueChanged += new System.EventHandler(this.powerFactorTrackBar_ValueChanged);
			// 
			// powerFactorTextBox
			// 
			this.powerFactorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.powerFactorTextBox.Enabled = false;
			this.powerFactorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.powerFactorTextBox.Location = new System.Drawing.Point(314, 90);
			this.powerFactorTextBox.Name = "powerFactorTextBox";
			this.powerFactorTextBox.Size = new System.Drawing.Size(39, 22);
			this.powerFactorTextBox.TabIndex = 33;
			this.powerFactorTextBox.Text = "0.1";
			this.powerFactorTextBox.TextChanged += new System.EventHandler(this.powerFactorTextBox_TextChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(12, 90);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(130, 16);
			this.label9.TabIndex = 32;
			this.label9.Text = "Cooler Power Factor";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(28, 197);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 31;
			this.label6.Text = "Cooler Data";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(43, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 16);
			this.label4.TabIndex = 30;
			this.label4.Text = "Coolers";
			// 
			// coolersListBox
			// 
			this.coolersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.coolersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.coolersListBox.FormattingEnabled = true;
			this.coolersListBox.ItemHeight = 16;
			this.coolersListBox.Location = new System.Drawing.Point(122, 12);
			this.coolersListBox.Name = "coolersListBox";
			this.coolersListBox.Size = new System.Drawing.Size(231, 68);
			this.coolersListBox.TabIndex = 29;
			this.coolersListBox.SelectedIndexChanged += new System.EventHandler(this.coolersListBox_SelectedIndexChanged);
			// 
			// inputPowerRadioButton
			// 
			this.inputPowerRadioButton.AutoSize = true;
			this.inputPowerRadioButton.Location = new System.Drawing.Point(175, 127);
			this.inputPowerRadioButton.Name = "inputPowerRadioButton";
			this.inputPowerRadioButton.Size = new System.Drawing.Size(82, 17);
			this.inputPowerRadioButton.TabIndex = 36;
			this.inputPowerRadioButton.Text = "Input Power";
			this.inputPowerRadioButton.UseVisualStyleBackColor = true;
			this.inputPowerRadioButton.CheckedChanged += new System.EventHandler(this.inputPowerRadioButton_CheckedChanged);
			// 
			// outputPowerRadioButton
			// 
			this.outputPowerRadioButton.AutoSize = true;
			this.outputPowerRadioButton.Checked = true;
			this.outputPowerRadioButton.Location = new System.Drawing.Point(263, 127);
			this.outputPowerRadioButton.Name = "outputPowerRadioButton";
			this.outputPowerRadioButton.Size = new System.Drawing.Size(90, 17);
			this.outputPowerRadioButton.TabIndex = 37;
			this.outputPowerRadioButton.TabStop = true;
			this.outputPowerRadioButton.Text = "Output Power";
			this.outputPowerRadioButton.UseVisualStyleBackColor = true;
			this.outputPowerRadioButton.CheckedChanged += new System.EventHandler(this.outputPowerRadioButton_CheckedChanged);
			// 
			// CoolerPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(365, 406);
			this.Controls.Add(this.outputPowerRadioButton);
			this.Controls.Add(this.inputPowerRadioButton);
			this.Controls.Add(this.coolerVisualizer);
			this.Controls.Add(this.powerFactorTrackBar);
			this.Controls.Add(this.powerFactorTextBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.coolersListBox);
			this.Name = "CoolerPicker";
			this.Text = "CoolerPicker";
			((System.ComponentModel.ISupportInitialize)(this.powerFactorTrackBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DataVisualizer.DataVisualizer coolerVisualizer;
		private System.Windows.Forms.TrackBar powerFactorTrackBar;
		private System.Windows.Forms.TextBox powerFactorTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox coolersListBox;
		private System.Windows.Forms.RadioButton inputPowerRadioButton;
		private System.Windows.Forms.RadioButton outputPowerRadioButton;

	}
}