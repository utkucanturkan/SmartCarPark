namespace SmartCarPark
{
    partial class uControlEditCar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPlateName = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.lblApartmentName = new System.Windows.Forms.Label();
            this.cmbApartments = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlateName
            // 
            this.lblPlateName.AutoSize = true;
            this.lblPlateName.Location = new System.Drawing.Point(3, 16);
            this.lblPlateName.Name = "lblPlateName";
            this.lblPlateName.Size = new System.Drawing.Size(37, 13);
            this.lblPlateName.TabIndex = 0;
            this.lblPlateName.Text = "Plate :";
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(70, 13);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(185, 20);
            this.txtPlate.TabIndex = 1;
            // 
            // lblApartmentName
            // 
            this.lblApartmentName.AutoSize = true;
            this.lblApartmentName.Location = new System.Drawing.Point(3, 42);
            this.lblApartmentName.Name = "lblApartmentName";
            this.lblApartmentName.Size = new System.Drawing.Size(61, 13);
            this.lblApartmentName.TabIndex = 2;
            this.lblApartmentName.Text = "Apartment :";
            // 
            // cmbApartments
            // 
            this.cmbApartments.FormattingEnabled = true;
            this.cmbApartments.Location = new System.Drawing.Point(70, 39);
            this.cmbApartments.Name = "cmbApartments";
            this.cmbApartments.Size = new System.Drawing.Size(185, 21);
            this.cmbApartments.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(180, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // uControlEditCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbApartments);
            this.Controls.Add(this.lblApartmentName);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.lblPlateName);
            this.Name = "uControlEditCar";
            this.Size = new System.Drawing.Size(261, 99);
            this.Load += new System.EventHandler(this.uControlEditCar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlateName;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label lblApartmentName;
        private System.Windows.Forms.ComboBox cmbApartments;
        private System.Windows.Forms.Button btnSave;
    }
}
