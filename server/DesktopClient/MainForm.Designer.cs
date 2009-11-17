namespace DesktopClient {
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
			this.temperatureBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.choosersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.problemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.coolersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.strutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sketchPadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.heatLeakVisualizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chooseStrutButton = new System.Windows.Forms.Button();
			this.chooseCoolerButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.costBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.inputPowerBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.stressLimitTextBox = new System.Windows.Forms.TextBox();
			this.challengeNameTextBox = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.commitButton = new System.Windows.Forms.Button();
			this.bankBalanceTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.incentiveTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// temperatureBox
			// 
			this.temperatureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.temperatureBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.temperatureBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.temperatureBox.ForeColor = System.Drawing.Color.Red;
			this.temperatureBox.Location = new System.Drawing.Point(12, 419);
			this.temperatureBox.Name = "temperatureBox";
			this.temperatureBox.Size = new System.Drawing.Size(138, 19);
			this.temperatureBox.TabIndex = 11;
			this.temperatureBox.Text = "n/a";
			this.temperatureBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.temperatureBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stressLimitTextBox_KeyPress);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(58, 400);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Temp (K)";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.choosersToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(625, 24);
			this.menuStrip1.TabIndex = 29;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// choosersToolStripMenuItem
			// 
			this.choosersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.problemToolStripMenuItem,
            this.coolersToolStripMenuItem,
            this.strutsToolStripMenuItem});
			this.choosersToolStripMenuItem.Name = "choosersToolStripMenuItem";
			this.choosersToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.choosersToolStripMenuItem.Text = "&Choose";
			// 
			// problemToolStripMenuItem
			// 
			this.problemToolStripMenuItem.Name = "problemToolStripMenuItem";
			this.problemToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.problemToolStripMenuItem.Text = "&Challenge";
			this.problemToolStripMenuItem.Click += new System.EventHandler(this.problemToolStripMenuItem_Click);
			// 
			// coolersToolStripMenuItem
			// 
			this.coolersToolStripMenuItem.Name = "coolersToolStripMenuItem";
			this.coolersToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.coolersToolStripMenuItem.Text = "C&ooler";
			this.coolersToolStripMenuItem.Click += new System.EventHandler(this.coolersToolStripMenuItem_Click);
			// 
			// strutsToolStripMenuItem
			// 
			this.strutsToolStripMenuItem.Name = "strutsToolStripMenuItem";
			this.strutsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.strutsToolStripMenuItem.Text = "&Strut";
			this.strutsToolStripMenuItem.Click += new System.EventHandler(this.strutsToolStripMenuItem_Click);
			// 
			// ToolsToolStripMenuItem
			// 
			this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sketchPadToolStripMenuItem,
            this.heatLeakVisualizerToolStripMenuItem});
			this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
			this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.ToolsToolStripMenuItem.Text = "&Tools";
			// 
			// sketchPadToolStripMenuItem
			// 
			this.sketchPadToolStripMenuItem.Name = "sketchPadToolStripMenuItem";
			this.sketchPadToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.sketchPadToolStripMenuItem.Text = "&SketchPad";
			this.sketchPadToolStripMenuItem.Click += new System.EventHandler(this.sketchPadToolStripMenuItem_Click);
			// 
			// heatLeakVisualizerToolStripMenuItem
			// 
			this.heatLeakVisualizerToolStripMenuItem.Name = "heatLeakVisualizerToolStripMenuItem";
			this.heatLeakVisualizerToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.heatLeakVisualizerToolStripMenuItem.Text = "&Heat Leak Visualizer";
			this.heatLeakVisualizerToolStripMenuItem.Click += new System.EventHandler(this.heatLeakVisualizerToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// chooseStrutButton
			// 
			this.chooseStrutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chooseStrutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chooseStrutButton.Location = new System.Drawing.Point(517, 55);
			this.chooseStrutButton.Name = "chooseStrutButton";
			this.chooseStrutButton.Size = new System.Drawing.Size(96, 41);
			this.chooseStrutButton.TabIndex = 31;
			this.chooseStrutButton.Text = "Choose Strut";
			this.chooseStrutButton.UseVisualStyleBackColor = true;
			this.chooseStrutButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// chooseCoolerButton
			// 
			this.chooseCoolerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chooseCoolerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chooseCoolerButton.Location = new System.Drawing.Point(517, 102);
			this.chooseCoolerButton.Name = "chooseCoolerButton";
			this.chooseCoolerButton.Size = new System.Drawing.Size(96, 41);
			this.chooseCoolerButton.TabIndex = 32;
			this.chooseCoolerButton.Text = "Choose Cooler";
			this.chooseCoolerButton.UseVisualStyleBackColor = true;
			this.chooseCoolerButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(228, 318);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 16);
			this.label1.TabIndex = 34;
			this.label1.Text = "Cost (Dollars)";
			// 
			// costBox
			// 
			this.costBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.costBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.costBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.costBox.Location = new System.Drawing.Point(179, 337);
			this.costBox.Name = "costBox";
			this.costBox.Size = new System.Drawing.Size(138, 19);
			this.costBox.TabIndex = 33;
			this.costBox.Text = "n/a";
			this.costBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.costBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stressLimitTextBox_KeyPress);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(28, 359);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 16);
			this.label2.TabIndex = 36;
			this.label2.Text = "Input Power (W)";
			// 
			// inputPowerBox
			// 
			this.inputPowerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.inputPowerBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.inputPowerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inputPowerBox.ForeColor = System.Drawing.Color.Red;
			this.inputPowerBox.Location = new System.Drawing.Point(12, 378);
			this.inputPowerBox.Name = "inputPowerBox";
			this.inputPowerBox.Size = new System.Drawing.Size(138, 19);
			this.inputPowerBox.TabIndex = 35;
			this.inputPowerBox.Text = "n/a";
			this.inputPowerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.inputPowerBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stressLimitTextBox_KeyPress);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 318);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 16);
			this.label3.TabIndex = 38;
			this.label3.Text = "Maximum Stress (MN)";
			// 
			// stressLimitTextBox
			// 
			this.stressLimitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.stressLimitTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.stressLimitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stressLimitTextBox.ForeColor = System.Drawing.Color.Red;
			this.stressLimitTextBox.Location = new System.Drawing.Point(12, 337);
			this.stressLimitTextBox.Name = "stressLimitTextBox";
			this.stressLimitTextBox.Size = new System.Drawing.Size(138, 19);
			this.stressLimitTextBox.TabIndex = 37;
			this.stressLimitTextBox.Text = "n/a";
			this.stressLimitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.stressLimitTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stressLimitTextBox_KeyPress);
			// 
			// challengeNameTextBox
			// 
			this.challengeNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.challengeNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.challengeNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.challengeNameTextBox.Location = new System.Drawing.Point(80, 256);
			this.challengeNameTextBox.Name = "challengeNameTextBox";
			this.challengeNameTextBox.Size = new System.Drawing.Size(344, 22);
			this.challengeNameTextBox.TabIndex = 39;
			this.challengeNameTextBox.Text = "Problem Name";
			this.challengeNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.challengeNameTextBox);
			this.panel1.Location = new System.Drawing.Point(0, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(511, 288);
			this.panel1.TabIndex = 40;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(4, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(504, 247);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 30;
			this.pictureBox1.TabStop = false;
			// 
			// commitButton
			// 
			this.commitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.commitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.commitButton.Location = new System.Drawing.Point(519, 274);
			this.commitButton.Name = "commitButton";
			this.commitButton.Size = new System.Drawing.Size(96, 41);
			this.commitButton.TabIndex = 41;
			this.commitButton.Text = "Commit";
			this.commitButton.UseVisualStyleBackColor = true;
			this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
			// 
			// bankBalanceTextBox
			// 
			this.bankBalanceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bankBalanceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.bankBalanceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.bankBalanceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bankBalanceTextBox.Location = new System.Drawing.Point(373, 378);
			this.bankBalanceTextBox.Name = "bankBalanceTextBox";
			this.bankBalanceTextBox.Size = new System.Drawing.Size(138, 19);
			this.bankBalanceTextBox.TabIndex = 11;
			this.bankBalanceTextBox.Text = "$0.00";
			this.bankBalanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.bankBalanceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stressLimitTextBox_KeyPress);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(419, 359);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "Bank Balance";
			// 
			// incentiveTextBox
			// 
			this.incentiveTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.incentiveTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.incentiveTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.incentiveTextBox.Location = new System.Drawing.Point(372, 337);
			this.incentiveTextBox.Name = "incentiveTextBox";
			this.incentiveTextBox.Size = new System.Drawing.Size(138, 19);
			this.incentiveTextBox.TabIndex = 11;
			this.incentiveTextBox.Text = "n/a";
			this.incentiveTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.incentiveTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stressLimitTextBox_KeyPress);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(449, 318);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 16);
			this.label6.TabIndex = 12;
			this.label6.Text = "Incentive";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(625, 445);
			this.Controls.Add(this.commitButton);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.stressLimitTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.inputPowerBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.costBox);
			this.Controls.Add(this.chooseCoolerButton);
			this.Controls.Add(this.chooseStrutButton);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.incentiveTextBox);
			this.Controls.Add(this.bankBalanceTextBox);
			this.Controls.Add(this.temperatureBox);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(640, 400);
			this.Name = "MainForm";
			this.Text = "Cool It Desktop Client - Version 2";
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox temperatureBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem choosersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem coolersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem strutsToolStripMenuItem;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button chooseStrutButton;
		private System.Windows.Forms.Button chooseCoolerButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox costBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox inputPowerBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox stressLimitTextBox;
		private System.Windows.Forms.ToolStripMenuItem problemToolStripMenuItem;
		private System.Windows.Forms.TextBox challengeNameTextBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button commitButton;
		private System.Windows.Forms.TextBox bankBalanceTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox incentiveTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolStripMenuItem sketchPadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem heatLeakVisualizerToolStripMenuItem;
	}
}

