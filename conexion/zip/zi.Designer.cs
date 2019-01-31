namespace zip
{
    partial class zi
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butdesc = new System.Windows.Forms.Button();
            this.butcomp = new System.Windows.Forms.Button();
            this.encrip = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.encrip);
            this.groupBox1.Controls.Add(this.butdesc);
            this.groupBox1.Controls.Add(this.butcomp);
            this.groupBox1.Location = new System.Drawing.Point(280, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ZIPIZAPE";
            // 
            // butdesc
            // 
            this.butdesc.Location = new System.Drawing.Point(69, 80);
            this.butdesc.Name = "butdesc";
            this.butdesc.Size = new System.Drawing.Size(75, 23);
            this.butdesc.TabIndex = 1;
            this.butdesc.Text = "UPZIP";
            this.butdesc.UseVisualStyleBackColor = true;
            this.butdesc.Click += new System.EventHandler(this.butdesc_Click);
            // 
            // butcomp
            // 
            this.butcomp.Location = new System.Drawing.Point(69, 39);
            this.butcomp.Name = "butcomp";
            this.butcomp.Size = new System.Drawing.Size(75, 23);
            this.butcomp.TabIndex = 0;
            this.butcomp.Text = "ZIP";
            this.butcomp.UseVisualStyleBackColor = true;
            this.butcomp.Click += new System.EventHandler(this.butcomp_Click);
            // 
            // encrip
            // 
            this.encrip.Location = new System.Drawing.Point(214, 49);
            this.encrip.Name = "encrip";
            this.encrip.Size = new System.Drawing.Size(122, 44);
            this.encrip.TabIndex = 2;
            this.encrip.Text = "Encriptar";
            this.encrip.UseVisualStyleBackColor = true;
            // 
            // zi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "zi";
            this.Text = "ZIP";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butdesc;
        private System.Windows.Forms.Button butcomp;
        private System.Windows.Forms.Button encrip;
    }
}

