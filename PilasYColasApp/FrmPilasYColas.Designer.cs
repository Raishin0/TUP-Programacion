namespace PilasYColasApp
{
    partial class FrmPilasYColas
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
            this.LblPila = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LbxPila = new System.Windows.Forms.ListBox();
            this.BtnAñadirPila = new System.Windows.Forms.Button();
            this.TbxPila = new System.Windows.Forms.TextBox();
            this.TbxCola = new System.Windows.Forms.TextBox();
            this.BtnAñadirCola = new System.Windows.Forms.Button();
            this.LbxCola = new System.Windows.Forms.ListBox();
            this.BtnPrimeroPila = new System.Windows.Forms.Button();
            this.BtnVaciaPila = new System.Windows.Forms.Button();
            this.BtnExtraerCola = new System.Windows.Forms.Button();
            this.BtnPrimeroCola = new System.Windows.Forms.Button();
            this.BtnExtraerPila = new System.Windows.Forms.Button();
            this.BtnVaciaCola = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblPila
            // 
            this.LblPila.AutoSize = true;
            this.LblPila.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPila.Location = new System.Drawing.Point(131, 44);
            this.LblPila.Name = "LblPila";
            this.LblPila.Size = new System.Drawing.Size(80, 42);
            this.LblPila.TabIndex = 0;
            this.LblPila.Text = "Pila";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cola";
            // 
            // LbxPila
            // 
            this.LbxPila.FormattingEnabled = true;
            this.LbxPila.Location = new System.Drawing.Point(81, 144);
            this.LbxPila.Name = "LbxPila";
            this.LbxPila.Size = new System.Drawing.Size(181, 251);
            this.LbxPila.TabIndex = 2;
            // 
            // BtnAñadirPila
            // 
            this.BtnAñadirPila.Location = new System.Drawing.Point(81, 103);
            this.BtnAñadirPila.Name = "BtnAñadirPila";
            this.BtnAñadirPila.Size = new System.Drawing.Size(75, 23);
            this.BtnAñadirPila.TabIndex = 4;
            this.BtnAñadirPila.Text = "AñadirPila";
            this.BtnAñadirPila.UseVisualStyleBackColor = true;
            this.BtnAñadirPila.Click += new System.EventHandler(this.BtnAñadirPila_Click);
            // 
            // TbxPila
            // 
            this.TbxPila.Location = new System.Drawing.Point(162, 105);
            this.TbxPila.Name = "TbxPila";
            this.TbxPila.Size = new System.Drawing.Size(100, 20);
            this.TbxPila.TabIndex = 5;
            // 
            // TbxCola
            // 
            this.TbxCola.Location = new System.Drawing.Point(407, 105);
            this.TbxCola.Name = "TbxCola";
            this.TbxCola.Size = new System.Drawing.Size(100, 20);
            this.TbxCola.TabIndex = 8;
            // 
            // BtnAñadirCola
            // 
            this.BtnAñadirCola.Location = new System.Drawing.Point(326, 103);
            this.BtnAñadirCola.Name = "BtnAñadirCola";
            this.BtnAñadirCola.Size = new System.Drawing.Size(75, 23);
            this.BtnAñadirCola.TabIndex = 7;
            this.BtnAñadirCola.Text = "AñadirCola";
            this.BtnAñadirCola.UseVisualStyleBackColor = true;
            this.BtnAñadirCola.Click += new System.EventHandler(this.BtnAñadirCola_Click);
            // 
            // LbxCola
            // 
            this.LbxCola.FormattingEnabled = true;
            this.LbxCola.Location = new System.Drawing.Point(326, 144);
            this.LbxCola.Name = "LbxCola";
            this.LbxCola.Size = new System.Drawing.Size(181, 251);
            this.LbxCola.TabIndex = 6;
            // 
            // BtnPrimeroPila
            // 
            this.BtnPrimeroPila.Location = new System.Drawing.Point(93, 404);
            this.BtnPrimeroPila.Name = "BtnPrimeroPila";
            this.BtnPrimeroPila.Size = new System.Drawing.Size(75, 23);
            this.BtnPrimeroPila.TabIndex = 9;
            this.BtnPrimeroPila.Text = "Primero";
            this.BtnPrimeroPila.UseVisualStyleBackColor = true;
            this.BtnPrimeroPila.Click += new System.EventHandler(this.BtnPrimeroPila_Click);
            // 
            // BtnVaciaPila
            // 
            this.BtnVaciaPila.Location = new System.Drawing.Point(136, 433);
            this.BtnVaciaPila.Name = "BtnVaciaPila";
            this.BtnVaciaPila.Size = new System.Drawing.Size(75, 23);
            this.BtnVaciaPila.TabIndex = 10;
            this.BtnVaciaPila.Text = "EstaVacio?";
            this.BtnVaciaPila.UseVisualStyleBackColor = true;
            this.BtnVaciaPila.Click += new System.EventHandler(this.BtnVaciaPila_Click);
            // 
            // BtnExtraerCola
            // 
            this.BtnExtraerCola.Location = new System.Drawing.Point(417, 404);
            this.BtnExtraerCola.Name = "BtnExtraerCola";
            this.BtnExtraerCola.Size = new System.Drawing.Size(75, 23);
            this.BtnExtraerCola.TabIndex = 12;
            this.BtnExtraerCola.Text = "Extraer";
            this.BtnExtraerCola.UseVisualStyleBackColor = true;
            this.BtnExtraerCola.Click += new System.EventHandler(this.BtnExtraerCola_Click);
            // 
            // BtnPrimeroCola
            // 
            this.BtnPrimeroCola.Location = new System.Drawing.Point(336, 404);
            this.BtnPrimeroCola.Name = "BtnPrimeroCola";
            this.BtnPrimeroCola.Size = new System.Drawing.Size(75, 23);
            this.BtnPrimeroCola.TabIndex = 11;
            this.BtnPrimeroCola.Text = "Primero";
            this.BtnPrimeroCola.UseVisualStyleBackColor = true;
            this.BtnPrimeroCola.Click += new System.EventHandler(this.BtnPrimeroCola_Click);
            // 
            // BtnExtraerPila
            // 
            this.BtnExtraerPila.Location = new System.Drawing.Point(175, 404);
            this.BtnExtraerPila.Name = "BtnExtraerPila";
            this.BtnExtraerPila.Size = new System.Drawing.Size(75, 23);
            this.BtnExtraerPila.TabIndex = 13;
            this.BtnExtraerPila.Text = "Extraer";
            this.BtnExtraerPila.UseVisualStyleBackColor = true;
            this.BtnExtraerPila.Click += new System.EventHandler(this.BtnExtraerPila_Click);
            // 
            // BtnVaciaCola
            // 
            this.BtnVaciaCola.Location = new System.Drawing.Point(376, 433);
            this.BtnVaciaCola.Name = "BtnVaciaCola";
            this.BtnVaciaCola.Size = new System.Drawing.Size(75, 23);
            this.BtnVaciaCola.TabIndex = 14;
            this.BtnVaciaCola.Text = "EstaVacio?";
            this.BtnVaciaCola.UseVisualStyleBackColor = true;
            this.BtnVaciaCola.Click += new System.EventHandler(this.BtnVaciaCola_Click);
            // 
            // FrmPilasYColas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 487);
            this.Controls.Add(this.BtnVaciaCola);
            this.Controls.Add(this.BtnExtraerPila);
            this.Controls.Add(this.BtnExtraerCola);
            this.Controls.Add(this.BtnPrimeroCola);
            this.Controls.Add(this.BtnVaciaPila);
            this.Controls.Add(this.BtnPrimeroPila);
            this.Controls.Add(this.TbxCola);
            this.Controls.Add(this.BtnAñadirCola);
            this.Controls.Add(this.LbxCola);
            this.Controls.Add(this.TbxPila);
            this.Controls.Add(this.BtnAñadirPila);
            this.Controls.Add(this.LbxPila);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblPila);
            this.Name = "FrmPilasYColas";
            this.Text = "Pilas y Colas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblPila;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LbxPila;
        private System.Windows.Forms.Button BtnAñadirPila;
        private System.Windows.Forms.TextBox TbxPila;
        private System.Windows.Forms.TextBox TbxCola;
        private System.Windows.Forms.Button BtnAñadirCola;
        private System.Windows.Forms.ListBox LbxCola;
        private System.Windows.Forms.Button BtnPrimeroPila;
        private System.Windows.Forms.Button BtnVaciaPila;
        private System.Windows.Forms.Button BtnExtraerCola;
        private System.Windows.Forms.Button BtnPrimeroCola;
        private System.Windows.Forms.Button BtnExtraerPila;
        private System.Windows.Forms.Button BtnVaciaCola;
    }
}

