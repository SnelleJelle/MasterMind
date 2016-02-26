namespace MasterMind
{
    partial class frmMasterMind
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
			this.grpAvailableColors = new System.Windows.Forms.GroupBox();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.placeholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.usageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.msMasterMind = new System.Windows.Forms.MenuStrip();
			this.grpAantalRijen = new System.Windows.Forms.GroupBox();
			this.btnTry = new System.Windows.Forms.Button();
			this.msMasterMind.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpAvailableColors
			// 
			this.grpAvailableColors.Location = new System.Drawing.Point(13, 28);
			this.grpAvailableColors.Margin = new System.Windows.Forms.Padding(2);
			this.grpAvailableColors.Name = "grpAvailableColors";
			this.grpAvailableColors.Padding = new System.Windows.Forms.Padding(2);
			this.grpAvailableColors.Size = new System.Drawing.Size(160, 40);
			this.grpAvailableColors.TabIndex = 1;
			this.grpAvailableColors.TabStop = false;
			this.grpAvailableColors.Text = "Available colors";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.newToolStripMenuItem.Text = "New";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.placeholderToolStripMenuItem});
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.loadToolStripMenuItem.Text = "Load";
			// 
			// placeholderToolStripMenuItem
			// 
			this.placeholderToolStripMenuItem.Name = "placeholderToolStripMenuItem";
			this.placeholderToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.placeholderToolStripMenuItem.Text = "*placeholder*";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usageToolStripMenuItem,
            this.exitToolStripMenuItem1});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// usageToolStripMenuItem
			// 
			this.usageToolStripMenuItem.Name = "usageToolStripMenuItem";
			this.usageToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.usageToolStripMenuItem.Text = "Usage";
			this.usageToolStripMenuItem.Click += new System.EventHandler(this.usageToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem1
			// 
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
			this.exitToolStripMenuItem1.Text = "About";
			this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
			// 
			// msMasterMind
			// 
			this.msMasterMind.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.msMasterMind.Location = new System.Drawing.Point(0, 0);
			this.msMasterMind.Name = "msMasterMind";
			this.msMasterMind.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.msMasterMind.Size = new System.Drawing.Size(470, 24);
			this.msMasterMind.TabIndex = 0;
			this.msMasterMind.Text = "menuStrip1";
			// 
			// grpAantalRijen
			// 
			this.grpAantalRijen.Location = new System.Drawing.Point(13, 113);
			this.grpAantalRijen.Name = "grpAantalRijen";
			this.grpAantalRijen.Size = new System.Drawing.Size(160, 138);
			this.grpAantalRijen.TabIndex = 3;
			this.grpAantalRijen.TabStop = false;
			// 
			// btnTry
			// 
			this.btnTry.Location = new System.Drawing.Point(233, 140);
			this.btnTry.Name = "btnTry";
			this.btnTry.Size = new System.Drawing.Size(75, 23);
			this.btnTry.TabIndex = 4;
			this.btnTry.Text = "Try";
			this.btnTry.UseVisualStyleBackColor = true;
			this.btnTry.Click += new System.EventHandler(this.btnTry_Click);
			// 
			// frmMasterMind
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(470, 565);
			this.Controls.Add(this.btnTry);
			this.Controls.Add(this.grpAantalRijen);
			this.Controls.Add(this.grpAvailableColors);
			this.Controls.Add(this.msMasterMind);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.msMasterMind;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.Name = "frmMasterMind";
			this.Text = "MasterMind";
			this.Load += new System.EventHandler(this.frmMasterMind_Load);
			this.msMasterMind.ResumeLayout(false);
			this.msMasterMind.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.GroupBox grpAvailableColors;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem placeholderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem usageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.MenuStrip msMasterMind;
		private System.Windows.Forms.GroupBox grpAantalRijen;
		private System.Windows.Forms.Button btnTry;
    }
}

