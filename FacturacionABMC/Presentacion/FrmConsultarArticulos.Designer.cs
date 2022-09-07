
namespace FacturacionABMC.Presentacion
{
    partial class FrmConsultarArticulos
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSArticulos = new FacturacionABMC.Presentacion.Reportes.DSArticulos();
            this.articulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.articulosTableAdapter = new FacturacionABMC.Presentacion.Reportes.DSArticulosTableAdapters.articulosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.articulosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FacturacionABMC.Presentacion.Reportes.RptConsultarArticulos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(44, 28);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(639, 398);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSArticulos
            // 
            this.dSArticulos.DataSetName = "DSArticulos";
            this.dSArticulos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // articulosBindingSource
            // 
            this.articulosBindingSource.DataMember = "articulos";
            this.articulosBindingSource.DataSource = this.dSArticulos;
            // 
            // articulosTableAdapter
            // 
            this.articulosTableAdapter.ClearBeforeFill = true;
            // 
            // FrmConsultarArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmConsultarArticulos";
            this.Text = "FrmConsultarArticulos";
            this.Load += new System.EventHandler(this.FrmConsultarArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes.DSArticulos dSArticulos;
        private System.Windows.Forms.BindingSource articulosBindingSource;
        private Reportes.DSArticulosTableAdapters.articulosTableAdapter articulosTableAdapter;
    }
}