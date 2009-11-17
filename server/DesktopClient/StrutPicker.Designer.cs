namespace DesktopClient {
	partial class StrutPicker {
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
			this.materialVisualizer = new DataVisualizer.DataVisualizer();
			this.crossSectionTrackBar = new System.Windows.Forms.TrackBar();
			this.lengthTrackBar = new System.Windows.Forms.TrackBar();
			this.label7 = new System.Windows.Forms.Label();
			this.crossSectionTextBox = new System.Windows.Forms.TextBox();
			this.lengthTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.materialsListBox = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.priceTextBox = new System.Windows.Forms.TextBox();
			this.costPerUnitTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.yieldStrengthTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.stressLimitTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.crossSectionTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lengthTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// materialVisualizer
			// 
			this.materialVisualizer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.materialVisualizer.Location = new System.Drawing.Point(2, 224);
			this.materialVisualizer.Name = "materialVisualizer";
			this.materialVisualizer.Size = new System.Drawing.Size(444, 225);
			this.materialVisualizer.TabIndex = 37;
			// 
			// crossSectionTrackBar
			// 
			this.crossSectionTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.crossSectionTrackBar.BackColor = System.Drawing.SystemColors.Control;
			this.crossSectionTrackBar.Location = new System.Drawing.Point(136, 117);
			this.crossSectionTrackBar.Name = "crossSectionTrackBar";
			this.crossSectionTrackBar.Size = new System.Drawing.Size(228, 45);
			this.crossSectionTrackBar.TabIndex = 36;
			this.crossSectionTrackBar.ValueChanged += new System.EventHandler(this.crossSectionTrackBar_ValueChanged);
			// 
			// lengthTrackBar
			// 
			this.lengthTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lengthTrackBar.BackColor = System.Drawing.SystemColors.Control;
			this.lengthTrackBar.Location = new System.Drawing.Point(136, 83);
			this.lengthTrackBar.Name = "lengthTrackBar";
			this.lengthTrackBar.Size = new System.Drawing.Size(228, 45);
			this.lengthTrackBar.TabIndex = 35;
			this.lengthTrackBar.ValueChanged += new System.EventHandler(this.lengthTrackBar_ValueChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(-1, 204);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(117, 20);
			this.label7.TabIndex = 34;
			this.label7.Text = "Material Data";
			// 
			// crossSectionTextBox
			// 
			this.crossSectionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.crossSectionTextBox.Enabled = false;
			this.crossSectionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.crossSectionTextBox.Location = new System.Drawing.Point(370, 119);
			this.crossSectionTextBox.Name = "crossSectionTextBox";
			this.crossSectionTextBox.Size = new System.Drawing.Size(61, 22);
			this.crossSectionTextBox.TabIndex = 33;
			this.crossSectionTextBox.Text = "0.001";
			this.crossSectionTextBox.TextChanged += new System.EventHandler(this.crossSectionTextBox_TextChanged);
			// 
			// lengthTextBox
			// 
			this.lengthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lengthTextBox.Enabled = false;
			this.lengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lengthTextBox.Location = new System.Drawing.Point(370, 83);
			this.lengthTextBox.Name = "lengthTextBox";
			this.lengthTextBox.Size = new System.Drawing.Size(61, 22);
			this.lengthTextBox.TabIndex = 32;
			this.lengthTextBox.Text = "0.1";
			this.lengthTextBox.TextChanged += new System.EventHandler(this.lengthTextBox_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(65, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 16);
			this.label3.TabIndex = 31;
			this.label3.Text = "Length (cm)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(-1, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(134, 16);
			this.label2.TabIndex = 30;
			this.label2.Text = "Cross Section (cm^2)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(79, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 29;
			this.label1.Text = "Material";
			// 
			// materialsListBox
			// 
			this.materialsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.materialsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.materialsListBox.FormattingEnabled = true;
			this.materialsListBox.ItemHeight = 16;
			this.materialsListBox.Location = new System.Drawing.Point(135, 12);
			this.materialsListBox.Name = "materialsListBox";
			this.materialsListBox.Size = new System.Drawing.Size(296, 68);
			this.materialsListBox.TabIndex = 28;
			this.materialsListBox.SelectedIndexChanged += new System.EventHandler(this.materialsListBox_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(307, 158);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 16);
			this.label4.TabIndex = 38;
			this.label4.Text = "Price ($)";
			// 
			// priceTextBox
			// 
			this.priceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.priceTextBox.Enabled = false;
			this.priceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.priceTextBox.Location = new System.Drawing.Point(370, 155);
			this.priceTextBox.Name = "priceTextBox";
			this.priceTextBox.Size = new System.Drawing.Size(61, 22);
			this.priceTextBox.TabIndex = 39;
			this.priceTextBox.Text = "0.001";
			// 
			// costPerUnitTextBox
			// 
			this.costPerUnitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.costPerUnitTextBox.Enabled = false;
			this.costPerUnitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.costPerUnitTextBox.Location = new System.Drawing.Point(175, 188);
			this.costPerUnitTextBox.Name = "costPerUnitTextBox";
			this.costPerUnitTextBox.Size = new System.Drawing.Size(49, 22);
			this.costPerUnitTextBox.TabIndex = 41;
			this.costPerUnitTextBox.Text = "0.001";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(112, 188);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 16);
			this.label5.TabIndex = 40;
			this.label5.Text = "$ / cm^3";
			// 
			// yieldStrengthTextBox
			// 
			this.yieldStrengthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.yieldStrengthTextBox.Enabled = false;
			this.yieldStrengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.yieldStrengthTextBox.Location = new System.Drawing.Point(362, 188);
			this.yieldStrengthTextBox.Name = "yieldStrengthTextBox";
			this.yieldStrengthTextBox.Size = new System.Drawing.Size(69, 22);
			this.yieldStrengthTextBox.TabIndex = 43;
			this.yieldStrengthTextBox.Text = "(unknown)";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(230, 191);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(130, 16);
			this.label6.TabIndex = 42;
			this.label6.Text = "Yield Strength (MPa)";
			// 
			// stressLimitTextBox
			// 
			this.stressLimitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.stressLimitTextBox.Enabled = false;
			this.stressLimitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stressLimitTextBox.Location = new System.Drawing.Point(207, 155);
			this.stressLimitTextBox.Name = "stressLimitTextBox";
			this.stressLimitTextBox.Size = new System.Drawing.Size(68, 22);
			this.stressLimitTextBox.TabIndex = 45;
			this.stressLimitTextBox.Text = "(unknown)";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(112, 158);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(89, 16);
			this.label8.TabIndex = 44;
			this.label8.Text = "Strength (MN)";
			// 
			// StrutPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 447);
			this.Controls.Add(this.stressLimitTextBox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.yieldStrengthTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.costPerUnitTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.priceTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.crossSectionTrackBar);
			this.Controls.Add(this.lengthTrackBar);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.crossSectionTextBox);
			this.Controls.Add(this.lengthTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.materialsListBox);
			this.Controls.Add(this.materialVisualizer);
			this.Name = "StrutPicker";
			this.Text = "StrutPicker";
			((System.ComponentModel.ISupportInitialize)(this.crossSectionTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lengthTrackBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DataVisualizer.DataVisualizer materialVisualizer;
		private System.Windows.Forms.TrackBar crossSectionTrackBar;
		private System.Windows.Forms.TrackBar lengthTrackBar;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox crossSectionTextBox;
		private System.Windows.Forms.TextBox lengthTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox materialsListBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox priceTextBox;
		private System.Windows.Forms.TextBox costPerUnitTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox yieldStrengthTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox stressLimitTextBox;
		private System.Windows.Forms.Label label8;
	}
}