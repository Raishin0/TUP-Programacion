﻿
namespace FacturacionABMC.Presentacion
{
    partial class FrmModificarFactura
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
            this.TbxTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.DgvDetalles = new System.Windows.Forms.DataGridView();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TbxCantidad = new System.Windows.Forms.TextBox();
            this.CbxArticulos = new System.Windows.Forms.ComboBox();
            this.CbxFormaPago = new System.Windows.Forms.ComboBox();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TbxCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblFactura = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // TbxTotal
            // 
            this.TbxTotal.Enabled = false;
            this.TbxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxTotal.Location = new System.Drawing.Point(423, 466);
            this.TbxTotal.Name = "TbxTotal";
            this.TbxTotal.Size = new System.Drawing.Size(102, 26);
            this.TbxTotal.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(368, 469);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Total";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(166, 469);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 30;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(85, 469);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 29;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // DgvDetalles
            // 
            this.DgvDetalles.AllowUserToAddRows = false;
            this.DgvDetalles.AllowUserToDeleteRows = false;
            this.DgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Articulo,
            this.Cantidad,
            this.PrecioUnitario,
            this.Accion});
            this.DgvDetalles.Location = new System.Drawing.Point(42, 261);
            this.DgvDetalles.Name = "DgvDetalles";
            this.DgvDetalles.ReadOnly = true;
            this.DgvDetalles.Size = new System.Drawing.Size(509, 189);
            this.DgvDetalles.TabIndex = 28;
            this.DgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalles_CellContentClick);
            // 
            // Articulo
            // 
            this.Articulo.Frozen = true;
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 200;
            // 
            // Cantidad
            // 
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.Frozen = true;
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            // 
            // Accion
            // 
            this.Accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Accion.Text = "Quitar";
            this.Accion.UseColumnTextForButtonValue = true;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(411, 234);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(75, 22);
            this.BtnAgregar.TabIndex = 27;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            // 
            // TbxCantidad
            // 
            this.TbxCantidad.Location = new System.Drawing.Point(305, 235);
            this.TbxCantidad.Name = "TbxCantidad";
            this.TbxCantidad.Size = new System.Drawing.Size(99, 20);
            this.TbxCantidad.TabIndex = 26;
            // 
            // CbxArticulos
            // 
            this.CbxArticulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxArticulos.FormattingEnabled = true;
            this.CbxArticulos.Location = new System.Drawing.Point(106, 235);
            this.CbxArticulos.Name = "CbxArticulos";
            this.CbxArticulos.Size = new System.Drawing.Size(192, 21);
            this.CbxArticulos.TabIndex = 25;
            // 
            // CbxFormaPago
            // 
            this.CbxFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxFormaPago.FormattingEnabled = true;
            this.CbxFormaPago.Location = new System.Drawing.Point(251, 176);
            this.CbxFormaPago.Name = "CbxFormaPago";
            this.CbxFormaPago.Size = new System.Drawing.Size(121, 21);
            this.CbxFormaPago.TabIndex = 24;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Enabled = false;
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(251, 91);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(118, 20);
            this.DtpFecha.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Forma de pago";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TbxCliente
            // 
            this.TbxCliente.Location = new System.Drawing.Point(251, 132);
            this.TbxCliente.Name = "TbxCliente";
            this.TbxCliente.Size = new System.Drawing.Size(121, 20);
            this.TbxCliente.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha";
            // 
            // LblFactura
            // 
            this.LblFactura.AutoSize = true;
            this.LblFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFactura.Location = new System.Drawing.Point(166, 31);
            this.LblFactura.Name = "LblFactura";
            this.LblFactura.Size = new System.Drawing.Size(281, 31);
            this.LblFactura.TabIndex = 18;
            this.LblFactura.Text = "Modificar Factura Nº";
            // 
            // FrmModificarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 514);
            this.Controls.Add(this.TbxTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.DgvDetalles);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.TbxCantidad);
            this.Controls.Add(this.CbxArticulos);
            this.Controls.Add(this.CbxFormaPago);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TbxCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblFactura);
            this.Name = "FrmModificarFactura";
            this.Text = "FrmModificarFactura";
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbxTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.DataGridView DgvDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox TbxCantidad;
        private System.Windows.Forms.ComboBox CbxArticulos;
        private System.Windows.Forms.ComboBox CbxFormaPago;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbxCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblFactura;
    }
}