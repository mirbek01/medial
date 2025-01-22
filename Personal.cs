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

namespace DSS
{
    public partial class Personal : Form
    {
        public Personal()
        {
            InitializeComponent();
        }


        string filterAZ = "";
        string filterDoc = "";

        private void toolStripButtonAlfavitShow_Click(object sender, EventArgs e)
        {
            if (toolStripAlfavit.Visible)
            {
                toolStripAlfavit.Hide();
                toolStripButtonAlfavitShow.CheckState = CheckState.Unchecked;
                toolStripButtonAlfavitShow.Text = "Показать Алфавит";
            }
            else
            {
                toolStripAlfavit.Show();
                toolStripButtonAlfavitShow.CheckState = CheckState.Checked;
                toolStripButtonAlfavitShow.Text = "Скрыть Алфавит";
            }
        }

        private void Personal_Load(object sender, EventArgs e)
        {
            dataGridViewPers.Columns["isDoctor"].DisplayIndex = 3;
        }

        private void toolStripButtonA_Click(object sender, EventArgs e)
        {
            string Litera = ((ToolStripButton)sender).Text;
            filterAZ = "DF LIKE '" + Litera + "%'";
            filterPers();
            foreach (ToolStripButton buttn in toolStripAlfavit.Items)
            { buttn.CheckState = CheckState.Unchecked; }
            ((ToolStripButton)sender).CheckState = CheckState.Checked;
        }

        private void toolStripButtonA_Z_Click(object sender, EventArgs e)
        {
            filterAZ = "";
            filterPers();
            foreach (ToolStripButton buttn in toolStripAlfavit.Items)
            { buttn.CheckState = CheckState.Unchecked; }
            ((ToolStripButton)sender).CheckState = CheckState.Checked;
        }

        private void toolStripButtonOpenKart_Click(object sender, EventArgs e)
        {
            if (personalBindingSource.Current != null)
            {
                openDelo((DataRowView)personalBindingSource.Current);
            }
        }

        void filterPers()
        {
            if (filterAZ != "" && filterDoc != "")
            {
                personalBindingSource.Filter = filterAZ + " AND " + filterDoc;
            }
            else if (filterAZ != "" && filterDoc == "")
            {
                personalBindingSource.Filter = filterAZ;
            }
            else if (filterAZ == "" && filterDoc != "")
            {
                personalBindingSource.Filter = filterDoc;
            }
            else if (filterAZ == "" && filterDoc == "")
            {
                personalBindingSource.RemoveFilter();
            }
        }


        void openDelo(DataRowView curent)
        {
            if (curent != null)
            {
                DeloPers delo = new DeloPers();
                delo.Tag = (int)((DataRowView)curent)["DID"];
                delo.Text = "Персонал: " + curent["DFIO"].ToString();
                ((MainForm)this.MdiParent).checkWin(delo);
            }
        }

        private void toolStripButtonUpd_Click(object sender, EventArgs e)
        {
            this.personalVievTableAdapter.Fill(this.___BASA__DataSet.PersonalViev, true);
        }

        private void Personal_Activated(object sender, EventArgs e)
        {
            this.personalVievTableAdapter.Fill(this.___BASA__DataSet.PersonalViev, true);
        }

        private void toolStripSplitButtonBD_DropDownOpening(object sender, EventArgs e)
        {
            bool isBD_15Days = false;
            toolStripSplitButtonBD.DropDownItems.Clear();
            foreach (___BASA__DataSet.PersonalVievRow drv in ___BASA__DataSet.PersonalViev)
            {
                if (drv.DBD.DayOfYear - DateTime.Today.DayOfYear >= 0 && drv.DBD.DayOfYear - DateTime.Today.DayOfYear <= 15)
                {
                    ToolStripMenuItem bmu = new ToolStripMenuItem();
                    bmu.Text = drv.DFIO;
                    bmu.Tag = drv;
                    bmu.Click += new EventHandler(bmu_Click);
                    toolStripSplitButtonBD.DropDownItems.Add(bmu);
                    isBD_15Days = true;
                }
            }
            if (!isBD_15Days)
            {
                ToolStripMenuItem bmu = new ToolStripMenuItem();
                bmu.Text = "Ближайшие 15 дней Имениников нет";
                toolStripSplitButtonBD.DropDownItems.Add(bmu);
            }
        }

        void bmu_Click(object sender, EventArgs e)
        {
            personalBindingSource.Position = personalBindingSource.Find("DID", (int)((DataRow)((ToolStripMenuItem)sender).Tag)["DID"]);
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            if (personalBindingSource.Current != null)
            {
                DeletePers((DataRowView)personalBindingSource.Current);
            }
        }

        private void DeletePers(DataRowView row)
        {
            if (MessageBox.Show("Удалить личное дело в карзину?", row["DFIO"].ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int PID = (int)row["DID"];
                kadryTableAdapter.UpdateQuery(false, PID);
                personalVievTableAdapter.Fill(___BASA__DataSet.PersonalViev, true);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonOnlyDoc.Checked)
            {
                toolStripButtonOnlyDoc.Checked = true;
                toolStripButtonOnlyNODoc.Checked = false;
                filterDoc = "isDoctor=true";
                filterPers();
            }
            else
            {
                toolStripButtonOnlyDoc.Checked = false;
                filterDoc = "";
                filterPers();
            }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonOnlyNODoc.Checked)
            {
                toolStripButtonOnlyNODoc.Checked = true;
                toolStripButtonOnlyDoc.Checked = false;

                filterDoc = "isDoctor=false";
                filterPers();
            }
            else
            {
                toolStripButtonOnlyNODoc.Checked = false;
                filterDoc = "";
                filterPers();
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (!dataGridViewPers.Rows[e.RowIndex].Selected)
                {
                    dataGridViewPers.ClearSelection();
                    dataGridViewPers.Rows[e.RowIndex].Selected = true;
                    dataGridViewPers[e.ColumnIndex, e.RowIndex].ContextMenuStrip = contextMenuStripGrid;
                }
            }
        }

        private void deletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPers.SelectedRows.Count == 1)
            {
                DeletePers((DataRowView)dataGridViewPers.SelectedRows[0].DataBoundItem);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPers.SelectedRows.Count == 1)
            {
                openDelo((DataRowView)dataGridViewPers.SelectedRows[0].DataBoundItem);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                openDelo((DataRowView)dataGridViewPers.Rows[e.RowIndex].DataBoundItem);
            }
        }

        private void toolStripSplitButtonBD_ButtonClick(object sender, EventArgs e)
        {
            toolStripSplitButtonBD.ShowDropDown();
        }

        private void toolStripButton33_Click(object sender, EventArgs e)
        {

            DeloPers delo = new DeloPers();
            delo.Tag = 0;
            ((MainForm)this.MdiParent).checkWin(delo);
        }

        private void toolStripButtonOnlyDoc_CheckStateChanged(object sender, EventArgs e)
        {
            docOnlyToolStripMenuItem.CheckState = toolStripButtonOnlyDoc.CheckState;
        }

        private void toolStripButtonOnlyNODoc_CheckStateChanged(object sender, EventArgs e)
        {
            notDocOnlyToolStripMenuItem.CheckState = toolStripButtonOnlyNODoc.CheckState;
        }
    }
}
