namespace DesktopClient {
	partial class ChallengePicker {
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
			this.problemsListBox = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.imageViewer = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.alreadySolvedLabel = new System.Windows.Forms.Label();
			this.constraintGridView = new System.Windows.Forms.DataGridView();
			this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.opColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.limitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.strutNumberTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.heatLeakTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.supportModeTextBox = new System.Windows.Forms.TextBox();
			this.monetaryIncentiveLabel = new System.Windows.Forms.Label();
			this.imageChooserGroupBox = new System.Windows.Forms.GroupBox();
			this.lengthUpDown = new System.Windows.Forms.NumericUpDown();
			this.widthUpDown = new System.Windows.Forms.NumericUpDown();
			this.pickerImageRadioButton = new System.Windows.Forms.RadioButton();
			this.failStrutBreaksRadioButton = new System.Windows.Forms.RadioButton();
			this.failPowerLimitRadioButton = new System.Windows.Forms.RadioButton();
			this.failTooHotRadioButton = new System.Windows.Forms.RadioButton();
			this.successRadioButton = new System.Windows.Forms.RadioButton();
			this.introRadioButton = new System.Windows.Forms.RadioButton();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imageViewer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.constraintGridView)).BeginInit();
			this.imageChooserGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lengthUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// problemsListBox
			// 
			this.problemsListBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.problemsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.problemsListBox.FormattingEnabled = true;
			this.problemsListBox.ItemHeight = 16;
			this.problemsListBox.Location = new System.Drawing.Point(15, 28);
			this.problemsListBox.Name = "problemsListBox";
			this.problemsListBox.Size = new System.Drawing.Size(334, 100);
			this.problemsListBox.TabIndex = 0;
			this.problemsListBox.SelectedIndexChanged += new System.EventHandler(this.problemsListBox_SelectedIndexChanged);
			this.problemsListBox.Leave += new System.EventHandler(this.listBox_FocusChanged);
			this.problemsListBox.Enter += new System.EventHandler(this.listBox_FocusChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Challenges";
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.descriptionTextBox.Location = new System.Drawing.Point(382, 28);
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.Size = new System.Drawing.Size(582, 253);
			this.descriptionTextBox.TabIndex = 2;
			this.descriptionTextBox.TabStop = false;
			this.descriptionTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(379, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Description";
			// 
			// imageViewer
			// 
			this.imageViewer.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.imageViewer.Location = new System.Drawing.Point(12, 159);
			this.imageViewer.Name = "imageViewer";
			this.imageViewer.Size = new System.Drawing.Size(337, 248);
			this.imageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imageViewer.TabIndex = 4;
			this.imageViewer.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(-161, 418);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Images";
			// 
			// okButton
			// 
			this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okButton.Location = new System.Drawing.Point(869, 510);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(95, 23);
			this.okButton.TabIndex = 9;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelButton.Location = new System.Drawing.Point(869, 481);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(95, 23);
			this.cancelButton.TabIndex = 10;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// alreadySolvedLabel
			// 
			this.alreadySolvedLabel.AutoSize = true;
			this.alreadySolvedLabel.Location = new System.Drawing.Point(268, 131);
			this.alreadySolvedLabel.Name = "alreadySolvedLabel";
			this.alreadySolvedLabel.Size = new System.Drawing.Size(81, 13);
			this.alreadySolvedLabel.TabIndex = 11;
			this.alreadySolvedLabel.Text = "(already solved)";
			// 
			// constraintGridView
			// 
			this.constraintGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.constraintGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valueColumn,
            this.opColumn,
            this.limitColumn,
            this.unitsColumn});
			this.constraintGridView.Location = new System.Drawing.Point(382, 316);
			this.constraintGridView.Name = "constraintGridView";
			this.constraintGridView.Size = new System.Drawing.Size(370, 217);
			this.constraintGridView.TabIndex = 12;
			// 
			// valueColumn
			// 
			this.valueColumn.HeaderText = "Value";
			this.valueColumn.Name = "valueColumn";
			this.valueColumn.Width = 125;
			// 
			// opColumn
			// 
			this.opColumn.HeaderText = "Op";
			this.opColumn.Name = "opColumn";
			this.opColumn.Width = 25;
			// 
			// limitColumn
			// 
			this.limitColumn.HeaderText = "Limit";
			this.limitColumn.Name = "limitColumn";
			this.limitColumn.Width = 50;
			// 
			// unitsColumn
			// 
			this.unitsColumn.HeaderText = "Unit";
			this.unitsColumn.Name = "unitsColumn";
			this.unitsColumn.Width = 125;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(379, 297);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Constraints";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(769, 312);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Number of Struts:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// strutNumberTextBox
			// 
			this.strutNumberTextBox.Location = new System.Drawing.Point(864, 309);
			this.strutNumberTextBox.Name = "strutNumberTextBox";
			this.strutNumberTextBox.Size = new System.Drawing.Size(100, 20);
			this.strutNumberTextBox.TabIndex = 14;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(769, 341);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Static Heat Leak:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// heatLeakTextBox
			// 
			this.heatLeakTextBox.Location = new System.Drawing.Point(864, 338);
			this.heatLeakTextBox.Name = "heatLeakTextBox";
			this.heatLeakTextBox.Size = new System.Drawing.Size(47, 20);
			this.heatLeakTextBox.TabIndex = 14;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(769, 371);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Support Mode:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// supportModeTextBox
			// 
			this.supportModeTextBox.Location = new System.Drawing.Point(864, 368);
			this.supportModeTextBox.Name = "supportModeTextBox";
			this.supportModeTextBox.Size = new System.Drawing.Size(100, 20);
			this.supportModeTextBox.TabIndex = 14;
			// 
			// monetaryIncentiveLabel
			// 
			this.monetaryIncentiveLabel.AutoSize = true;
			this.monetaryIncentiveLabel.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.monetaryIncentiveLabel.Location = new System.Drawing.Point(801, 418);
			this.monetaryIncentiveLabel.Name = "monetaryIncentiveLabel";
			this.monetaryIncentiveLabel.Size = new System.Drawing.Size(163, 35);
			this.monetaryIncentiveLabel.TabIndex = 13;
			this.monetaryIncentiveLabel.Text = "$1,000,000";
			this.monetaryIncentiveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// imageChooserGroupBox
			// 
			this.imageChooserGroupBox.Controls.Add(this.lengthUpDown);
			this.imageChooserGroupBox.Controls.Add(this.widthUpDown);
			this.imageChooserGroupBox.Controls.Add(this.pickerImageRadioButton);
			this.imageChooserGroupBox.Controls.Add(this.failStrutBreaksRadioButton);
			this.imageChooserGroupBox.Controls.Add(this.failPowerLimitRadioButton);
			this.imageChooserGroupBox.Controls.Add(this.failTooHotRadioButton);
			this.imageChooserGroupBox.Controls.Add(this.successRadioButton);
			this.imageChooserGroupBox.Controls.Add(this.introRadioButton);
			this.imageChooserGroupBox.Location = new System.Drawing.Point(12, 418);
			this.imageChooserGroupBox.Name = "imageChooserGroupBox";
			this.imageChooserGroupBox.Size = new System.Drawing.Size(337, 115);
			this.imageChooserGroupBox.TabIndex = 15;
			this.imageChooserGroupBox.TabStop = false;
			this.imageChooserGroupBox.Text = "Image Chooser";
			// 
			// lengthUpDown
			// 
			this.lengthUpDown.Location = new System.Drawing.Point(204, 86);
			this.lengthUpDown.Name = "lengthUpDown";
			this.lengthUpDown.Size = new System.Drawing.Size(63, 20);
			this.lengthUpDown.TabIndex = 8;
			this.lengthUpDown.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
			// 
			// widthUpDown
			// 
			this.widthUpDown.Location = new System.Drawing.Point(135, 86);
			this.widthUpDown.Name = "widthUpDown";
			this.widthUpDown.Size = new System.Drawing.Size(63, 20);
			this.widthUpDown.TabIndex = 7;
			this.widthUpDown.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
			// 
			// pickerImageRadioButton
			// 
			this.pickerImageRadioButton.AutoSize = true;
			this.pickerImageRadioButton.Location = new System.Drawing.Point(22, 86);
			this.pickerImageRadioButton.Name = "pickerImageRadioButton";
			this.pickerImageRadioButton.Size = new System.Drawing.Size(111, 17);
			this.pickerImageRadioButton.TabIndex = 5;
			this.pickerImageRadioButton.TabStop = true;
			this.pickerImageRadioButton.Text = "Picker Image [0,0]";
			this.pickerImageRadioButton.UseVisualStyleBackColor = true;
			this.pickerImageRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// failStrutBreaksRadioButton
			// 
			this.failStrutBreaksRadioButton.AutoSize = true;
			this.failStrutBreaksRadioButton.Location = new System.Drawing.Point(158, 43);
			this.failStrutBreaksRadioButton.Name = "failStrutBreaksRadioButton";
			this.failStrutBreaksRadioButton.Size = new System.Drawing.Size(83, 17);
			this.failStrutBreaksRadioButton.TabIndex = 4;
			this.failStrutBreaksRadioButton.TabStop = true;
			this.failStrutBreaksRadioButton.Text = "Strut Breaks";
			this.failStrutBreaksRadioButton.UseVisualStyleBackColor = true;
			this.failStrutBreaksRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// failPowerLimitRadioButton
			// 
			this.failPowerLimitRadioButton.AutoSize = true;
			this.failPowerLimitRadioButton.Location = new System.Drawing.Point(22, 63);
			this.failPowerLimitRadioButton.Name = "failPowerLimitRadioButton";
			this.failPowerLimitRadioButton.Size = new System.Drawing.Size(130, 17);
			this.failPowerLimitRadioButton.TabIndex = 3;
			this.failPowerLimitRadioButton.TabStop = true;
			this.failPowerLimitRadioButton.Text = "Power Limit Exceeded";
			this.failPowerLimitRadioButton.UseVisualStyleBackColor = true;
			this.failPowerLimitRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// failTooHotRadioButton
			// 
			this.failTooHotRadioButton.AutoSize = true;
			this.failTooHotRadioButton.Location = new System.Drawing.Point(158, 20);
			this.failTooHotRadioButton.Name = "failTooHotRadioButton";
			this.failTooHotRadioButton.Size = new System.Drawing.Size(127, 17);
			this.failTooHotRadioButton.TabIndex = 2;
			this.failTooHotRadioButton.TabStop = true;
			this.failTooHotRadioButton.Text = "Temp Limit Exceeded";
			this.failTooHotRadioButton.UseVisualStyleBackColor = true;
			this.failTooHotRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// successRadioButton
			// 
			this.successRadioButton.AutoSize = true;
			this.successRadioButton.Location = new System.Drawing.Point(22, 43);
			this.successRadioButton.Name = "successRadioButton";
			this.successRadioButton.Size = new System.Drawing.Size(66, 17);
			this.successRadioButton.TabIndex = 1;
			this.successRadioButton.TabStop = true;
			this.successRadioButton.Text = "Success";
			this.successRadioButton.UseVisualStyleBackColor = true;
			this.successRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// introRadioButton
			// 
			this.introRadioButton.AutoSize = true;
			this.introRadioButton.Location = new System.Drawing.Point(22, 20);
			this.introRadioButton.Name = "introRadioButton";
			this.introRadioButton.Size = new System.Drawing.Size(46, 17);
			this.introRadioButton.TabIndex = 0;
			this.introRadioButton.TabStop = true;
			this.introRadioButton.Text = "Intro";
			this.introRadioButton.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(914, 341);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(55, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Watts (W)";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ChallengePicker
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(989, 545);
			this.Controls.Add(this.imageChooserGroupBox);
			this.Controls.Add(this.supportModeTextBox);
			this.Controls.Add(this.heatLeakTextBox);
			this.Controls.Add(this.strutNumberTextBox);
			this.Controls.Add(this.monetaryIncentiveLabel);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.constraintGridView);
			this.Controls.Add(this.alreadySolvedLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.imageViewer);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.descriptionTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.problemsListBox);
			this.Name = "ChallengePicker";
			this.Text = "Challenge Picker";
			this.Shown += new System.EventHandler(this.ProblemPicker_Shown);
			((System.ComponentModel.ISupportInitialize)(this.imageViewer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.constraintGridView)).EndInit();
			this.imageChooserGroupBox.ResumeLayout(false);
			this.imageChooserGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.lengthUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox problemsListBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox descriptionTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox imageViewer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label alreadySolvedLabel;
		private System.Windows.Forms.DataGridView constraintGridView;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox strutNumberTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox heatLeakTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox supportModeTextBox;
		private System.Windows.Forms.Label monetaryIncentiveLabel;
		private System.Windows.Forms.GroupBox imageChooserGroupBox;
		private System.Windows.Forms.NumericUpDown lengthUpDown;
		private System.Windows.Forms.NumericUpDown widthUpDown;
		private System.Windows.Forms.RadioButton pickerImageRadioButton;
		private System.Windows.Forms.RadioButton failStrutBreaksRadioButton;
		private System.Windows.Forms.RadioButton failPowerLimitRadioButton;
		private System.Windows.Forms.RadioButton failTooHotRadioButton;
		private System.Windows.Forms.RadioButton successRadioButton;
		private System.Windows.Forms.RadioButton introRadioButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn opColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn limitColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn unitsColumn;
		private System.Windows.Forms.Label label8;
	}
}