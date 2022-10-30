namespace FrontFacturacion.formularios
{
    partial class FrmConsultarFacturas
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
            this.label1 = new System.Windows.Forms.Label();
            this.DgvFacturas = new System.Windows.Forms.DataGridView();
            this.NroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Borrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbxCliente = new System.Windows.Forms.TextBox();
            this.DtpPrimeraFecha = new System.Windows.Forms.DateTimePicker();
            this.DtpUltimaFecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(396, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Facturas";
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
            this.IDFormaPago,
            this.Borrar,
            this.Modificar,
            this.Ver});
            this.DgvFacturas.Location = new System.Drawing.Point(33, 195);
            this.DgvFacturas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvFacturas.Name = "DgvFacturas";
            this.DgvFacturas.ReadOnly = true;
            this.DgvFacturas.Size = new System.Drawing.Size(839, 377);
            this.DgvFacturas.TabIndex = 1;
            this.DgvFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFacturas_CellContentClick);
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
            // IDFormaPago
            // 
            this.IDFormaPago.HeaderText = "IDFormaPago";
            this.IDFormaPago.Name = "IDFormaPago";
            this.IDFormaPago.ReadOnly = true;
            this.IDFormaPago.Visible = false;
            // 
            // Borrar
            // 
            this.Borrar.HeaderText = "Borrar";
            this.Borrar.Name = "Borrar";
            this.Borrar.ReadOnly = true;
            this.Borrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Borrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Borrar.Text = "Borrar";
            this.Borrar.UseColumnTextForButtonValue = true;
            this.Borrar.Width = 75;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseColumnTextForButtonValue = true;
            this.Modificar.Width = 75;
            // 
            // Ver
            // 
            this.Ver.HeaderText = "Ver";
            this.Ver.Name = "Ver";
            this.Ver.ReadOnly = true;
            this.Ver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ver.Text = "Ver";
            this.Ver.UseColumnTextForButtonValue = true;
            this.Ver.Width = 75;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSalir.Location = new System.Drawing.Point(418, 579);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(88, 39);
            this.BtnSalir.TabIndex = 2;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerar.Location = new System.Drawing.Point(582, 104);
            this.BtnGenerar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(106, 39);
            this.BtnGenerar.TabIndex = 3;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Primera Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ultima Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 147);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cliente";
            // 
            // TbxCliente
            // 
            this.TbxCliente.Location = new System.Drawing.Point(342, 142);
            this.TbxCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbxCliente.Name = "TbxCliente";
            this.TbxCliente.Size = new System.Drawing.Size(233, 23);
            this.TbxCliente.TabIndex = 7;
            // 
            // DtpPrimeraFecha
            // 
            this.DtpPrimeraFecha.Location = new System.Drawing.Point(342, 80);
            this.DtpPrimeraFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DtpPrimeraFecha.Name = "DtpPrimeraFecha";
            this.DtpPrimeraFecha.Size = new System.Drawing.Size(233, 23);
            this.DtpPrimeraFecha.TabIndex = 8;
            this.DtpPrimeraFecha.Value = new System.DateTime(2000, 9, 13, 21, 25, 0, 0);
            // 
            // DtpUltimaFecha
            // 
            this.DtpUltimaFecha.Location = new System.Drawing.Point(342, 111);
            this.DtpUltimaFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DtpUltimaFecha.Name = "DtpUltimaFecha";
            this.DtpUltimaFecha.Size = new System.Drawing.Size(233, 23);
            this.DtpUltimaFecha.TabIndex = 9;
            // 
            // FrmConsultarFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 623);
            this.Controls.Add(this.DtpUltimaFecha);
            this.Controls.Add(this.DtpPrimeraFecha);
            this.Controls.Add(this.TbxCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.DgvFacturas);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmConsultarFacturas";
            this.Text = "Consultar Facturas";
            this.Load += new System.EventHandler(this.FrmConsultarFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvFacturas;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbxCliente;
        private System.Windows.Forms.DateTimePicker DtpPrimeraFecha;
        private System.Windows.Forms.DateTimePicker DtpUltimaFecha;
        private DataGridViewTextBoxColumn NroFactura;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn FormaPago;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn IDFormaPago;
        private DataGridViewButtonColumn Borrar;
        private DataGridViewButtonColumn Modificar;
        private DataGridViewButtonColumn Ver;
    }
}