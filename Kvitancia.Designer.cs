namespace DSS
{
    partial class Kvitancia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kvitancia));
            this.PlataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.___BASA__DataSet = new DSS.___BASA__DataSet();
            this.PlataTableAdapter = new DSS.___BASA__DataSetTableAdapters.PlataTableAdapter();
            this.patientsTableAdapter1 = new DSS.___BASA__DataSetTableAdapters.PatientsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.diagnosisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.diagnosisTableAdapter = new DSS.___BASA__DataSetTableAdapters.DiagnosisTableAdapter();
            this.tableAdapterManager = new DSS.___BASA__DataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.PlataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.___BASA__DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosisBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PlataBindingSource
            // 
            this.PlataBindingSource.DataMember = "Plata";
            this.PlataBindingSource.DataSource = this.___BASA__DataSet;
            // 
            // ___BASA__DataSet
            // 
            this.___BASA__DataSet.DataSetName = "___BASA__DataSet";
            this.___BASA__DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PlataTableAdapter
            // 
            this.PlataTableAdapter.ClearBeforeFill = true;
            // 
            // patientsTableAdapter1
            // 
            this.patientsTableAdapter1.ClearBeforeFill = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(this.printPreviewDialog1, "printPreviewDialog1");
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // diagnosisBindingSource
            // 
            this.diagnosisBindingSource.DataMember = "Diagnosis";
            this.diagnosisBindingSource.DataSource = this.___BASA__DataSet;
            // 
            // diagnosisTableAdapter
            // 
            this.diagnosisTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DiagnosisTableAdapter = this.diagnosisTableAdapter;
            this.tableAdapterManager.GorodTableAdapter = null;
            this.tableAdapterManager.KartaTableAdapter = null;
            this.tableAdapterManager.ObektTableAdapter = null;
            this.tableAdapterManager.OblastTableAdapter = null;
            this.tableAdapterManager.PatientsProfessiaTableAdapter = null;
            this.tableAdapterManager.PatientsRabotaTableAdapter = null;
            this.tableAdapterManager.PatientsTableAdapter = this.patientsTableAdapter1;
           // this.tableAdapterManager.Personal1TableAdapter = null;
            this.tableAdapterManager.PersonalProfessiaTableAdapter = null;
            this.tableAdapterManager.PersonalTableAdapter = null;
            this.tableAdapterManager.PlataTableAdapter = this.PlataTableAdapter;
            this.tableAdapterManager.PosesenieTableAdapter = null;
            this.tableAdapterManager.raspisanieTableAdapter = null;
            this.tableAdapterManager.SexTableAdapter = null;
            this.tableAdapterManager.TreatDSTableAdapter = null;
            this.tableAdapterManager.TreatTableAdapter = null;
            this.tableAdapterManager.TreatTreatTableAdapter = null;
            this.tableAdapterManager.UlizaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DSS.___BASA__DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.whenDatesTableAdapter = null;
            this.tableAdapterManager.ZalobyTableAdapter = null;
            this.tableAdapterManager.ZurnalTableAdapter = null;
            // 
            // Kvitancia
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Kvitancia";
            this.Load += new System.EventHandler(this.Kvitancia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.___BASA__DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosisBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource PlataBindingSource;
        private ___BASA__DataSet ___BASA__DataSet;
        private DSS.___BASA__DataSetTableAdapters.PlataTableAdapter PlataTableAdapter;
       private DSS.___BASA__DataSetTableAdapters.PatientsTableAdapter patientsTableAdapter1;
       private System.Windows.Forms.Button button1;
      // private Microsoft.VisualBasic.PowerPacks.Printing.PrintForm printForm1;
       private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
       private System.Drawing.Printing.PrintDocument printDocument1;
       private System.Windows.Forms.PrintDialog printDialog1;
       private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
       private System.Windows.Forms.Button button2;
       private System.Windows.Forms.BindingSource diagnosisBindingSource;
       private DSS.___BASA__DataSetTableAdapters.DiagnosisTableAdapter diagnosisTableAdapter;
       private DSS.___BASA__DataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}