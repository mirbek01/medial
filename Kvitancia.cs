using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
//using Microsoft.ReportViewer.WinForms.resources;//using System.Windows.Forms. ;

namespace DSS
{
    public partial class Kvitancia : Form
    {
        public Kvitancia()
        {
            InitializeComponent();
        }

        private void Kvitancia_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "___BASA__DataSet.Diagnosis". При необходимости она может быть перемещена или удалена.
            this.diagnosisTableAdapter.Fill(this.___BASA__DataSet.Diagnosis);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "___BASA__DataSet.Plata". При необходимости она может быть перемещена или удалена.
            this.PlataTableAdapter.Fill(this.___BASA__DataSet.Plata);
            // TODO: This line of code loads data into the '___BASA__DataSet.Plata' table. You can move, or remove it, as needed.
           // this.PlataTableAdapter.Fill(this.___BASA__DataSet.Plata);

           // this.reportViewer1.RefreshReport();
           // this.reportViewer2.RefreshReport();
           // this.reportViewer1.RefreshReport();
          //  this.reportViewer1.RefreshReport();
           // this.reportViewer1.RefreshReport();
          //  this.reportViewer2.RefreshReport();
           // this.reportViewer1.RefreshReport();
           // this.reportViewer1.RefreshReport();
        }

       

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
              
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
           
           // toolStripComboBox1.it
        }

        private void button1_Click(object sender, EventArgs e)
        {//printForm1.
           // printForm1.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(printForm1_QueryPageSettings);
           // printForm1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(printForm1_BeginPrint);
           // printForm1..PrintAction= System.Drawing.Printing.PrintAction
          // printForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToFile;//.PrintToPreview;
          // printForm1.PrintFileName = "qaz.jpg";
            //printForm1.Print(this, Microsoft.VisualBasic.PowerPacks.Printing.PrintForm.PrintOption.Scrollable);

        }

        void printForm1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {//e.PageSettings=new System.Drawing.Printing.PageSettings( 
            //throw new NotImplementedException();
            
        }

        void printForm1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
              e.Graphics.DrawImageUnscaled(Image.FromFile("qaz.jpg"), 10, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void myControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
