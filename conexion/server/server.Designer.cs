namespace server
{
    partial class server
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
            this.labestado = new System.Windows.Forms.Label();
            this.labconec = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labarc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butzip = new System.Windows.Forms.Button();
            this.labenvia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labreci = new System.Windows.Forms.Label();
            this.lab2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labestado
            // 
            this.labestado.AutoSize = true;
            this.labestado.Location = new System.Drawing.Point(6, 16);
            this.labestado.Name = "labestado";
            this.labestado.Size = new System.Drawing.Size(35, 13);
            this.labestado.TabIndex = 0;
            this.labestado.Text = "label1";
            // 
            // labconec
            // 
            this.labconec.AutoSize = true;
            this.labconec.Location = new System.Drawing.Point(90, 16);
            this.labconec.Name = "labconec";
            this.labconec.Size = new System.Drawing.Size(35, 13);
            this.labconec.TabIndex = 1;
            this.labconec.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labarc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.butzip);
            this.groupBox1.Controls.Add(this.labenvia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labreci);
            this.groupBox1.Controls.Add(this.lab2);
            this.groupBox1.Controls.Add(this.labestado);
            this.groupBox1.Controls.Add(this.labconec);
            this.groupBox1.Location = new System.Drawing.Point(160, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 239);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // labarc
            // 
            this.labarc.AutoSize = true;
            this.labarc.Location = new System.Drawing.Point(90, 128);
            this.labarc.Name = "labarc";
            this.labarc.Size = new System.Drawing.Size(0, 13);
            this.labarc.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Leer Archivo";
            // 
            // butzip
            // 
            this.butzip.Location = new System.Drawing.Point(6, 166);
            this.butzip.Name = "butzip";
            this.butzip.Size = new System.Drawing.Size(75, 23);
            this.butzip.TabIndex = 6;
            this.butzip.Text = "ZIP";
            this.butzip.UseVisualStyleBackColor = true;
            this.butzip.Click += new System.EventHandler(this.butzip_Click);
            // 
            // labenvia
            // 
            this.labenvia.AutoSize = true;
            this.labenvia.Location = new System.Drawing.Point(62, 92);
            this.labenvia.Name = "labenvia";
            this.labenvia.Size = new System.Drawing.Size(0, 13);
            this.labenvia.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enviar:";
            // 
            // labreci
            // 
            this.labreci.AutoSize = true;
            this.labreci.Location = new System.Drawing.Point(64, 68);
            this.labreci.Name = "labreci";
            this.labreci.Size = new System.Drawing.Size(0, 13);
            this.labreci.TabIndex = 3;
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Location = new System.Drawing.Point(6, 68);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(52, 13);
            this.lab2.TabIndex = 2;
            this.lab2.Text = "Recibido:";
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.server_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labestado;
        private System.Windows.Forms.Label labconec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.Label labreci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labenvia;
        private System.Windows.Forms.Button butzip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labarc;
    }
}

