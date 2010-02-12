namespace MaterialProperties
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.plotSurface = new NPlot.Windows.PlotSurface2D();
			this.materialListBox = new System.Windows.Forms.ListBox();
			this.generateXmlButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.plotPage = new System.Windows.Forms.TabPage();
			this.tablePage = new System.Windows.Forms.TabPage();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.rawPriceTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tensileStrengthTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.idTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.scaledPriceTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.shearStrengthTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.compressionStrengthTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.youngsModulusTextBox = new System.Windows.Forms.TextBox();
			this.notUsableLabel = new System.Windows.Forms.Label();
			this.integratedCondCheckbox = new System.Windows.Forms.CheckBox();
			this.materialsCountLabel = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.plotPage.SuspendLayout();
			this.tablePage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// plotSurface
			// 
			this.plotSurface.AutoScaleAutoGeneratedAxes = false;
			this.plotSurface.AutoScaleTitle = false;
			this.plotSurface.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.plotSurface.DateTimeToolTip = false;
			this.plotSurface.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plotSurface.Legend = null;
			this.plotSurface.LegendZOrder = -1;
			this.plotSurface.Location = new System.Drawing.Point(3, 3);
			this.plotSurface.Name = "plotSurface";
			this.plotSurface.RightMenu = null;
			this.plotSurface.ShowCoordinates = true;
			this.plotSurface.Size = new System.Drawing.Size(862, 369);
			this.plotSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			this.plotSurface.TabIndex = 0;
			this.plotSurface.Text = "plotSurface2D1";
			this.plotSurface.Title = "";
			this.plotSurface.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.plotSurface.XAxis1 = null;
			this.plotSurface.XAxis2 = null;
			this.plotSurface.YAxis1 = null;
			this.plotSurface.YAxis2 = null;
			// 
			// materialListBox
			// 
			this.materialListBox.FormattingEnabled = true;
			this.materialListBox.Location = new System.Drawing.Point(2, 12);
			this.materialListBox.Name = "materialListBox";
			this.materialListBox.Size = new System.Drawing.Size(285, 108);
			this.materialListBox.TabIndex = 1;
			this.materialListBox.SelectedIndexChanged += new System.EventHandler(this.materialListBox_SelectedIndexChanged);
			// 
			// generateXmlButton
			// 
			this.generateXmlButton.Location = new System.Drawing.Point(177, 126);
			this.generateXmlButton.Name = "generateXmlButton";
			this.generateXmlButton.Size = new System.Drawing.Size(110, 27);
			this.generateXmlButton.TabIndex = 3;
			this.generateXmlButton.Text = "Generate XML";
			this.generateXmlButton.UseVisualStyleBackColor = true;
			this.generateXmlButton.Click += new System.EventHandler(this.generateXmlButton_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.plotPage);
			this.tabControl1.Controls.Add(this.tablePage);
			this.tabControl1.Location = new System.Drawing.Point(2, 177);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(876, 401);
			this.tabControl1.TabIndex = 4;
			// 
			// plotPage
			// 
			this.plotPage.Controls.Add(this.plotSurface);
			this.plotPage.Location = new System.Drawing.Point(4, 22);
			this.plotPage.Name = "plotPage";
			this.plotPage.Padding = new System.Windows.Forms.Padding(3);
			this.plotPage.Size = new System.Drawing.Size(868, 375);
			this.plotPage.TabIndex = 0;
			this.plotPage.Text = "Plot";
			this.plotPage.UseVisualStyleBackColor = true;
			// 
			// tablePage
			// 
			this.tablePage.Controls.Add(this.dataGridView);
			this.tablePage.Location = new System.Drawing.Point(4, 22);
			this.tablePage.Name = "tablePage";
			this.tablePage.Padding = new System.Windows.Forms.Padding(3);
			this.tablePage.Size = new System.Drawing.Size(868, 375);
			this.tablePage.TabIndex = 1;
			this.tablePage.Text = "Table";
			this.tablePage.UseVisualStyleBackColor = true;
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(3, 3);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(862, 369);
			this.dataGridView.TabIndex = 0;
			// 
			// rawPriceTextBox
			// 
			this.rawPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rawPriceTextBox.Location = new System.Drawing.Point(505, 38);
			this.rawPriceTextBox.Name = "rawPriceTextBox";
			this.rawPriceTextBox.Size = new System.Drawing.Size(98, 20);
			this.rawPriceTextBox.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(431, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "Raw Price";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(395, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Tensile Strength";
			// 
			// tensileStrengthTextBox
			// 
			this.tensileStrengthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tensileStrengthTextBox.Location = new System.Drawing.Point(505, 65);
			this.tensileStrengthTextBox.Name = "tensileStrengthTextBox";
			this.tensileStrengthTextBox.Size = new System.Drawing.Size(98, 20);
			this.tensileStrengthTextBox.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(454, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "Name";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nameTextBox.Location = new System.Drawing.Point(505, 11);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(98, 20);
			this.nameTextBox.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(733, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "ID";
			// 
			// idTextBox
			// 
			this.idTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.idTextBox.Location = new System.Drawing.Point(760, 11);
			this.idTextBox.Name = "idTextBox";
			this.idTextBox.Size = new System.Drawing.Size(98, 20);
			this.idTextBox.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(669, 42);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 16);
			this.label5.TabIndex = 14;
			this.label5.Text = "Scaled Price";
			// 
			// scaledPriceTextBox
			// 
			this.scaledPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.scaledPriceTextBox.Location = new System.Drawing.Point(760, 38);
			this.scaledPriceTextBox.Name = "scaledPriceTextBox";
			this.scaledPriceTextBox.Size = new System.Drawing.Size(98, 20);
			this.scaledPriceTextBox.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(658, 69);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "Shear Strength";
			// 
			// shearStrengthTextBox
			// 
			this.shearStrengthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.shearStrengthTextBox.Location = new System.Drawing.Point(760, 65);
			this.shearStrengthTextBox.Name = "shearStrengthTextBox";
			this.shearStrengthTextBox.Size = new System.Drawing.Size(98, 20);
			this.shearStrengthTextBox.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(360, 96);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(140, 16);
			this.label7.TabIndex = 18;
			this.label7.Text = "Compression Strength";
			// 
			// compressionStrengthTextBox
			// 
			this.compressionStrengthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.compressionStrengthTextBox.Location = new System.Drawing.Point(505, 92);
			this.compressionStrengthTextBox.Name = "compressionStrengthTextBox";
			this.compressionStrengthTextBox.Size = new System.Drawing.Size(98, 20);
			this.compressionStrengthTextBox.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(643, 96);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(111, 16);
			this.label8.TabIndex = 20;
			this.label8.Text = "Young\'s Modulus";
			// 
			// youngsModulusTextBox
			// 
			this.youngsModulusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.youngsModulusTextBox.Location = new System.Drawing.Point(760, 92);
			this.youngsModulusTextBox.Name = "youngsModulusTextBox";
			this.youngsModulusTextBox.Size = new System.Drawing.Size(98, 20);
			this.youngsModulusTextBox.TabIndex = 19;
			// 
			// notUsableLabel
			// 
			this.notUsableLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.notUsableLabel.AutoSize = true;
			this.notUsableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
							| System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.notUsableLabel.ForeColor = System.Drawing.Color.Red;
			this.notUsableLabel.Location = new System.Drawing.Point(501, 154);
			this.notUsableLabel.Name = "notUsableLabel";
			this.notUsableLabel.Size = new System.Drawing.Size(330, 20);
			this.notUsableLabel.TabIndex = 21;
			this.notUsableLabel.Text = "Not usable in game due to missing data!";
			this.notUsableLabel.Visible = false;
			// 
			// integratedCondCheckbox
			// 
			this.integratedCondCheckbox.AutoSize = true;
			this.integratedCondCheckbox.Location = new System.Drawing.Point(505, 126);
			this.integratedCondCheckbox.Name = "integratedCondCheckbox";
			this.integratedCondCheckbox.Size = new System.Drawing.Size(161, 17);
			this.integratedCondCheckbox.TabIndex = 22;
			this.integratedCondCheckbox.Text = "Integrated Conductivity Data";
			this.integratedCondCheckbox.UseVisualStyleBackColor = true;
			// 
			// materialsCountLabel
			// 
			this.materialsCountLabel.AutoSize = true;
			this.materialsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.materialsCountLabel.Location = new System.Drawing.Point(12, 131);
			this.materialsCountLabel.Name = "materialsCountLabel";
			this.materialsCountLabel.Size = new System.Drawing.Size(155, 16);
			this.materialsCountLabel.TabIndex = 23;
			this.materialsCountLabel.Text = "XX materials (YY usable)";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(890, 590);
			this.Controls.Add(this.materialsCountLabel);
			this.Controls.Add(this.integratedCondCheckbox);
			this.Controls.Add(this.notUsableLabel);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.youngsModulusTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.compressionStrengthTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.shearStrengthTextBox);
			this.Controls.Add(this.generateXmlButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.scaledPriceTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.idTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tensileStrengthTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rawPriceTextBox);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.materialListBox);
			this.Name = "Form1";
			this.Text = "Thermal Conductivity Curve Generator";
			this.tabControl1.ResumeLayout(false);
			this.plotPage.ResumeLayout(false);
			this.tablePage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private NPlot.Windows.PlotSurface2D plotSurface;
		private System.Windows.Forms.ListBox materialListBox;
		private System.Windows.Forms.Button generateXmlButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage plotPage;
		private System.Windows.Forms.TabPage tablePage;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.TextBox rawPriceTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tensileStrengthTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox idTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox scaledPriceTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox shearStrengthTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox compressionStrengthTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox youngsModulusTextBox;
		private System.Windows.Forms.Label notUsableLabel;
		private System.Windows.Forms.CheckBox integratedCondCheckbox;
		private System.Windows.Forms.Label materialsCountLabel;
    }
}
