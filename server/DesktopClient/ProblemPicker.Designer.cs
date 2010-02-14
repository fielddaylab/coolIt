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
            this.dgStruts = new System.Windows.Forms.DataGridView();
            this.lblStruts = new System.Windows.Forms.Label();
            this.dgCoolers = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.dgStrutConstraint = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCoolerConstraint = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.constraintGridView)).BeginInit();
            this.imageChooserGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStruts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCoolers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStrutConstraint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCoolerConstraint)).BeginInit();
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
            this.descriptionTextBox.Size = new System.Drawing.Size(729, 100);
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
            this.label3.Location = new System.Drawing.Point(-14, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Images";
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(1008, 187);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(95, 22);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(1008, 158);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 22);
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
            this.constraintGridView.Location = new System.Drawing.Point(382, 160);
            this.constraintGridView.Name = "constraintGridView";
            this.constraintGridView.Size = new System.Drawing.Size(370, 105);
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
            this.label4.Location = new System.Drawing.Point(379, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Problem Constraints";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(769, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Number of Struts:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // strutNumberTextBox
            // 
            this.strutNumberTextBox.Location = new System.Drawing.Point(864, 160);
            this.strutNumberTextBox.Name = "strutNumberTextBox";
            this.strutNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.strutNumberTextBox.TabIndex = 14;
            // 
            // monetaryIncentiveLabel
            // 
            this.monetaryIncentiveLabel.AutoSize = true;
            this.monetaryIncentiveLabel.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monetaryIncentiveLabel.Location = new System.Drawing.Point(801, 187);
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
            // dgStruts
            // 
            this.dgStruts.AllowUserToAddRows = false;
            this.dgStruts.AllowUserToDeleteRows = false;
            this.dgStruts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStruts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgStruts.Location = new System.Drawing.Point(379, 289);
            this.dgStruts.Name = "dgStruts";
            this.dgStruts.ReadOnly = true;
            this.dgStruts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStruts.Size = new System.Drawing.Size(373, 96);
            this.dgStruts.TabIndex = 17;
            this.dgStruts.SelectionChanged += new System.EventHandler(this.dgStruts_SelectedIndexChanged);
            // 
            // lblStruts
            // 
            this.lblStruts.AutoSize = true;
            this.lblStruts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStruts.Location = new System.Drawing.Point(376, 270);
            this.lblStruts.Name = "lblStruts";
            this.lblStruts.Size = new System.Drawing.Size(229, 16);
            this.lblStruts.TabIndex = 16;
            this.lblStruts.Text = "Struts (select one to show constraints)";
            // 
            // dgCoolers
            // 
            this.dgCoolers.AllowUserToAddRows = false;
            this.dgCoolers.AllowUserToDeleteRows = false;
            this.dgCoolers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCoolers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgCoolers.Location = new System.Drawing.Point(378, 408);
            this.dgCoolers.Name = "dgCoolers";
            this.dgCoolers.ReadOnly = true;
            this.dgCoolers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCoolers.Size = new System.Drawing.Size(374, 107);
            this.dgCoolers.TabIndex = 19;
            this.dgCoolers.SelectionChanged += new System.EventHandler(this.dgCooler_SelectionChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(375, 389);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(243, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Coolers (select one to show constraints)";
            // 
            // dgStrutConstraint
            // 
            this.dgStrutConstraint.AllowUserToAddRows = false;
            this.dgStrutConstraint.AllowUserToDeleteRows = false;
            this.dgStrutConstraint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStrutConstraint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgStrutConstraint.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgStrutConstraint.Location = new System.Drawing.Point(758, 289);
            this.dgStrutConstraint.Name = "dgStrutConstraint";
            this.dgStrutConstraint.ReadOnly = true;
            this.dgStrutConstraint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStrutConstraint.Size = new System.Drawing.Size(370, 96);
            this.dgStrutConstraint.TabIndex = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Value";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Op";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 25;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Limit";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dgCoolerConstraint
            // 
            this.dgCoolerConstraint.AllowUserToAddRows = false;
            this.dgCoolerConstraint.AllowUserToDeleteRows = false;
            this.dgCoolerConstraint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCoolerConstraint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgCoolerConstraint.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgCoolerConstraint.Location = new System.Drawing.Point(758, 408);
            this.dgCoolerConstraint.MultiSelect = false;
            this.dgCoolerConstraint.Name = "dgCoolerConstraint";
            this.dgCoolerConstraint.ReadOnly = true;
            this.dgCoolerConstraint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCoolerConstraint.Size = new System.Drawing.Size(370, 107);
            this.dgCoolerConstraint.TabIndex = 21;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Value";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Op";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 25;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Limit";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // ChallengePicker
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1136, 545);
            this.Controls.Add(this.dgCoolerConstraint);
            this.Controls.Add(this.dgStrutConstraint);
            this.Controls.Add(this.dgCoolers);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgStruts);
            this.Controls.Add(this.lblStruts);
            this.Controls.Add(this.imageChooserGroupBox);
            this.Controls.Add(this.strutNumberTextBox);
            this.Controls.Add(this.monetaryIncentiveLabel);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgStruts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCoolers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgStrutConstraint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCoolerConstraint)).EndInit();
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
        private System.Windows.Forms.DataGridView dgStruts;
        private System.Windows.Forms.Label lblStruts;
        private System.Windows.Forms.DataGridView dgCoolers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgStrutConstraint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dgCoolerConstraint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
	}
}