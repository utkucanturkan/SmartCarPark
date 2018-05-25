namespace SmartCarPark
{
    partial class uControlEditApartment
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtApartmentNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.dgCars = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCars)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No :";
            // 
            // txtApartmentNo
            // 
            this.txtApartmentNo.Location = new System.Drawing.Point(53, 12);
            this.txtApartmentNo.Name = "txtApartmentNo";
            this.txtApartmentNo.Size = new System.Drawing.Size(363, 20);
            this.txtApartmentNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Owner :";
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(53, 38);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(363, 20);
            this.txtOwner.TabIndex = 3;
            // 
            // dgCars
            // 
            this.dgCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCars.Location = new System.Drawing.Point(6, 64);
            this.dgCars.Name = "dgCars";
            this.dgCars.Size = new System.Drawing.Size(410, 171);
            this.dgCars.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(341, 241);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // uControlEditApartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgCars);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtApartmentNo);
            this.Controls.Add(this.label1);
            this.Name = "uControlEditApartment";
            this.Size = new System.Drawing.Size(423, 274);
            this.Load += new System.EventHandler(this.uControlEditApartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApartmentNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.DataGridView dgCars;
        private System.Windows.Forms.Button btnSave;
    }
}
