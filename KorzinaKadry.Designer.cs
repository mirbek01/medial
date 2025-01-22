namespace DSS
{
    partial class KorzinaKadry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KorzinaKadry));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelAll = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStripCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator = new System.Windows.Forms.ToolStripSeparator();
            this.cleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalVievDataGridView = new System.Windows.Forms.DataGridView();
            this.PFIO_GridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nachal_GridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BD_GridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prof_GridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personalVievBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.___BASA__DataSet = new DSS.___BASA__DataSet();
            this.personalVievTableAdapter = new DSS.___BASA__DataSetTableAdapters.PersonalVievTableAdapter();
            this.tableAdapterManager = new DSS.___BASA__DataSetTableAdapters.TableAdapterManager();
            this.kadryTableAdapter = new DSS.___BASA__DataSetTableAdapters.KadryTableAdapter();
            this.toolStripMain.SuspendLayout();
            this.contextMenuStripCell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personalVievDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalVievBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.___BASA__DataSet)).BeginInit();
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
            this.toolStripMain.Size = new System.Drawing.Size(630, 36);
            this.toolStripMain.TabIndex = 1;
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
            // contextMenuStripCell
            // 
            this.contextMenuStripCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.delToolStripMenuItem,
            this.Separator,
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
            // Separator
            // 
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(176, 6);
            // 
            // cleanToolStripMenuItem
            // 
            this.cleanToolStripMenuItem.Name = "cleanToolStripMenuItem";
            this.cleanToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.cleanToolStripMenuItem.Text = "Очистить Корзину";
            this.cleanToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // personalVievDataGridView
            // 
            this.personalVievDataGridView.AllowUserToAddRows = false;
            this.personalVievDataGridView.AllowUserToDeleteRows = false;
            this.personalVievDataGridView.AllowUserToResizeColumns = false;
            this.personalVievDataGridView.AllowUserToResizeRows = false;
            this.personalVievDataGridView.AutoGenerateColumns = false;
            this.personalVievDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.personalVievDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.personalVievDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personalVievDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PFIO_GridViewTextBoxColumn,
            this.Nachal_GridViewTextBoxColumn,
            this.BD_GridViewTextBoxColumn,
            this.Prof_GridViewTextBoxColumn});
            this.personalVievDataGridView.ContextMenuStrip = this.contextMenuStripCell;
            this.personalVievDataGridView.DataSource = this.personalVievBindingSource;
            this.personalVievDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personalVievDataGridView.Location = new System.Drawing.Point(0, 36);
            this.personalVievDataGridView.MultiSelect = false;
            this.personalVievDataGridView.Name = "personalVievDataGridView";
            this.personalVievDataGridView.ReadOnly = true;
            this.personalVievDataGridView.RowHeadersVisible = false;
            this.personalVievDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.personalVievDataGridView.Size = new System.Drawing.Size(630, 349);
            this.personalVievDataGridView.TabIndex = 4;
            this.personalVievDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.personalVievDataGridView_CellMouseDown);
            // 
            // PFIO_GridViewTextBoxColumn
            // 
            this.PFIO_GridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PFIO_GridViewTextBoxColumn.DataPropertyName = "DFIO";
            this.PFIO_GridViewTextBoxColumn.HeaderText = "Ф.И.О.";
            this.PFIO_GridViewTextBoxColumn.Name = "PFIO_GridViewTextBoxColumn";
            this.PFIO_GridViewTextBoxColumn.ReadOnly = true;
            // 
            // Nachal_GridViewTextBoxColumn
            // 
            this.Nachal_GridViewTextBoxColumn.DataPropertyName = "Nachal";
            this.Nachal_GridViewTextBoxColumn.HeaderText = "Принят на работу";
            this.Nachal_GridViewTextBoxColumn.Name = "Nachal_GridViewTextBoxColumn";
            this.Nachal_GridViewTextBoxColumn.ReadOnly = true;
            this.Nachal_GridViewTextBoxColumn.Width = 121;
            // 
            // BD_GridViewTextBoxColumn
            // 
            this.BD_GridViewTextBoxColumn.DataPropertyName = "DBD";
            this.BD_GridViewTextBoxColumn.HeaderText = "Дата рождения";
            this.BD_GridViewTextBoxColumn.Name = "BD_GridViewTextBoxColumn";
            this.BD_GridViewTextBoxColumn.ReadOnly = true;
            this.BD_GridViewTextBoxColumn.Width = 111;
            // 
            // Prof_GridViewTextBoxColumn
            // 
            this.Prof_GridViewTextBoxColumn.DataPropertyName = "PersProfessia";
            this.Prof_GridViewTextBoxColumn.HeaderText = "Должность";
            this.Prof_GridViewTextBoxColumn.Name = "Prof_GridViewTextBoxColumn";
            this.Prof_GridViewTextBoxColumn.ReadOnly = true;
            this.Prof_GridViewTextBoxColumn.Width = 90;
            // 
            // personalVievBindingSource
            // 
            this.personalVievBindingSource.DataMember = "PersonalViev";
            this.personalVievBindingSource.DataSource = this.___BASA__DataSet;
            this.personalVievBindingSource.Sort = "DFIO";
            // 
            // ___BASA__DataSet
            // 
            this.___BASA__DataSet.DataSetName = "___BASA__DataSet";
            this.___BASA__DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personalVievTableAdapter
            // 
            this.personalVievTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AnamnezTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DiagnosisTableAdapter = null;
            this.tableAdapterManager.DolgTableAdapter = null;
            this.tableAdapterManager.GorodTableAdapter = null;
            this.tableAdapterManager.KadryTableAdapter = this.kadryTableAdapter;
            this.tableAdapterManager.KartaTableAdapter = null;
            this.tableAdapterManager.KartyTableAdapter = null;
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
            // kadryTableAdapter
            // 
            this.kadryTableAdapter.ClearBeforeFill = true;
            // 
            // KorzinaKadry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 385);
            this.Controls.Add(this.personalVievDataGridView);
            this.Controls.Add(this.toolStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "KorzinaKadry";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Корзина Личных Дел";
            this.Load += new System.EventHandler(this.KorzinaKadry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KorzinaKadry_KeyDown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.contextMenuStripCell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.personalVievDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalVievBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.___BASA__DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonBack;
        private System.Windows.Forms.ToolStripButton toolStripButtonDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCell;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator Separator;
        private System.Windows.Forms.ToolStripMenuItem cleanToolStripMenuItem;
        private ___BASA__DataSet ___BASA__DataSet;
        private System.Windows.Forms.BindingSource personalVievBindingSource;
        private DSS.___BASA__DataSetTableAdapters.PersonalVievTableAdapter personalVievTableAdapter;
        private DSS.___BASA__DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView personalVievDataGridView;
        private DSS.___BASA__DataSetTableAdapters.KadryTableAdapter kadryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFIO_GridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nachal_GridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BD_GridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prof_GridViewTextBoxColumn;
    }
}