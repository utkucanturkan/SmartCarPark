namespace SmartCarPark
{
    partial class PlateRecognitionSystemForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsNewImageBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.pbOrginal = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbGrey = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbCanny = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProcessTime = new System.Windows.Forms.Label();
            this.lblPerson = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPlate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSonuc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.sPort = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanny)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNewImageBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(651, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsNewImageBtn
            // 
            this.tsNewImageBtn.Name = "tsNewImageBtn";
            this.tsNewImageBtn.Size = new System.Drawing.Size(43, 20);
            this.tsNewImageBtn.Text = "New";
            this.tsNewImageBtn.Click += new System.EventHandler(this.tsNewImageBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Orjinal Fotoğraf";
            // 
            // pbOrginal
            // 
            this.pbOrginal.Location = new System.Drawing.Point(17, 64);
            this.pbOrginal.Name = "pbOrginal";
            this.pbOrginal.Size = new System.Drawing.Size(250, 250);
            this.pbOrginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOrginal.TabIndex = 7;
            this.pbOrginal.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(374, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gri Ölçekli Fotoğraf";
            // 
            // pbGrey
            // 
            this.pbGrey.Location = new System.Drawing.Point(379, 64);
            this.pbGrey.Name = "pbGrey";
            this.pbGrey.Size = new System.Drawing.Size(250, 250);
            this.pbGrey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGrey.TabIndex = 11;
            this.pbGrey.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SmartCarPark.Properties.Resources.arrow;
            this.pictureBox3.Location = new System.Drawing.Point(273, 152);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SmartCarPark.Properties.Resources.arrow;
            this.pictureBox4.Location = new System.Drawing.Point(273, 475);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // pbCanny
            // 
            this.pbCanny.Location = new System.Drawing.Point(17, 374);
            this.pbCanny.Name = "pbCanny";
            this.pbCanny.Size = new System.Drawing.Size(250, 250);
            this.pbCanny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCanny.TabIndex = 15;
            this.pbCanny.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Kenar Bulunmuş Fotoğraf";
            // 
            // lblProcessTime
            // 
            this.lblProcessTime.AutoSize = true;
            this.lblProcessTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProcessTime.Location = new System.Drawing.Point(13, 93);
            this.lblProcessTime.Name = "lblProcessTime";
            this.lblProcessTime.Size = new System.Drawing.Size(176, 20);
            this.lblProcessTime.TabIndex = 6;
            this.lblProcessTime.Text = "Görüntü İşleme Süresi :";
            // 
            // lblPerson
            // 
            this.lblPerson.AutoSize = true;
            this.lblPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPerson.Location = new System.Drawing.Point(495, 93);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(30, 20);
            this.lblPerson.TabIndex = 5;
            this.lblPerson.Text = "xxx";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(391, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Araç Sahibi :";
            // 
            // lblPlate
            // 
            this.lblPlate.AutoSize = true;
            this.lblPlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPlate.ForeColor = System.Drawing.Color.Red;
            this.lblPlate.Location = new System.Drawing.Point(75, 38);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(45, 26);
            this.lblPlate.TabIndex = 3;
            this.lblPlate.Text = "xxx";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(13, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Plaka :";
            // 
            // lblSonuc
            // 
            this.lblSonuc.AutoSize = true;
            this.lblSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSonuc.Location = new System.Drawing.Point(495, 44);
            this.lblSonuc.Name = "lblSonuc";
            this.lblSonuc.Size = new System.Drawing.Size(30, 20);
            this.lblSonuc.TabIndex = 1;
            this.lblSonuc.Text = "xxx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(375, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "İşlem Sonucu :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblSonuc);
            this.groupBox2.Controls.Add(this.lblProcessTime);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblPerson);
            this.groupBox2.Controls.Add(this.lblPlate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(0, 654);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 143);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sonuç : ";
            // 
            // pnlResult
            // 
            this.pnlResult.Location = new System.Drawing.Point(379, 374);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(252, 250);
            this.pnlResult.TabIndex = 8;
            // 
            // PlateRecognitionSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 797);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pbCanny);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pbGrey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbOrginal);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlateRecognitionSystemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlateRecognitionSystemForm_FormClosed);
            this.Load += new System.EventHandler(this.PlateRecognitionSystemForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanny)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsNewImageBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbOrginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbGrey;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbCanny;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProcessTime;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSonuc;
        private System.Windows.Forms.Panel pnlResult;
        private System.IO.Ports.SerialPort sPort;
    }
}