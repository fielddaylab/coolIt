namespace Version_02_App {
	partial class MainForm {
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
			this.materialDataBox = new System.Windows.Forms.RichTextBox();
			this.simulateButton = new System.Windows.Forms.Button();
			this.materialsListBox = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lengthTextBox = new System.Windows.Forms.TextBox();
			this.crossSectionTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.coolersListBox = new System.Windows.Forms.ListBox();
			this.answerBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.coolerDataBox = new System.Windows.Forms.RichTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// materialDataBox
			// 
			this.materialDataBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.materialDataBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.materialDataBox.Location = new System.Drawing.Point(27, 247);
			this.materialDataBox.Name = "materialDataBox";
			this.materialDataBox.Size = new System.Drawing.Size(379, 465);
			this.materialDataBox.TabIndex = 1;
			this.materialDataBox.Text = "";
			// 
			// simulateButton
			// 
			this.simulateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.simulateButton.Enabled = false;
			this.simulateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.simulateButton.Location = new System.Drawing.Point(769, 126);
			this.simulateButton.Name = "simulateButton";
			this.simulateButton.Size = new System.Drawing.Size(88, 26);
			this.simulateButton.TabIndex = 2;
			this.simulateButton.Text = "Simulate";
			this.simulateButton.UseVisualStyleBackColor = true;
			this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
			// 
			// materialsListBox
			// 
			this.materialsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.materialsListBox.FormattingEnabled = true;
			this.materialsListBox.ItemHeight = 16;
			this.materialsListBox.Location = new System.Drawing.Point(225, 9);
			this.materialsListBox.Name = "materialsListBox";
			this.materialsListBox.Size = new System.Drawing.Size(171, 52);
			this.materialsListBox.TabIndex = 3;
			this.materialsListBox.SelectedIndexChanged += new System.EventHandler(this.materialsListBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(127, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Strut Materials";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 99);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(195, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Strut Cross Section (Meters ** 2)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(90, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Strut Length (Meters)";
			// 
			// lengthTextBox
			// 
			this.lengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lengthTextBox.Location = new System.Drawing.Point(226, 68);
			this.lengthTextBox.Name = "lengthTextBox";
			this.lengthTextBox.Size = new System.Drawing.Size(100, 22);
			this.lengthTextBox.TabIndex = 7;
			this.lengthTextBox.Text = "0.1";
			this.lengthTextBox.TextChanged += new System.EventHandler(this.lengthTextBox_TextChanged);
			// 
			// crossSectionTextBox
			// 
			this.crossSectionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.crossSectionTextBox.Location = new System.Drawing.Point(226, 96);
			this.crossSectionTextBox.Name = "crossSectionTextBox";
			this.crossSectionTextBox.Size = new System.Drawing.Size(100, 22);
			this.crossSectionTextBox.TabIndex = 8;
			this.crossSectionTextBox.Text = "0.001";
			this.crossSectionTextBox.TextChanged += new System.EventHandler(this.crossSectionTextBox_TextChanged);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(625, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Coolers";
			// 
			// coolersListBox
			// 
			this.coolersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.coolersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.coolersListBox.FormattingEnabled = true;
			this.coolersListBox.ItemHeight = 16;
			this.coolersListBox.Location = new System.Drawing.Point(686, 12);
			this.coolersListBox.Name = "coolersListBox";
			this.coolersListBox.Size = new System.Drawing.Size(171, 52);
			this.coolersListBox.TabIndex = 9;
			this.coolersListBox.SelectedIndexChanged += new System.EventHandler(this.coolersListBox_SelectedIndexChanged);
			// 
			// answerBox
			// 
			this.answerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.answerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.answerBox.Location = new System.Drawing.Point(690, 158);
			this.answerBox.Name = "answerBox";
			this.answerBox.Size = new System.Drawing.Size(167, 26);
			this.answerBox.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(512, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(172, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Steady State Temp (Deg K)";
			// 
			// coolerDataBox
			// 
			this.coolerDataBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.coolerDataBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.coolerDataBox.Location = new System.Drawing.Point(478, 247);
			this.coolerDataBox.Name = "coolerDataBox";
			this.coolerDataBox.Size = new System.Drawing.Size(379, 468);
			this.coolerDataBox.TabIndex = 13;
			this.coolerDataBox.Text = "";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(631, 228);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 14;
			this.label6.Text = "Cooler Data";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(178, 228);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 16);
			this.label7.TabIndex = 15;
			this.label7.Text = "Material Data";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(891, 724);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.coolerDataBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.answerBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.coolersListBox);
			this.Controls.Add(this.crossSectionTextBox);
			this.Controls.Add(this.lengthTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.materialsListBox);
			this.Controls.Add(this.simulateButton);
			this.Controls.Add(this.materialDataBox);
			this.Name = "MainForm";
			this.Text = "Cool It Desktop Application - Version 2";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox materialDataBox;
		private System.Windows.Forms.Button simulateButton;
		private System.Windows.Forms.ListBox materialsListBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox lengthTextBox;
		private System.Windows.Forms.TextBox crossSectionTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox coolersListBox;
		private System.Windows.Forms.TextBox answerBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox coolerDataBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
	}
}

