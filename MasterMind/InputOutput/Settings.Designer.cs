namespace MasterMind
{
    partial class frmSettings
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
			this.lblNr = new System.Windows.Forms.Label();
			this.lblColor = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nudTurns = new System.Windows.Forms.NumericUpDown();
			this.nudAvailableColors = new System.Windows.Forms.NumericUpDown();
			this.nudColorGuess = new System.Windows.Forms.NumericUpDown();
			this.rdbComputer = new System.Windows.Forms.RadioButton();
			this.grpWho = new System.Windows.Forms.GroupBox();
			this.rdbUser = new System.Windows.Forms.RadioButton();
			this.btnOk = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudTurns)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAvailableColors)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColorGuess)).BeginInit();
			this.grpWho.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblNr
			// 
			this.lblNr.AutoSize = true;
			this.lblNr.Location = new System.Drawing.Point(73, 28);
			this.lblNr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblNr.Name = "lblNr";
			this.lblNr.Size = new System.Drawing.Size(82, 13);
			this.lblNr.TabIndex = 0;
			this.lblNr.Text = "Number of turns";
			this.lblNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblColor
			// 
			this.lblColor.AutoSize = true;
			this.lblColor.Location = new System.Drawing.Point(23, 57);
			this.lblColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblColor.Name = "lblColor";
			this.lblColor.Size = new System.Drawing.Size(132, 13);
			this.lblColor.TabIndex = 1;
			this.lblColor.Text = "Number of available colors";
			this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 87);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(130, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Number of colors to guess";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nudTurns
			// 
			this.nudTurns.Location = new System.Drawing.Point(169, 28);
			this.nudTurns.Margin = new System.Windows.Forms.Padding(2);
			this.nudTurns.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.nudTurns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTurns.Name = "nudTurns";
			this.nudTurns.Size = new System.Drawing.Size(36, 20);
			this.nudTurns.TabIndex = 0;
			this.nudTurns.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// nudAvailableColors
			// 
			this.nudAvailableColors.Location = new System.Drawing.Point(169, 57);
			this.nudAvailableColors.Margin = new System.Windows.Forms.Padding(2);
			this.nudAvailableColors.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudAvailableColors.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudAvailableColors.Name = "nudAvailableColors";
			this.nudAvailableColors.Size = new System.Drawing.Size(36, 20);
			this.nudAvailableColors.TabIndex = 1;
			this.nudAvailableColors.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudAvailableColors.ValueChanged += new System.EventHandler(this.nudAvailableColors_ValueChanged);
			// 
			// nudColorGuess
			// 
			this.nudColorGuess.Location = new System.Drawing.Point(169, 87);
			this.nudColorGuess.Margin = new System.Windows.Forms.Padding(2);
			this.nudColorGuess.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudColorGuess.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudColorGuess.Name = "nudColorGuess";
			this.nudColorGuess.Size = new System.Drawing.Size(36, 20);
			this.nudColorGuess.TabIndex = 2;
			this.nudColorGuess.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// rdbComputer
			// 
			this.rdbComputer.AutoSize = true;
			this.rdbComputer.Location = new System.Drawing.Point(4, 39);
			this.rdbComputer.Margin = new System.Windows.Forms.Padding(2);
			this.rdbComputer.Name = "rdbComputer";
			this.rdbComputer.Size = new System.Drawing.Size(70, 17);
			this.rdbComputer.TabIndex = 5;
			this.rdbComputer.Text = "Computer";
			this.rdbComputer.UseVisualStyleBackColor = true;
			// 
			// grpWho
			// 
			this.grpWho.Controls.Add(this.rdbUser);
			this.grpWho.Controls.Add(this.rdbComputer);
			this.grpWho.Location = new System.Drawing.Point(92, 126);
			this.grpWho.Margin = new System.Windows.Forms.Padding(2);
			this.grpWho.Name = "grpWho";
			this.grpWho.Padding = new System.Windows.Forms.Padding(2);
			this.grpWho.Size = new System.Drawing.Size(112, 71);
			this.grpWho.TabIndex = 3;
			this.grpWho.TabStop = false;
			this.grpWho.Text = "Who\'s guessing?";
			// 
			// rdbUser
			// 
			this.rdbUser.AutoSize = true;
			this.rdbUser.Checked = true;
			this.rdbUser.Location = new System.Drawing.Point(5, 17);
			this.rdbUser.Name = "rdbUser";
			this.rdbUser.Size = new System.Drawing.Size(47, 17);
			this.rdbUser.TabIndex = 4;
			this.rdbUser.TabStop = true;
			this.rdbUser.Text = "User";
			this.rdbUser.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(128, 211);
			this.btnOk.Margin = new System.Windows.Forms.Padding(2);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(76, 27);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(222, 254);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.grpWho);
			this.Controls.Add(this.nudColorGuess);
			this.Controls.Add(this.nudAvailableColors);
			this.Controls.Add(this.nudTurns);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblColor);
			this.Controls.Add(this.lblNr);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "frmSettings";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.frmSettings_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudTurns)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAvailableColors)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudColorGuess)).EndInit();
			this.grpWho.ResumeLayout(false);
			this.grpWho.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNr;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTurns;
        private System.Windows.Forms.NumericUpDown nudAvailableColors;
        private System.Windows.Forms.NumericUpDown nudColorGuess;
        private System.Windows.Forms.RadioButton rdbComputer;
        private System.Windows.Forms.GroupBox grpWho;
        private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.RadioButton rdbUser;

    }
}