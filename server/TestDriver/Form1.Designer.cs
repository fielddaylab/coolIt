namespace TestDriver {
	partial class Form1 {
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
            this.loginButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.userListGrid = new System.Windows.Forms.DataGridView();
            this.initDbButton = new System.Windows.Forms.Button();
            this.episodesListGrid = new System.Windows.Forms.DataGridView();
            this.newLoginButton = new System.Windows.Forms.Button();
            this.problemsListBox = new System.Windows.Forms.ListBox();
            this.problemButton = new System.Windows.Forms.Button();
            this.setStateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statesListGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDBSuccess = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodesListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statesListGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(172, 43);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(56, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(59, 17);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(169, 20);
            this.emailTextBox.TabIndex = 2;
            this.emailTextBox.Text = "<mlitzkow@wisc.edu>";
            // 
            // userListGrid
            // 
            this.userListGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userListGrid.Location = new System.Drawing.Point(3, 159);
            this.userListGrid.Name = "userListGrid";
            this.userListGrid.Size = new System.Drawing.Size(426, 389);
            this.userListGrid.TabIndex = 4;
            this.userListGrid.SelectionChanged += new System.EventHandler(this.userListGrid_SelectionChanged);
            // 
            // initDbButton
            // 
            this.initDbButton.Location = new System.Drawing.Point(623, 17);
            this.initDbButton.Name = "initDbButton";
            this.initDbButton.Size = new System.Drawing.Size(95, 23);
            this.initDbButton.TabIndex = 6;
            this.initDbButton.Text = "Init Database";
            this.initDbButton.UseVisualStyleBackColor = true;
            this.initDbButton.Click += new System.EventHandler(this.initDbButton_Click);
            // 
            // episodesListGrid
            // 
            this.episodesListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.episodesListGrid.Location = new System.Drawing.Point(444, 159);
            this.episodesListGrid.Name = "episodesListGrid";
            this.episodesListGrid.Size = new System.Drawing.Size(363, 386);
            this.episodesListGrid.TabIndex = 7;
            this.episodesListGrid.SelectionChanged += new System.EventHandler(this.episodesListGrid_SelectionChanged);
            // 
            // newLoginButton
            // 
            this.newLoginButton.Location = new System.Drawing.Point(59, 43);
            this.newLoginButton.Name = "newLoginButton";
            this.newLoginButton.Size = new System.Drawing.Size(106, 23);
            this.newLoginButton.TabIndex = 0;
            this.newLoginButton.Text = "Create Account";
            this.newLoginButton.UseVisualStyleBackColor = true;
            this.newLoginButton.Click += new System.EventHandler(this.newLoginButton_Click);
            // 
            // problemsListBox
            // 
            this.problemsListBox.FormattingEnabled = true;
            this.problemsListBox.Location = new System.Drawing.Point(248, 17);
            this.problemsListBox.Name = "problemsListBox";
            this.problemsListBox.Size = new System.Drawing.Size(203, 95);
            this.problemsListBox.TabIndex = 8;
            // 
            // problemButton
            // 
            this.problemButton.Location = new System.Drawing.Point(460, 17);
            this.problemButton.Name = "problemButton";
            this.problemButton.Size = new System.Drawing.Size(75, 23);
            this.problemButton.TabIndex = 9;
            this.problemButton.Text = "Set Problem";
            this.problemButton.UseVisualStyleBackColor = true;
            this.problemButton.Click += new System.EventHandler(this.problemButton_Click);
            // 
            // setStateButton
            // 
            this.setStateButton.Location = new System.Drawing.Point(460, 43);
            this.setStateButton.Name = "setStateButton";
            this.setStateButton.Size = new System.Drawing.Size(75, 23);
            this.setStateButton.TabIndex = 9;
            this.setStateButton.Text = "Set State";
            this.setStateButton.UseVisualStyleBackColor = true;
            this.setStateButton.Click += new System.EventHandler(this.setStateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(441, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Episodes";
            // 
            // statesListGrid
            // 
            this.statesListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statesListGrid.Location = new System.Drawing.Point(829, 162);
            this.statesListGrid.Name = "statesListGrid";
            this.statesListGrid.Size = new System.Drawing.Size(154, 382);
            this.statesListGrid.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(826, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "States";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "Update Database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDBSuccess
            // 
            this.lblDBSuccess.AutoSize = true;
            this.lblDBSuccess.Location = new System.Drawing.Point(740, 17);
            this.lblDBSuccess.Name = "lblDBSuccess";
            this.lblDBSuccess.Size = new System.Drawing.Size(0, 13);
            this.lblDBSuccess.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 543);
            this.Controls.Add(this.lblDBSuccess);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statesListGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setStateButton);
            this.Controls.Add(this.problemButton);
            this.Controls.Add(this.problemsListBox);
            this.Controls.Add(this.episodesListGrid);
            this.Controls.Add(this.initDbButton);
            this.Controls.Add(this.userListGrid);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newLoginButton);
            this.Controls.Add(this.loginButton);
            this.Name = "Form1";
            this.Text = "CoolIt Persistence Test Client";
            ((System.ComponentModel.ISupportInitialize)(this.userListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodesListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statesListGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button loginButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox emailTextBox;
		private System.Windows.Forms.DataGridView userListGrid;
		private System.Windows.Forms.Button initDbButton;
		private System.Windows.Forms.DataGridView episodesListGrid;
		private System.Windows.Forms.Button newLoginButton;
		private System.Windows.Forms.ListBox problemsListBox;
		private System.Windows.Forms.Button problemButton;
		private System.Windows.Forms.Button setStateButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView statesListGrid;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDBSuccess;
	}
}

