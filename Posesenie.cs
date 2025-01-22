/*
* Copyright (c) 2010, Демченко Сергей Сергеевич, doctor.dss@mail.ru
*
* Разрешается повторное распространение и использование как в виде исходного
* кода, так и в двоичной форме, с изменениями или без, при соблюдении
* следующих условий:
*
*     * При повторном распространении исходного кода должно оставаться
*       указанное выше уведомление об авторском праве, этот список условий и
*       последующий отказ от гарантий.
*     * При повторном распространении двоичного кода должна сохраняться
*       указанная выше информация об авторском праве, этот список условий и
*       последующий отказ от гарантий в документации и/или в других
*       материалах, поставляемых при распространении.
*
* ЭТА ПРОГРАММА ПРЕДОСТАВЛЕНА ВЛАДЕЛЬЦАМИ АВТОРСКИХ ПРАВ И/ИЛИ ДРУГИМИ
* СТОРОНАМИ "КАК ОНА ЕСТЬ" БЕЗ КАКОГО-ЛИБО ВИДА ГАРАНТИЙ, ВЫРАЖЕННЫХ ЯВНО
* ИЛИ ПОДРАЗУМЕВАЕМЫХ, ВКЛЮЧАЯ, НО НЕ ОГРАНИЧИВАЯСЬ ИМИ, ПОДРАЗУМЕВАЕМЫЕ
* ГАРАНТИИ КОММЕРЧЕСКОЙ ЦЕННОСТИ И ПРИГОДНОСТИ ДЛЯ КОНКРЕТНОЙ ЦЕЛИ. НИ В
* КОЕМ СЛУЧАЕ, ЕСЛИ НЕ ТРЕБУЕТСЯ СООТВЕТСТВУЮЩИМ ЗАКОНОМ, ИЛИ НЕ УСТАНОВЛЕНО
* В УСТНОЙ ФОРМЕ, НИ ОДИН ВЛАДЕЛЕЦ АВТОРСКИХ ПРАВ И НИ ОДНО  ДРУГОЕ ЛИЦО,
* КОТОРОЕ МОЖЕТ ИЗМЕНЯТЬ И/ИЛИ ПОВТОРНО РАСПРОСТРАНЯТЬ ПРОГРАММУ, КАК БЫЛО
* СКАЗАНО ВЫШЕ, НЕ НЕСЁТ ОТВЕТСТВЕННОСТИ, ВКЛЮЧАЯ ЛЮБЫЕ ОБЩИЕ, СЛУЧАЙНЫЕ,
* СПЕЦИАЛЬНЫЕ ИЛИ ПОСЛЕДОВАВШИЕ УБЫТКИ, ВСЛЕДСТВИЕ ИСПОЛЬЗОВАНИЯ ИЛИ
* НЕВОЗМОЖНОСТИ ИСПОЛЬЗОВАНИЯ ПРОГРАММЫ (ВКЛЮЧАЯ, НО НЕ ОГРАНИЧИВАЯСЬ
* ПОТЕРЕЙ ДАННЫХ, ИЛИ ДАННЫМИ, СТАВШИМИ НЕПРАВИЛЬНЫМИ, ИЛИ ПОТЕРЯМИ
* ПРИНЕСЕННЫМИ ИЗ-ЗА ВАС ИЛИ ТРЕТЬИХ ЛИЦ, ИЛИ ОТКАЗОМ ПРОГРАММЫ РАБОТАТЬ
* СОВМЕСТНО С ДРУГИМИ ПРОГРАММАМИ), ДАЖЕ ЕСЛИ ТАКОЙ ВЛАДЕЛЕЦ ИЛИ ДРУГОЕ
* ЛИЦО БЫЛИ ИЗВЕЩЕНЫ О ВОЗМОЖНОСТИ ТАКИХ УБЫТКОВ.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DSS
{
    public partial class Posesenie : Form
    {
        public Posesenie()
        {
            InitializeComponent();
        }

        ___BASA__DataSet.PosesenieRow PosRow;
        int PID = 0;
        string Pfio = "";
        int posesenieN = 0;
        Button zub;
        string btn = "";
        int DS_MY_heit = 5;
        int TR_MY_heit = 5;
        DateTime now = DateTime.Now;

        private void Posesenie_Load(object sender, EventArgs e)
        {
            posesenieTableAdapter.Adapter.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(PosesenieAdapter_RowUpdated);
            treatDSTableAdapter.Adapter.RowUpdated += new OleDbRowUpdatedEventHandler(DSAdapter_RowUpdated);
            treatTreatTableAdapter.Adapter.RowUpdated += new OleDbRowUpdatedEventHandler(TRAdapter_RowUpdated);

            PID = (int)this.Tag;

            Pfio = patientsTableAdapter.GetDataBy(PID)[0].PFIO;
            labelPatFIO.Text = Pfio;
            this.Text = "Лечение: " + Pfio;

            PosRow = ___bASA__DataSet.Posesenie.NewPosesenieRow();
            PosRow.Personal = 0;
            PosRow.Patient = PID;
            PosRow.Narad = false;
            PosRow.Data = now;
            PosRow.Summa = 0;
            PosRow.Zaloby = PosRow.Anamnez = PosRow.Obekt = PosRow.Treat = PosRow.Diagnos = "";
            ___bASA__DataSet.Posesenie.AddPosesenieRow(PosRow);
            personalVievTableAdapter1.FillBy(___bASA__DataSet.PersonalViev, true, true);

            this.anamnezTableAdapter.FillByReal(this.___bASA__DataSet.Anamnez, true);
            obektTableAdapter.FillByReal(this.___bASA__DataSet.Obekt, true);
            zalobyTableAdapter.FillByReal(___bASA__DataSet.Zaloby, true);
            diagnosisTableAdapter.FillByReal(___bASA__DataSet.Diagnosis, true);
            treatTableAdapter.FillByReal(___bASA__DataSet.Treat, true);
            splitContainer_TR.Panel2Collapsed = splitContainer_DS.Panel2Collapsed = true;

            toolStripButtonNarad.Enabled = toolStripButton_Save.Enabled = toolStripButtonNoNarad.Enabled = false;
        }

        void TRAdapter_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", treatTreatTableAdapter.Connection);
                cmdNewID.Transaction = treatTreatTableAdapter.Transaction;  // Retrieve the Autonumber and store it in the CategoryID column.

                ((___BASA__DataSet.TreatTreatRow)e.Row).ID = (int)cmdNewID.ExecuteScalar();
                e.Status = UpdateStatus.SkipCurrentRow;

            }
        }

        void DSAdapter_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", treatDSTableAdapter.Connection);
                cmdNewID.Transaction = treatDSTableAdapter.Transaction;  // Retrieve the Autonumber and store it in the CategoryID column.

                ((___BASA__DataSet.TreatDSRow)e.Row).ID = (int)cmdNewID.ExecuteScalar();
                e.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        void PosesenieAdapter_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", posesenieTableAdapter.Connection);
                cmdNewID.Transaction = posesenieTableAdapter.Transaction;  // Retrieve the Autonumber and store it in the CategoryID column.

                ((___BASA__DataSet.PosesenieRow)e.Row).ID = (int)cmdNewID.ExecuteScalar();
            }
        }

        private void FirstTreeNode(___BASA__DataSet.ZalobyDataTable table, TreeView trr)
        {
            trr.Nodes.Clear();
            DataRow[] firstRow = table.Select("ParID=0");
            foreach (DataRow f in firstRow)
            {
                TreeNode tn = new TreeNode();

                DataRow[] secondRow = table.Select("ParID=" + f["ID"].ToString());
                if (secondRow.Length == 0)
                {
                    tn = trr.Nodes.Add(f["ID"].ToString(), f["Names"].ToString());
                    tn.ContextMenuStrip = contextMenuStripTree;
                }
                else
                {
                    tn = trr.Nodes.Add("", f["Names"].ToString());
                    AddTreeNodes(tn, secondRow, table);
                }
                tn.Tag = f;
            }
        }


        private void FirstTreeNode(___BASA__DataSet.AnamnezDataTable table, TreeView trr)
        {
            trr.Nodes.Clear();
            DataRow[] firstRow = table.Select("ParID=0");
            foreach (DataRow f in firstRow)
            {
                TreeNode tn = new TreeNode();

                DataRow[] secondRow = table.Select("ParID=" + f["ID"].ToString());
                if (secondRow.Length == 0)
                {
                    tn = trr.Nodes.Add(f["ID"].ToString(), f["Names"].ToString());
                    tn.ContextMenuStrip = contextMenuStripTree;
                }
                else
                {
                    tn = trr.Nodes.Add("", f["Names"].ToString());
                    AddTreeNodes(tn, secondRow, table);
                }
                tn.Tag = f;
            }
        }

        private void FirstTreeNode(___BASA__DataSet.ObektDataTable table, TreeView trr)
        {
            trr.Nodes.Clear();
            DataRow[] firstRow = table.Select("ParID=0");
            foreach (DataRow f in firstRow)
            {
                TreeNode tn = new TreeNode();

                DataRow[] secondRow = table.Select("ParID=" + f["ID"].ToString());
                if (secondRow.Length == 0)
                {
                    tn = trr.Nodes.Add(f["ID"].ToString(), f["Names"].ToString());
                    tn.ContextMenuStrip = contextMenuStripTree;
                }
                else
                {
                    tn = trr.Nodes.Add("", f["Names"].ToString());
                    AddTreeNodes(tn, secondRow, table);
                }
                tn.Tag = f;
            }
        }


        private void FirstTreeNode(___BASA__DataSet.DiagnosisDataTable table, TreeView trr)
        {
            trr.Nodes.Clear();
            DataRow[] firstRow = table.Select("ParID=0");
            foreach (DataRow f in firstRow)
            {
                TreeNode tn = new TreeNode();

                DataRow[] secondRow = table.Select("ParID=" + f["ID"].ToString());
                if (secondRow.Length == 0)
                {
                    tn = trr.Nodes.Add(f["ID"].ToString(), f["Names"].ToString());
                    tn.ContextMenuStrip = contextMenuStripTree;
                }
                else
                {
                    tn = trr.Nodes.Add("", f["Names"].ToString());
                    AddTreeNodes(tn, secondRow, table);
                }
                tn.Tag = f;
            }
        }

        private void FirstTreeNode(___BASA__DataSet.TreatDataTable table, TreeView trr)
        {
            trr.Nodes.Clear();
            DataRow[] firstRow = table.Select("ParID=0");
            foreach (DataRow f in firstRow)
            {
                TreeNode tn = new TreeNode();

                DataRow[] secondRow = table.Select("ParID=" + f["ID"].ToString());
                if (secondRow.Length == 0)
                {
                    tn = trr.Nodes.Add(f["ID"].ToString(), f["Names"].ToString() + " (цена:" + f["Money"].ToString() + ")");
                    tn.ContextMenuStrip = contextMenuStripTree;
                }

                else
                {
                    tn = trr.Nodes.Add("", f["Names"].ToString());
                    AddTreeNodes(tn, secondRow, table);
                }
                tn.Tag = f;
            }
        }

        private void AddTreeNodes(TreeNode tn, DataRow[] secondRow, DataTable table)
        {

            foreach (DataRow f in secondRow)
            {
                TreeNode lactNode = new TreeNode();

                DataRow[] last = table.Select("ParID=" + f["ID"].ToString());
                if (tn.TreeView == treeView_Tr && last.Length == 0)
                {
                    lactNode = tn.Nodes.Add(f["ID"].ToString(), f["Names"].ToString() + " (цена:" + f["Money"].ToString() + ")");
                    lactNode.ContextMenuStrip = contextMenuStripTree;
                }
                else if (tn.TreeView != treeView_Tr && last.Length == 0)
                {
                    lactNode = tn.Nodes.Add(f["ID"].ToString(), f["Names"].ToString());
                    lactNode.ContextMenuStrip = contextMenuStripTree;
                }
                else
                {
                    lactNode = tn.Nodes.Add("", f["Names"].ToString());
                    AddTreeNodes(lactNode, last, table);
                }
                lactNode.Tag = f;

            }
        }

        void node_Select(TreeNode nod, TextBox txt)
        {
            if (nod.Name != "")
            { txt.Text = ((DataRow)nod.Tag)["Texts"].ToString(); }
            else { txt.Text = ""; }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            node_Select(e.Node, textBoxView);
        }

        void rightPanel_show()
        {
            if (!panelRight.Visible)
            { panelRight.Visible = true; }
            textBoxView.Text = "";
            treeView_Right.Focus();
        }

        private void buttonZub_Click(object sender, EventArgs e)
        {
            if (zub != null)
            {
                zub.FlatStyle = FlatStyle.Standard;
                zub.Margin = new Padding(1);//.Popup;}
            }
            labelForzubTR.Visible = labelForZubDS.Visible = true;
            labelDS_Choose_Zub.Text = labelTr_Choos_Zub.Text = (string)((Button)sender).Tag;
            textBox_TtView.Text = textBox_DSview.Text = "";

            treatTableAdapter.FillByReal(___bASA__DataSet.Treat, true);
            diagnosisTableAdapter.FillByReal(___bASA__DataSet.Diagnosis, true);
            treatDSBindingSource2.Filter = treatTreatBindingSource2.Filter = "Zub=" + (string)((Button)sender).Tag;
            FirstTreeNode(___bASA__DataSet.Diagnosis, treeView_DS);
            FirstTreeNode(___bASA__DataSet.Treat, treeView_Tr);
            panelDs_Tr.Visible = true;
            btn = (string)((Button)sender).Tag;

            zub = ((Button)sender);
            zub.FlatStyle = FlatStyle.Popup;
            zub.Margin = new Padding(0);
        }

        private void treeViewDS_AfterSelect(object sender, TreeViewEventArgs e)
        {
            node_Select(e.Node, textBox_DSview);
        }

        private void treeView_Tr_AfterSelect(object sender, TreeViewEventArgs e)
        {
            node_Select(e.Node, textBox_TtView);
        }

        void add_DS()
        {
            if (treeView_DS.SelectedNode != null && treeView_DS.SelectedNode.Name != "")
            {
                ___BASA__DataSet.TreatDSRow addedTrTD = ___bASA__DataSet.TreatDS.NewTreatDSRow();
                addedTrTD.Posesenie = posesenieN;
                addedTrTD.Zub = Convert.ToInt32(btn);
                addedTrTD.PS = "";
                addedTrTD.Diagnos = ((___BASA__DataSet.DiagnosisRow)treeView_DS.SelectedNode.Tag).ID;
                addedTrTD.DSZ = ((___BASA__DataSet.DiagnosisRow)treeView_DS.SelectedNode.Tag).Texts;
                ___bASA__DataSet.TreatDS.AddTreatDSRow(addedTrTD);
                if (zub != null && btn != "0")
                {
                    zub.BackColor = Color.Lime;
                }
                toolStripButton_Save.Enabled = true;
            }
        }

        private void button_takeDS_Click(object sender, EventArgs e)
        {
            add_DS();
        }

        void add_TR()
        {
            if (textBoxSkolko.Text == "")
            { textBoxSkolko.Text = "1"; }

            bool da = true;
            try
            { Convert.ToUInt32(textBoxSkolko.Text); }
            catch
            {
                MessageBox.Show("Количество манипуляций должно быть целым числом.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                da = false;
            }
            if (treeView_Tr.SelectedNode != null && treeView_Tr.SelectedNode.Name != "" && da)
            {
                ___BASA__DataSet.TreatTreatRow addedTRTR = ___bASA__DataSet.TreatTreat.NewTreatTreatRow();
                addedTRTR.Posesenie = posesenieN;
                addedTRTR.Zub = Convert.ToInt32(btn);
                addedTRTR.PS = "";
                addedTRTR.Treat = ((___BASA__DataSet.TreatRow)treeView_Tr.SelectedNode.Tag).ID;
                addedTRTR.Skolko = Convert.ToInt32(textBoxSkolko.Text);
                addedTRTR.TRZ = ((___BASA__DataSet.TreatRow)treeView_Tr.SelectedNode.Tag).Texts;
                addedTRTR.Moneys = ((___BASA__DataSet.TreatRow)treeView_Tr.SelectedNode.Tag).Money;
                ___bASA__DataSet.TreatTreat.AddTreatTreatRow(addedTRTR);
                if (zub != null && btn != "0")
                {
                    zub.BackColor = Color.Lime;
                }
                textBoxSkolko.Text = "";
                toolStripButton_Save.Enabled = true;
            }
        }

        private void button_takeTR_Click(object sender, EventArgs e)
        {
            add_TR();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Save(false, false);
        }

        private void panelDs_Tr_VisibleChanged(object sender, EventArgs e)
        {
            if (panelDs_Tr.Visible)
            { panelRight.Visible = false; }
        }

        private void panelRight_VisibleChanged(object sender, EventArgs e)
        {
            if (panelRight.Visible)
            { panelDs_Tr.Visible = false; }
        }

        private void buttonTakeRight_Click(object sender, EventArgs e)
        {
            takeZal_Obekt();
            treeView_Right.Focus();
        }

        void takeZal_Obekt()
        {
            if (treeView_Right.SelectedNode != null)
            {
                ((RichTextBox)buttonTakeRight.Tag).Text += textBoxView.Text; //treeView1.SelectedNode.Name;

                toolStripButton_Save.Enabled = true;
            }
        }

        private void Clean_Zub_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (DataRow r in ___bASA__DataSet.TreatTreat.Select("Zub=" + (string)contextMenuStripZub.SourceControl.Tag))
            { r.Delete(); }


            foreach (DataRow r in ___bASA__DataSet.TreatDS.Select("Zub=" + (string)contextMenuStripZub.SourceControl.Tag))
            { r.Delete(); }

            contextMenuStripZub.SourceControl.BackColor = Color.WhiteSmoke;
        }

        private void treeViewDS_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            add_DS();
        }


        void del_DS_TR(BindingSource bs)
        {
            if (bs.Current != null)
            {
                bs.RemoveCurrent();
            }

            if (treatDSBindingSource2.Count == 0 && treatTreatBindingSource2.Count == 0)
            { zub.BackColor = Color.WhiteSmoke; }
        }

        private void toolStripButton_DelDS_Click(object sender, EventArgs e)
        {
            del_DS_TR(treatDSBindingSource2);
        }

        private void toolStripButton_DelDSALL_Click(object sender, EventArgs e)
        {
            del_DS_TR_All(___bASA__DataSet.TreatDS, treatDSBindingSource2);
        }

        void del_DS_TR_All(DataTable dt, BindingSource s)
        {
            foreach (DataRow r in dt.Select(s.Filter))
            { r.Delete(); }
            if (treatDSBindingSource2.Count == 0 && treatTreatBindingSource2.Count == 0)
            {
                if (s.Filter != "Zub=0")
                {
                    zub.BackColor = Color.WhiteSmoke;
                }
            }
        }


        private void buttonChoosDS_Click(object sender, EventArgs e)
        {
            diagnosisTableAdapter.FillByReal(___bASA__DataSet.Diagnosis, true);
            FirstTreeNode(___bASA__DataSet.Diagnosis, treeView_DS);

            toolStripButtonTakeDS.Visible = true;
            toolStripButtonTakeTR.Visible = false;
            toolStripLabel1.Text = "Выбираем Диагноз";
            treeView_DS.Visible = true;
            panel20.Visible = true;
            panel18.Visible = false;
            treeView_Tr.Visible = false;
            treeView_DS.BringToFront();
        }

        private void buttonChoosTR_Click(object sender, EventArgs e)
        {
            treatTableAdapter.FillByReal(___bASA__DataSet.Treat, true);
            FirstTreeNode(___bASA__DataSet.Treat, treeView_Tr);

            toolStripButtonTakeDS.Visible = false;
            toolStripButtonTakeTR.Visible = true;
            toolStripLabel1.Text = "Выбираем Лечение";

            treeView_Tr.Visible = true;
            panel18.Visible = true;

            treeView_DS.Visible = false;
            panel20.Visible = false;

            treeView_Tr.BringToFront();
        }

        private void toolStripButton_DelTR_Click(object sender, EventArgs e)
        {
            del_DS_TR(treatTreatBindingSource2);
        }

        private void toolStripButton_DelTR_All_Click(object sender, EventArgs e)
        {
            del_DS_TR_All(___bASA__DataSet.TreatTreat, treatTreatBindingSource2);

        }

        private void treeView_Tr_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            add_TR();
        }

        private void toolStripButtonChangeSkolko_Click(object sender, EventArgs e)
        {
            if (TrTr_dataGridView.CurrentCell != null)
            {
                TrTr_dataGridView.CurrentCell = TrTr_dataGridView.CurrentRow.Cells["Skolko"];
                TrTr_dataGridView.BeginEdit(true);
            }
        }

        private void TrTr_dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool da = true;
            try
            {
                Convert.ToUInt32(((DataGridView)sender).CurrentCell.Value);
            }
            catch
            {
                MessageBox.Show("Количество манипуляций должно быть целым числом.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ((DataGridView)sender).CancelEdit();
                da = false;
            }
            if (da)
            {
                treatTreatBindingSource2.EndEdit();
            }
        }

        private void TrTr_dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.ColumnIndex == ((DataGridView)sender).Columns["Skolko"].Index)
            {
                ((DataGridView)sender).CancelEdit();
                MessageBox.Show("Количество манипуляций должно быть целым числом.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void resiseRichText(Control cont, int heit)
        {
            cont.Parent.Height = heit + 10;
        }

        private void textBoxZaloby_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            resiseRichText((Control)sender, e.NewRectangle.Height);
        }


        private void textBoxObekt_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            resiseRichText((Control)sender, e.NewRectangle.Height);
        }

        int DSViewH = 20;

        void add_del_RowDS()
        {
            DSViewH = DS_DataGridView.RowTemplate.Height * DS_DataGridView.RowCount + 35;
            if (splitContainer_DS.Panel2Collapsed || (!splitContainer_DS.Panel2Collapsed && DS_MY_heit < DSViewH))
            {
                splitContainer_DS.Height = DSViewH;
            }
            else
            {
                splitContainer_DS.Height = DS_MY_heit;
            }
        }


        private void DS_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            add_del_RowDS();
        }


        private void Tr_dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            add_del_rowsTR();
        }

        int TRViewH = 20;
        void add_del_rowsTR()
        {
            TRViewH = Tr_dataGridView.RowTemplate.Height * Tr_dataGridView.RowCount + 45;

            if (splitContainer_TR.Panel2Collapsed || (!splitContainer_TR.Panel2Collapsed && TR_MY_heit < TRViewH))
            {

                splitContainer_TR.Height = TRViewH;
            }
            else
            {
                splitContainer_TR.Height = TR_MY_heit;
            }
        }

        private void Tr_dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            add_del_rowsTR();
        }

        private void DS_DataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            add_del_RowDS();
        }

        private void treeView_Right_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                takeZal_Obekt();
            }
        }

        private void treeViewDS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_DS();
            }
        }

        private void treeView_Tr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_TR();
            }
        }

        private string myDS()
        {
            int leng = ___bASA__DataSet.TreatDS.Select("", "", DataViewRowState.CurrentRows).Length;
            int[] ooo = new int[0];
            DataRow[] drs = ___bASA__DataSet.TreatDS.Select("", "Zub", DataViewRowState.CurrentRows);
            if (leng > 0)
            {
                ooo = new int[] { (int)drs[0]["Zub"] };
                foreach (DataRow dr in drs)
                {
                    bool b = false;
                    foreach (int o in ooo)
                    {
                        if ((int)dr["Zub"] == o)
                        {
                            b = true;
                            break;
                        }

                    }
                    if (!b)
                    {
                        int[] nov = new int[ooo.Length + 1];
                        ooo.CopyTo(nov, 0);
                        nov[ooo.Length] = (int)dr["Zub"];
                        ooo = nov;
                    }
                }
            }


            string full = "";
            foreach (int zb in ooo)
            {
                string str = "";
                if (zb != 0)
                {

                    str = zb.ToString() + " ЗУБ: ";
                }
                foreach (___BASA__DataSet.TreatDSRow dr in ___bASA__DataSet.TreatDS.Select("", "", DataViewRowState.CurrentRows))
                {
                    if (dr.Zub == zb)
                    { str += dr.DSZ + ";" + " "; }

                }
                full += str + "\r";

            }
            richTextBox_DS_MY.Text = full;
            return full;
        }

        private void richTextBox_DS_MY_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            DS_MY_heit = e.NewRectangle.Height + 10;
            if (DS_MY_heit > splitContainer_DS.Height || (DS_MY_heit < splitContainer_DS.Height && DS_MY_heit > DSViewH))
            {
                splitContainer_DS.Height = DS_MY_heit;
                splitContainer_DS.Panel2.SetBounds(splitContainer_DS.Panel2.Bounds.X, splitContainer_DS.Panel2.Bounds.Y, splitContainer_DS.Panel2.Width, DS_MY_heit);//..Refresh();
                splitContainer_DS.Panel1.SetBounds(splitContainer_DS.Panel1.Bounds.X, splitContainer_DS.Panel1.Bounds.Y, splitContainer_DS.Panel1.Width, DS_MY_heit);
            }
            else if (DS_MY_heit < splitContainer_DS.Height && DS_MY_heit < DSViewH)
            {
                splitContainer_DS.Height = DSViewH;
            }
        }
        private void richTextBoxAnamnez_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            resiseRichText((Control)sender, e.NewRectangle.Height);
        }

        private void toolStripSplitButtonZal_ButtonClick(object sender, EventArgs e)
        {

            labelCaption_Right.Text = "Выбираем ЖАЛОБЫ";
            zalobyTableAdapter.FillByReal(___bASA__DataSet.Zaloby, true);
            FirstTreeNode(___bASA__DataSet.Zaloby, treeView_Right);
            rightPanel_show();
            buttonTakeRight.Tag = textBoxZaloby;
        }

        private void toolStripSplitButtonOB_ButtonClick(object sender, EventArgs e)
        {
            labelCaption_Right.Text = "Выбираем ОБЪЕКТИВНЫЕ ДАННЫЕ";
            obektTableAdapter.FillByReal(___bASA__DataSet.Obekt, true);
            FirstTreeNode(___bASA__DataSet.Obekt, treeView_Right);
            rightPanel_show();
            buttonTakeRight.Tag = textBoxObekt;
        }

        private void cleanZalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxZaloby.Text = "";
        }

        private void cleanObToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxObekt.Text = "";
        }

        private void cleanAnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxAnamnez.Text = "";
        }

        private void myDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myDSToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                richTextBox_DS_MY.Text = "";
                myDSToolStripMenuItem.CheckState = CheckState.Checked;
                splitContainer_DS.Panel2Collapsed = false;
                myDS();
                richTextBox_DS_MY.Focus();
            }


            else if (myDSToolStripMenuItem.CheckState == CheckState.Checked)
            {
                myDSToolStripMenuItem.CheckState = CheckState.Unchecked;
                splitContainer_DS.Panel2Collapsed = true;
            }
        }

        private void toolStripMenuItem_MYTR_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem_MYTR.CheckState == CheckState.Unchecked)
            {
                richTextBox_TR_MY.Text = "";
                toolStripMenuItem_MYTR.CheckState = CheckState.Checked;
                splitContainer_TR.Panel2Collapsed = false;
                myTR();
                richTextBox_TR_MY.Focus();
            }


            else if (toolStripMenuItem_MYTR.CheckState == CheckState.Checked)
            {
                toolStripMenuItem_MYTR.CheckState = CheckState.Unchecked;
                splitContainer_TR.Panel2Collapsed = true;
            }
        }

        private string myTR()
        {
            int leng = ___bASA__DataSet.TreatTreat.Select("", "", DataViewRowState.CurrentRows).Length;
            int[] ooo = new int[0];
            DataRow[] drs = ___bASA__DataSet.TreatTreat.Select("", "Zub", DataViewRowState.CurrentRows);
            if (leng > 0)
            {
                ooo = new int[] { (int)drs[0]["Zub"] };
                foreach (DataRow dr in drs)
                {
                    bool b = false;
                    foreach (int o in ooo)
                    {
                        if ((int)dr["Zub"] == o)
                        {
                            b = true;
                            break;
                        }

                    }
                    if (!b)
                    {
                        int[] nov = new int[ooo.Length + 1];
                        ooo.CopyTo(nov, 0);
                        nov[ooo.Length] = (int)dr["Zub"];
                        ooo = nov;
                    }
                }
            }

            string full = "";
            foreach (int zb in ooo)
            {
                string str = "";
                if (zb != 0)
                {

                    str = zb.ToString() + " ЗУБ: ";
                }

                foreach (___BASA__DataSet.TreatTreatRow dr in ___bASA__DataSet.TreatTreat.Select("", "", DataViewRowState.CurrentRows))
                {
                    if (dr.Zub == zb)
                    { str += dr.TRZ + ";" + " "; }

                }
                full += str + "\r";
            }
            richTextBox_TR_MY.Text = full;
            return full;
        }

        private void richTextBox_TR_MY_ContentsResized_1(object sender, ContentsResizedEventArgs e)
        {
            TR_MY_heit = e.NewRectangle.Height + 10;
            if (TR_MY_heit > splitContainer_TR.Height || (TR_MY_heit < splitContainer_TR.Height && TR_MY_heit > TRViewH))
            {
                splitContainer_TR.Height = TR_MY_heit;
                splitContainer_TR.Panel2.SetBounds(splitContainer_TR.Panel2.Bounds.X, splitContainer_TR.Panel2.Bounds.Y, splitContainer_TR.Panel2.Width, TR_MY_heit);//..Refresh();
                splitContainer_TR.Panel1.SetBounds(splitContainer_TR.Panel1.Bounds.X, splitContainer_TR.Panel1.Bounds.Y, splitContainer_TR.Panel1.Width, TR_MY_heit);
            }
            else if (TR_MY_heit < splitContainer_TR.Height && TR_MY_heit < TRViewH)
            { splitContainer_TR.Height = TRViewH; }
        }


        private void treeView_Tr_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ((TreeView)sender).SelectedNode = e.Node;
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((TreeView)contextMenuStripTree.SourceControl == treeView_Tr)
            {
                add_TR();
            }

            else if ((TreeView)contextMenuStripTree.SourceControl == treeView_DS)
            {
                add_DS();
            }
            else if ((TreeView)contextMenuStripTree.SourceControl == treeView_Right)
            {
                takeZal_Obekt();
            }
        }

        void Save(bool onClose, bool isNarad)
        {
            DS_DataGridView.RowsAdded -= DS_DataGridView_RowsAdded;
            DS_DataGridView.RowsRemoved -= DS_DataGridView_RowsRemoved;
            Tr_dataGridView.RowsAdded -= Tr_dataGridView_RowsAdded;
            Tr_dataGridView.RowsRemoved -= Tr_dataGridView_RowsRemoved;
            richTextBox_TR_MY.ContentsResized -= richTextBox_TR_MY_ContentsResized_1;
            richTextBox_DS_MY.ContentsResized -= richTextBox_DS_MY_ContentsResized;

            this.Validate();
            if (dateTimePicker1.Value.Date != now.Date)
            {
                ___bASA__DataSet.Posesenie[0].Data = dateTimePicker1.Value.Date;
            }
            decimal d = numericUpDown1.Value;

            treatDSBindingSource.EndEdit();
            treatDSBindingSource2.EndEdit();
            treatTreatBindingSource.EndEdit();
            treatTreatBindingSource2.EndEdit();

            if (splitContainer_DS.Panel2Collapsed)
            { myDS(); }
            if (splitContainer_TR.Panel2Collapsed)
            { myTR(); }

            if (onClose)
            {
                if (isNarad)
                {
                    ___bASA__DataSet.Posesenie[0].Summa = d;
                    ___bASA__DataSet.Posesenie[0].Narad = true;

                }
                else
                {
                    ___bASA__DataSet.Posesenie[0].Summa = 0;
                    ___bASA__DataSet.Posesenie[0].Narad = false;

                }
                toolStripButtonNoNarad.Enabled = toolStripButtonNarad.Enabled = false;

            }
            posesenieBindingSource.EndEdit();
            posesenieTableAdapter.Update(___bASA__DataSet.Posesenie);

            if (posesenieN == 0)
            {
                posesenieN = ___bASA__DataSet.Posesenie[0].ID;

                foreach (___BASA__DataSet.TreatDSRow DSr in ___bASA__DataSet.TreatDS.Select("Posesenie<>" + posesenieN.ToString()))
                {
                    DSr.Posesenie = posesenieN;
                }
                foreach (___BASA__DataSet.TreatTreatRow TRr in ___bASA__DataSet.TreatTreat.Select("Posesenie<>" + posesenieN.ToString()))
                {
                    TRr.Posesenie = posesenieN;
                }
            }

            if (onClose)
            {

                if (isNarad)
                {
                    if (d != 0)
                    {
                        dolgTableAdapter.Insert(___bASA__DataSet.Posesenie[0].ID, d);
                    }
                }
                treatDSTableAdapter.Update(___bASA__DataSet.TreatDS);
                treatTreatTableAdapter.Update(___bASA__DataSet.TreatTreat);
            }
            else
            {
                ___BASA__DataSet.TreatDSDataTable chengDS = (___BASA__DataSet.TreatDSDataTable)___bASA__DataSet.TreatDS.GetChanges();
                if (chengDS != null)
                {
                    treatDSTableAdapter.Update(chengDS);
                    ___bASA__DataSet.TreatDS.Merge(chengDS);
                    ___bASA__DataSet.TreatDS.AcceptChanges();
                }

                ___BASA__DataSet.TreatTreatDataTable chengTR = (___BASA__DataSet.TreatTreatDataTable)___bASA__DataSet.TreatTreat.GetChanges();
                if (chengTR != null)
                {
                    treatTreatTableAdapter.Update(chengTR);
                    ___bASA__DataSet.TreatTreat.Merge(chengTR);
                    ___bASA__DataSet.TreatTreat.AcceptChanges();
                }

                numericUpDown1.Value = d;
                PosRow = ___bASA__DataSet.Posesenie[0];
                Tr_dataGridView.RowsAdded += Tr_dataGridView_RowsAdded;
                Tr_dataGridView.RowsRemoved += Tr_dataGridView_RowsRemoved;
                DS_DataGridView.RowsAdded += DS_DataGridView_RowsAdded;
                DS_DataGridView.RowsRemoved += DS_DataGridView_RowsRemoved;
                richTextBox_DS_MY.ContentsResized += richTextBox_DS_MY_ContentsResized;
                richTextBox_TR_MY.ContentsResized += richTextBox_TR_MY_ContentsResized_1;

                toolStripButton_Save.Enabled = false;

            }
        }

        private void toolStripButtonNarad_Click(object sender, EventArgs e)
        {
            Save(true, true);
            this.Close();
        }



        private void textBoxZaloby_TextChanged(object sender, EventArgs e)
        {
            toolStripButton_Save.Enabled = true;
        }

        private void treeView_Right_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            takeZal_Obekt();
        }

        private void Posesenie_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toolStripButtonNarad.Enabled)
            {
                Question Qu = new Question();
                Qu.Text = this.Text;
                Qu.buttonSave.Text = "Выписать наряд";
                Qu.buttonNotSave.Text = "Не сохранять";
                // Qu..buttonSave.Text = "Наряд";
                Qu.label_TextDn.Text = "Внимание! После закрытия формы изменить данные о лечении невозможно. Что будем делать?";
                Qu.label_TextUp.Text = "Вы уверены, что хотите завершить лечение?";
                DialogResult res = Qu.ShowDialog();
                if (res == DialogResult.Yes)
                {
                    Save(true, true);

                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    if (this.MdiParent.ActiveMdiChild != this)
                    {
                        ((MainForm)this.MdiParent).checkWin(this);
                    }
                }

            }
        }


        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            if (zub != null)
            {
                zub.FlatStyle = FlatStyle.Standard;
                zub.Margin = new Padding(1);//.Popup;}
            }
            labelForzubTR.Visible = labelForZubDS.Visible = false;
            btn = "0";
            zub = null;
            labelTr_Choos_Zub.Text = "не связанное с зубом";
            labelDS_Choose_Zub.Text = "не связанный с зубом";
            textBox_TtView.Text = textBox_DSview.Text = "";
            treatTableAdapter.FillByReal(___bASA__DataSet.Treat, true);
            diagnosisTableAdapter.FillByReal(___bASA__DataSet.Diagnosis, true);
            treatDSBindingSource2.Filter = treatTreatBindingSource2.Filter = "Zub=0";
            FirstTreeNode(___bASA__DataSet.Diagnosis, treeView_DS);
            FirstTreeNode(___bASA__DataSet.Treat, treeView_Tr);
            toolStripButtonTakeDS.Visible = true;
            toolStripButtonTakeTR.Visible = false;
            toolStripLabel1.Text = "Выбираем Диагноз";
            treeView_DS.Visible = true;
            panel20.Visible = true;
            panel18.Visible = false;
            treeView_Tr.Visible = false;
            panelDs_Tr.Visible = true;
            treeView_DS.BringToFront();
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            if (zub != null)
            {
                zub.FlatStyle = FlatStyle.Standard;
                zub.Margin = new Padding(1);
            }
            labelForzubTR.Visible = labelForZubDS.Visible = false;
            btn = "0";
            zub = null;
            labelTr_Choos_Zub.Text = "не связанное с зубом";
            labelDS_Choose_Zub.Text = "не связанный с зубом";
            textBox_TtView.Text = textBox_DSview.Text = "";
            treatTableAdapter.FillByReal(___bASA__DataSet.Treat, true);
            diagnosisTableAdapter.FillByReal(___bASA__DataSet.Diagnosis, true);
            treatDSBindingSource2.Filter = treatTreatBindingSource2.Filter = "Zub=0";
            FirstTreeNode(___bASA__DataSet.Diagnosis, treeView_DS);
            FirstTreeNode(___bASA__DataSet.Treat, treeView_Tr);

            toolStripButtonTakeDS.Visible = false;
            toolStripButtonTakeTR.Visible = true;
            toolStripLabel1.Text = "Выбираем Лечение";

            treeView_Tr.Visible = true;
            panel18.Visible = true;

            treeView_DS.Visible = false;
            panel20.Visible = false;
            panelDs_Tr.Visible = true;
            treeView_Tr.BringToFront();

        }

        private void toolStripSplitButton2_DropDownOpening(object sender, EventArgs e)
        {
            if (toolStripMenuItem_MYTR.Checked)
            { autoTRtoolStripMenuItem.Visible = cleanMYTRToolStripMenuItem.Visible = true; }
            else
            { autoTRtoolStripMenuItem.Visible = cleanMYTRToolStripMenuItem.Visible = false; }
        }

        private void cleanMYTRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_TR_MY.Text = "";
            richTextBox_TR_MY.Focus();
        }

        private void cleanMYDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_DS_MY.Text = "";
            richTextBox_DS_MY.Focus();
        }

        private void toolStripSplitButton1_DropDownOpening(object sender, EventArgs e)
        {
            if (myDSToolStripMenuItem.Checked)
            {
                autoDSToolStripMenuItem.Visible = cleanMYDSToolStripMenuItem.Visible = true;
            }
            else
            { autoDSToolStripMenuItem.Visible = cleanMYDSToolStripMenuItem.Visible = false; }

        }

        private void toolStripSplitButtonAn_ButtonClick(object sender, EventArgs e)
        {
            labelCaption_Right.Text = "Выбираем АНАМНЕЗ";
            anamnezTableAdapter.FillByReal(___bASA__DataSet.Anamnez, true);
            FirstTreeNode(___bASA__DataSet.Anamnez, treeView_Right);
            rightPanel_show();
            buttonTakeRight.Tag = richTextBoxAnamnez;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panelRight.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panelDs_Tr.Visible = false;
        }

        private void treatTreatBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (___bASA__DataSet.TreatTreat.Rows.Count != 0 && ___bASA__DataSet.TreatTreat.Compute("SUM(Summa)", "").GetType() != typeof(DBNull))
            {
                numericUpDown1.Value = (decimal)___bASA__DataSet.TreatTreat.Compute("SUM(Summa)", "");
            }
            else
            {
                numericUpDown1.Value = 0;
            }
        }

        private void autoDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myDS();
            richTextBox_DS_MY.Focus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            myTR();
            richTextBox_TR_MY.Focus();
        }

        private void toolStripButtonNoNarad_Click(object sender, EventArgs e)
        {
            Save(true, false);
            this.Close();
        }

        private void toolStripButton_Save_EnabledChanged(object sender, EventArgs e)
        {
            if (toolStripButton_Save.Enabled)
            {
                toolStripButtonNarad.Enabled = toolStripButtonNoNarad.Enabled = true;
            }
        }

        private void toolStripOb_Resize(object sender, EventArgs e)
        {
            toolStripZal.Width = toolStripTR.Width = toolStripAnamnez.Width = toolStripDS.Width = toolStripOb.Width;
        }
    }
}
