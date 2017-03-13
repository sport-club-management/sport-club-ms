namespace App
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.languageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem1});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // languageToolStripMenuItem1
            // 
            this.languageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frenchToolStripMenuItem1,
            this.englishToolStripMenuItem,
            this.arabToolStripMenuItem});
            this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
            resources.ApplyResources(this.languageToolStripMenuItem1, "languageToolStripMenuItem1");
            // 
            // frenchToolStripMenuItem1
            // 
            this.frenchToolStripMenuItem1.Name = "frenchToolStripMenuItem1";
            resources.ApplyResources(this.frenchToolStripMenuItem1, "frenchToolStripMenuItem1");
            this.frenchToolStripMenuItem1.Click += new System.EventHandler(this.frenchToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.anglaisToolStripMenuItem_Click);
            // 
            // arabToolStripMenuItem
            // 
            this.arabToolStripMenuItem.Name = "arabToolStripMenuItem";
            resources.ApplyResources(this.arabToolStripMenuItem, "arabToolStripMenuItem");
            this.arabToolStripMenuItem.Click += new System.EventHandler(this.arabeToolStripMenuItem_Click);
            // 
            // FormMenu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenu_FormClosed);
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arabToolStripMenuItem;
    }
}