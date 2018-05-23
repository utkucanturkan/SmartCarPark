namespace SmartCarPark
{
    partial class MainPage
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plateRecognizeSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLiveBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsApartmentManagementBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plateRecognizeSystemToolStripMenuItem,
            this.tsApartmentManagementBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(651, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plateRecognizeSystemToolStripMenuItem
            // 
            this.plateRecognizeSystemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLiveBtn,
            this.tsFileBtn});
            this.plateRecognizeSystemToolStripMenuItem.Name = "plateRecognizeSystemToolStripMenuItem";
            this.plateRecognizeSystemToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.plateRecognizeSystemToolStripMenuItem.Text = "Plate Recognition System";
            // 
            // tsLiveBtn
            // 
            this.tsLiveBtn.Name = "tsLiveBtn";
            this.tsLiveBtn.Size = new System.Drawing.Size(95, 22);
            this.tsLiveBtn.Text = "Live";
            this.tsLiveBtn.Click += new System.EventHandler(this.tsBtn_Click);
            // 
            // tsFileBtn
            // 
            this.tsFileBtn.Name = "tsFileBtn";
            this.tsFileBtn.Size = new System.Drawing.Size(95, 22);
            this.tsFileBtn.Text = "File";
            this.tsFileBtn.Click += new System.EventHandler(this.tsBtn_Click);
            // 
            // tsApartmentManagementBtn
            // 
            this.tsApartmentManagementBtn.Name = "tsApartmentManagementBtn";
            this.tsApartmentManagementBtn.Size = new System.Drawing.Size(150, 20);
            this.tsApartmentManagementBtn.Text = "Apartment Management";
            this.tsApartmentManagementBtn.Click += new System.EventHandler(this.tsApartmentManagementBtn_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(651, 823);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Car Park";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plateRecognizeSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsLiveBtn;
        private System.Windows.Forms.ToolStripMenuItem tsFileBtn;
        private System.Windows.Forms.ToolStripMenuItem tsApartmentManagementBtn;
    }
}