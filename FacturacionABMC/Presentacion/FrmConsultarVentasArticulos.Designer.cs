
namespace FacturacionABMC.Presentacion
{
    partial class FrmConsultarVentasArticulos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.articulosDTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSArticulos = new FacturacionABMC.Presentacion.Reportes.DSArticulos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.DtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.articulosDTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // articulosDTBindingSource
            // 
            this.articulosDTBindingSource.DataMember = "articulosDT";
            this.articulosDTBindingSource.DataSource = this.dSArticulos;
            // 
            // dSArticulos
            // 
            this.dSArticulos.DataSetName = "DSArticulos";
            this.dSArticulos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DSArticulos";
            reportDataSource1.Value = this.articulosDTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FacturacionABMC.Presentacion.Reportes.RptConsultarVentas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(40, 72);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewer1.Size = new System.Drawing.Size(709, 349);
            this.reportViewer1.TabIndex = 0;
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.Location = new System.Drawing.Point(40, 17);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(121, 38);
            this.BtnGenerar.TabIndex = 1;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // DtpFechaInicial
            // 
            this.DtpFechaInicial.Location = new System.Drawing.Point(260, 26);
            this.DtpFechaInicial.Name = "DtpFechaInicial";
            this.DtpFechaInicial.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaInicial.TabIndex = 2;
            this.DtpFechaInicial.Value = new System.DateTime(2000, 9, 6, 22, 23, 0, 0);
            // 
            // DtpFechaFinal
            // 
            this.DtpFechaFinal.Location = new System.Drawing.Point(549, 26);
            this.DtpFechaFinal.Name = "DtpFechaFinal";
            this.DtpFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaFinal.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Primer Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ultima Fecha";
            // 
            // FrmConsultarVentasArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFechaFinal);
            this.Controls.Add(this.DtpFechaInicial);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmConsultarVentasArticulos";
            this.Text = "FrmConsultarVentasArticulos";
            this.Load += new System.EventHandler(this.FrmConsultarVentasArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.articulosDTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.DateTimePicker DtpFechaInicial;
        private System.Windows.Forms.DateTimePicker DtpFechaFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource articulosDTBindingSource;
        private Reportes.DSArticulos dSArticulos;
    }
}