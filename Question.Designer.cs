namespace DSS
{
    partial class Question
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonNotClose = new System.Windows.Forms.Button();
            this.buttonNotSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_TextDn = new System.Windows.Forms.Label();
            this.label_TextUp = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(15, 96);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(149, 29);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonNotClose
            // 
            this.buttonNotClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonNotClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNotClose.Location = new System.Drawing.Point(373, 96);
            this.buttonNotClose.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.buttonNotClose.Name = "buttonNotClose";
            this.buttonNotClose.Size = new System.Drawing.Size(151, 29);
            this.buttonNotClose.TabIndex = 1;
            this.buttonNotClose.Text = "Не закрывать";
            this.buttonNotClose.UseVisualStyleBackColor = true;
            // 
            // buttonNotSave
            // 
            this.buttonNotSave.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonNotSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNotSave.Location = new System.Drawing.Point(194, 96);
            this.buttonNotSave.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.buttonNotSave.Name = "buttonNotSave";
            this.buttonNotSave.Size = new System.Drawing.Size(149, 29);
            this.buttonNotSave.TabIndex = 2;
            this.buttonNotSave.Text = "Не сохранять";
            this.buttonNotSave.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonNotClose, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonNotSave, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_TextDn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_TextUp, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(539, 135);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label_TextDn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label_TextDn, 3);
            this.label_TextDn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_TextDn.Location = new System.Drawing.Point(3, 43);
            this.label_TextDn.Name = "label_TextDn";
            this.label_TextDn.Size = new System.Drawing.Size(533, 43);
            this.label_TextDn.TabIndex = 3;
            this.label_TextDn.Text = "Что будем делать?";
            this.label_TextDn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_TextUp
            // 
            this.label_TextUp.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label_TextUp, 3);
            this.label_TextUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_TextUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_TextUp.Location = new System.Drawing.Point(3, 0);
            this.label_TextUp.Name = "label_TextUp";
            this.label_TextUp.Size = new System.Drawing.Size(533, 43);
            this.label_TextUp.TabIndex = 4;
            this.label_TextUp.Text = "Документ был изменен с момента последнего сохранения.";
            this.label_TextUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Question
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonNotSave;
            this.ClientSize = new System.Drawing.Size(539, 135);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Question";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label label_TextDn;
        public System.Windows.Forms.Label label_TextUp;
        public System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.Button buttonNotClose;
        public System.Windows.Forms.Button buttonNotSave;
    }
}