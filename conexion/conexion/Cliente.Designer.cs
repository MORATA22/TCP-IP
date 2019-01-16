namespace conexion
{
    partial class Cliente
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
            this.labarc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labresp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labconver = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.conectar = new System.Windows.Forms.Button();
            this.txtenviar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labarc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labresp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labconver);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.conectar);
            this.groupBox1.Controls.Add(this.txtenviar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(298, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // labarc
            // 
            this.labarc.AutoSize = true;
            this.labarc.Location = new System.Drawing.Point(71, 134);
            this.labarc.Name = "labarc";
            this.labarc.Size = new System.Drawing.Size(0, 13);
            this.labarc.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Archivo:";
            // 
            // labresp
            // 
            this.labresp.AutoSize = true;
            this.labresp.Location = new System.Drawing.Point(118, 107);
            this.labresp.Name = "labresp";
            this.labresp.Size = new System.Drawing.Size(0, 13);
            this.labresp.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Respuesta Server:";
            // 
            // labconver
            // 
            this.labconver.AutoSize = true;
            this.labconver.Location = new System.Drawing.Point(71, 83);
            this.labconver.Name = "labconver";
            this.labconver.Size = new System.Drawing.Size(0, 13);
            this.labconver.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enviado:";
            // 
            // conectar
            // 
            this.conectar.Location = new System.Drawing.Point(62, 200);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(75, 23);
            this.conectar.TabIndex = 2;
            this.conectar.Text = "Conectar";
            this.conectar.UseVisualStyleBackColor = true;
            this.conectar.Click += new System.EventHandler(this.conectar_Click);
            // 
            // txtenviar
            // 
            this.txtenviar.Location = new System.Drawing.Point(62, 39);
            this.txtenviar.Name = "txtenviar";
            this.txtenviar.Size = new System.Drawing.Size(100, 20);
            this.txtenviar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enviar:";
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Cliente";
            this.Text = "cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button conectar;
        private System.Windows.Forms.TextBox txtenviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labconver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labresp;
        private System.Windows.Forms.Label labarc;
        private System.Windows.Forms.Label label4;
    }
}

