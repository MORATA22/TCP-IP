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
            this.SuspendLayout();
            // 
            // labestado
            // 
            this.labestado.AutoSize = true;
            this.labestado.Location = new System.Drawing.Point(357, 45);
            this.labestado.Name = "labestado";
            this.labestado.Size = new System.Drawing.Size(35, 13);
            this.labestado.TabIndex = 0;
            this.labestado.Text = "label1";
            // 
            // labconec
            // 
            this.labconec.AutoSize = true;
            this.labconec.Location = new System.Drawing.Point(357, 121);
            this.labconec.Name = "labconec";
            this.labconec.Size = new System.Drawing.Size(35, 13);
            this.labconec.TabIndex = 1;
            this.labconec.Text = "label2";
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labconec);
            this.Controls.Add(this.labestado);
            this.Name = "server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labestado;
        private System.Windows.Forms.Label labconec;
    }
}

