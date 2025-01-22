namespace DSS
{
    partial class KorzinaKart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KorzinaKart));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelAll = new System.Windows.Forms.ToolStripButton();
            this.___BASA__DataSet = new DSS.___BASA__DataSet();
            this.kartyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kartyTableAdapter = new DSS.___BASA__DataSetTableAdapters.KartyTableAdapter();
            this.tableAdapterManager = new DSS.___BASA__DataSetTableAdapters.TableAdapterManager();
            this.kartyDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nachal_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kartaTableAdapter = new DSS.___BASA__DataSetTableAdapters.KartaTableAdapter();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.___BASA__DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kartyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kartyDataGridView)).BeginInit();
            this.contextMenuStripCell.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackColor = System.Drawing.Color.LightBlue;
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBack,
            this.toolStripButtonDel,
            this.toolStripSeparator1,
            this.toolStripButtonDelAll});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMain.Size = new System.Drawing.Size(644, 36);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.Image = global::DSS.Properties.Resources.Back;
            this.toolStripButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Size = new System.Drawing.Size(81, 33);
            this.toolStripButtonBack.Text = "Восстановить";
            this.toolStripButtonBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonBack.Click += new System.EventHandler(this.toolStripButtonBack_Click);
            // 
            // toolStripButtonDel
            // 
            this.toolStripButtonDel.Image = global::DSS.Properties.Resources.Del;
            this.toolStripButtonDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDel.Name = "toolStripButtonDel";
            this.toolStripButtonDel.Size = new System.Drawing.Size(130, 33);
            this.toolStripButtonDel.Text = "Удалить окончательно";
            this.toolStripButtonDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonDel.Click += new System.EventHandler(this.toolStripButtonDel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripButtonDelAll
            // 
            this.toolStripButtonDelAll.Image = global::DSS.Properties.Resources.TrashAmp;
            this.toolStripButtonDelAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelAll.Name = "toolStripButtonDelAll";
            this.toolStripButtonDelAll.Size = new System.Drawing.Size(105, 33);
            this.toolStripButtonDelAll.Text = "Очистить Корзину";
            this.toolStripButtonDelAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonDelAll.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // ___BASA__DataSet
            // 
            this.___BASA__DataSet.DataSetName = "___BASA__DataSet";
            this.___BASA__DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kartyBindingSource
            // 
            this.kartyBindingSource.DataMember = "Karty";
            this.kartyBindingSource.DataSource = this.___BASA__DataSet;
            this.kartyBindingSource.Sort = "PFIO";
            // 
            // kartyTableAdapter
            // 
            this.kartyTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AnamnezTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DiagnosisTableAdapter = null;
            this.tableAdapterManager.DolgTableAdapter = null;
            this.tableAdapterManager.GorodTableAdapter = null;
            this.tableAdapterManager.KadryTableAdapter = null;
            this.tableAdapterManager.KartaTableAdapter = null;
            this.tableAdapterManager.KartyTableAdapter = this.kartyTableAdapter;
            this.tableAdapterManager.ObektTableAdapter = null;
            this.tableAdapterManager.OblastTableAdapter = null;
            this.tableAdapterManager.PatientsProfessiaTableAdapter = null;
            this.tableAdapterManager.PatientsRabotaTableAdapter = null;
            this.tableAdapterManager.PatientsTableAdapter = null;
            this.tableAdapterManager.PersonalProfessiaTableAdapter = null;
            this.tableAdapterManager.PersonalTableAdapter = null;
            this.tableAdapterManager.PlataTableAdapter = null;
            this.tableAdapterManager.PosesenieTableAdapter = null;
            this.tableAdapterManager.PredoplataTableAdapter = null;
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
            // kartyDataGridView
            // 
            this.kartyDataGridView.AllowUserToAddRows = false;
            this.kartyDataGridView.AllowUserToDeleteRows = false;
            this.kartyDataGridView.AllowUserToResizeColumns = false;
            this.kartyDataGridView.AutoGenerateColumns = false;
            this.kartyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.kartyDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.kartyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kartyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn_1,
            this.dataGridViewTextBoxColumn_2,
            this.Nachal_3,
            this.dataGridViewTextBoxColumn_4});
            this.kartyDataGridView.ContextMenuStrip = this.contextMenuStripCell;
            this.kartyDataGridView.DataSource = this.kartyBindingSource;
            this.kartyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kartyDataGridView.Location = new System.Drawing.Point(0, 36);
            this.kartyDataGridView.MultiSelect = false;
            this.kartyDataGridView.Name = "kartyDataGridView";
            this.kartyDataGridView.ReadOnly = true;
            this.kartyDataGridView.RowHeadersVisible = false;
            this.kartyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kartyDataGridView.Size = new System.Drawing.Size(644, 320);
            this.kartyDataGridView.TabIndex = 3;
            this.kartyDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.kartyDataGridView_CellMouseDown);
            // 
            // dataGridViewTextBoxColumn_1
            // 
            this.dataGridViewTextBoxColumn_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn_1.DataPropertyName = "PFIO";
            this.dataGridViewTextBoxColumn_1.HeaderText = "Ф.И.О.";
            this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn_1";
            this.dataGridViewTextBoxColumn_1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn_2
            // 
            this.dataGridViewTextBoxColumn_2.DataPropertyName = "PNK";
            this.dataGridViewTextBoxColumn_2.HeaderText = "№ Карты";
            this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn_2";
            this.dataGridViewTextBoxColumn_2.ReadOnly = true;
            this.dataGridViewTextBoxColumn_2.Width = 78;
            // 
            // Nachal_3
            // 
            this.Nachal_3.DataPropertyName = "Nachal";
            this.Nachal_3.HeaderText = "Дата регистрации";
            this.Nachal_3.Name = "Nachal_3";
            this.Nachal_3.ReadOnly = true;
            this.Nachal_3.Width = 125;
            // 
            // dataGridViewTextBoxColumn_4
            // 
            this.dataGridViewTextBoxColumn_4.DataPropertyName = "PBD";
            this.dataGridViewTextBoxColumn_4.HeaderText = "Дата рождения";
            this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn_4";
            this.dataGridViewTextBoxColumn_4.ReadOnly = true;
            this.dataGridViewTextBoxColumn_4.Width = 111;
            // 
            // contextMenuStripCell
            // 
            this.contextMenuStripCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.delToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cleanToolStripMenuItem});
            this.contextMenuStripCell.Name = "contextMenuStrip1";
            this.contextMenuStripCell.ShowImageMargin = false;
            this.contextMenuStripCell.Size = new System.Drawing.Size(180, 76);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.backToolStripMenuItem.Text = "Восстановить";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonBack_Click);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.delToolStripMenuItem.Text = "Удалить окончательно";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonDel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 6);
            // 
            // cleanToolStripMenuItem
            // 
            this.cleanToolStripMenuItem.Name = "cleanToolStripMenuItem";
            this.cleanToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.cleanToolStripMenuItem.Text = "Очистить Корзину";
            this.cleanToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // kartaTableAdapter
            // 
            this.kartaTableAdapter.ClearBeforeFill = true;
            // 
            // KorzinaKart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 356);
            this.Controls.Add(this.kartyDataGridView);
            this.Controls.Add(this.toolStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "KorzinaKart";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Корзина Карточек Пациентов";
            this.Load += new System.EventHandler(this.KorzinaKart_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KorzinaKart_KeyDown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.___BASA__DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kartyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kartyDataGridView)).EndInit();
            this.contextMenuStripCell.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private ___BASA__DataSet ___BASA__DataSet;
        private System.Windows.Forms.BindingSource kartyBindingSource;
        private DSS.___BASA__DataSetTableAdapters.KartyTableAdapter kartyTableAdapter;
        private DSS.___BASA__DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView kartyDataGridView;
        private System.Windows.Forms.ToolStripButton toolStripButtonBack;
        private System.Windows.Forms.ToolStripButton toolStripButtonDel;
        private DSS.___BASA__DataSetTableAdapters.KartaTableAdapter kartaTableAdapter;
       
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCell;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cleanToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nachal_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;
    }
}