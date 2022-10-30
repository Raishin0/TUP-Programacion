namespace FrontFacturacion.formularios
{
    partial class FrmReporteVentas
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
            this.DtpUltimaFecha = new System.Windows.Forms.DateTimePicker();
            this.DtpPrimeraFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DgvFacturas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.NroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // DtpUltimaFecha
            // 
            this.DtpUltimaFecha.Location = new System.Drawing.Point(343, 114);
            this.DtpUltimaFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DtpUltimaFecha.Name = "DtpUltimaFecha";
            this.DtpUltimaFecha.Size = new System.Drawing.Size(233, 23);
            this.DtpUltimaFecha.TabIndex = 19;
            // 
            // DtpPrimeraFecha
            // 
            this.DtpPrimeraFecha.Location = new System.Drawing.Point(343, 83);
            this.DtpPrimeraFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DtpPrimeraFecha.Name = "DtpPrimeraFecha";
            this.DtpPrimeraFecha.Size = new System.Drawing.Size(233, 23);
            this.DtpPrimeraFecha.TabIndex = 18;
            this.DtpPrimeraFecha.Value = new System.DateTime(2000, 9, 13, 21, 25, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ultima Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Primera Fecha";
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerar.Location = new System.Drawing.Point(603, 87);
            this.BtnGenerar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(106, 39);
            this.BtnGenerar.TabIndex = 13;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSalir.Location = new System.Drawing.Point(419, 582);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(88, 39);
            this.BtnSalir.TabIndex = 12;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // DgvFacturas
            // 
            this.DgvFacturas.AllowUserToAddRows = false;
            this.DgvFacturas.AllowUserToDeleteRows = false;
            this.DgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroFactura,
            this.Fecha,
            this.FormaPago,
            this.Cliente,
            this.Cantidad,
            this.Total});
            this.DgvFacturas.Location = new System.Drawing.Point(40, 172);
            this.DgvFacturas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvFacturas.Name = "DgvFacturas";
            this.DgvFacturas.ReadOnly = true;
            this.DgvFacturas.Size = new System.Drawing.Size(839, 377);
            this.DgvFacturas.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(323, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "Reporte de Ventas";
            // 
            // NroFactura
            // 
            this.NroFactura.HeaderText = "NroFactura";
            this.NroFactura.Name = "NroFactura";
            this.NroFactura.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 150;
            // 
            // FormaPago
            // 
            this.FormaPago.HeaderText = "Forma pago";
            this.FormaPago.Name = "FormaPago";
            this.FormaPago.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 200;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // FrmReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 627);
            this.Controls.Add(this.DtpUltimaFecha);
            this.Controls.Add(this.DtpPrimeraFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.DgvFacturas);
            this.Controls.Add(this.label1);
            this.Name = "FrmReporteVentas";
            this.Text = "FrmReporteVentas";
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker DtpUltimaFecha;
        private DateTimePicker DtpPrimeraFecha;
        private Label label3;
        private Label label2;
        private Button BtnGenerar;
        private Button BtnSalir;
        private DataGridView DgvFacturas;
        private DataGridViewTextBoxColumn NroFactura;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn FormaPago;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Total;
        private Label label1;
    }
}