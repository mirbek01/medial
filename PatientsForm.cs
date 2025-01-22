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
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DSS
{

    public partial class PatientsForm : Form
    {
        public PatientsForm()
        {
            InitializeComponent();
        }

        int rN = -1, cN = -1;//счетчики текущей ячейки поиска
        bool searchFam = true;//поиск по фамилии?

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

        private void toolStripButtonA_Click(object sender, EventArgs e)
        {
            if (!((ToolStripButton)sender).Checked)
            {
                Cursor = Cursors.WaitCursor;
                string Litera = ((ToolStripButton)sender).Text;
                kartyBindingSource.Filter = "PF LIKE '" + Litera + "%'";
                foreach (ToolStripButton buttn in toolStripAlfavit.Items)
                {
                    buttn.CheckState = CheckState.Unchecked;
                }
                ((ToolStripButton)sender).CheckState = CheckState.Checked;
                Cursor = Cursors.Default;
            }
        }

        private void toolStripButtonA_Z_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonA_Z.Checked)
            {
                Cursor = Cursors.WaitCursor;
                kartyBindingSource.RemoveFilter();
                foreach (ToolStripButton buttn in toolStripAlfavit.Items)
                {
                    buttn.CheckState = CheckState.Unchecked;
                }
                ((ToolStripButton)sender).CheckState = CheckState.Checked;
                Cursor = Cursors.Default;
            }
        }

        private ContextMenuStrip columnSelect()
        {
            bool FIO_in_one_col = true;
            ContextMenuStrip ViborKolonok = new ContextMenuStrip();

            foreach (DataGridViewColumn selCol in dataGridViewPatients.Columns)
            {
                ToolStripMenuItem added = new ToolStripMenuItem();
                added.Text = selCol.HeaderText;

                if (selCol.HeaderText == "Ф.И.О." & selCol.Visible)
                {
                    added.CheckState = CheckState.Indeterminate;
                    added.ForeColor = Color.Gray;
                    ViborKolonok.Items.Add(added);
                    FIO_in_one_col = true;
                }

                else
                    if ((selCol.HeaderText == "Фамилия" | selCol.HeaderText == "Имя" | selCol.HeaderText == "Отчество") & selCol.Visible)
                    {
                        added.CheckState = CheckState.Indeterminate;
                        added.ForeColor = Color.Gray;
                        ViborKolonok.Items.Add(added);
                        FIO_in_one_col = false;
                    }

                    else
                        if (selCol.HeaderText != "Ф.И.О." & selCol.HeaderText != "Фамилия" &
                            selCol.HeaderText != "Имя" & selCol.HeaderText != "Отчество" & !selCol.Visible)
                        {
                            added.CheckState = CheckState.Unchecked;
                            ViborKolonok.Items.Add(added);
                            added.Click += added_Click;
                            added.Tag = selCol;
                        }
                        else if (selCol.Visible)
                        {
                            added.CheckState = CheckState.Checked;
                            ViborKolonok.Items.Add(added);
                            added.Click += added_Click;
                            added.Tag = selCol;
                        }

            }

            ViborKolonok.Items.Add("-");

            ToolStripMenuItem FioIn_1 = new ToolStripMenuItem("Ф.И.О. в одну колонку");
            FioIn_1.Click += FioIn_1_Click;
            if (FIO_in_one_col)
            { FioIn_1.CheckState = CheckState.Checked; }
            ViborKolonok.Items.Add(FioIn_1);

            return ViborKolonok;
        }

        void FioIn_1_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).CheckState == CheckState.Checked)
            {
                fio_to_one(true);
            }
            else
            {
                fio_to_one(false);
            }
        }

        void added_Click(object sender, EventArgs e)//нажата кнопка меню "выбор конкретной колонки"
        {
            if (((DataGridViewColumn)((ToolStripMenuItem)sender).Tag).Visible)
            { ((DataGridViewColumn)((ToolStripMenuItem)sender).Tag).Visible = false; }
            else
            { ((DataGridViewColumn)((ToolStripMenuItem)sender).Tag).Visible = true; }

        }

        private void toolStripSplitButtonVid_DropDownOpening(object sender, EventArgs e)
        {

            columnsToolStripMenuItem.DropDown = columnSelect();
            sortToolStripMenuItem.DropDown = columnSort();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridViewPatients.SelectionMode != DataGridViewSelectionMode.FullRowSelect)
                { dataGridViewPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect; }

                dataGridViewPatients[e.ColumnIndex, e.RowIndex].Selected = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1)
                {
                    dataGridViewPatients.Columns[e.ColumnIndex].HeaderCell.ContextMenuStrip = columnSelect();
                }
                else
                {
                    dataGridViewPatients.Rows[e.RowIndex].Cells[e.ColumnIndex].ContextMenuStrip = contextMenuStripGrid;
                }
            }
        }

        private void fio_to_one(bool fio_in_1)
        {
            Cursor = Cursors.WaitCursor;
            if (fio_in_1)
            {
                dataGridViewPatients.Columns["pFIODataGridViewTextBoxColumn"].Visible = false;

                dataGridViewPatients.Columns["pFDataGridViewTextBoxColumn"].Visible = true;
                dataGridViewPatients.Columns["pIDataGridViewTextBoxColumn"].Visible = true;
                dataGridViewPatients.Columns["pODataGridViewTextBoxColumn"].Visible = true;
            }
            else
            {
                dataGridViewPatients.Columns["pFIODataGridViewTextBoxColumn"].Visible = true;

                dataGridViewPatients.Columns["pFDataGridViewTextBoxColumn"].Visible = false;
                dataGridViewPatients.Columns["pIDataGridViewTextBoxColumn"].Visible = false;
                dataGridViewPatients.Columns["pODataGridViewTextBoxColumn"].Visible = false;
            }
            Cursor = Cursors.Default;
        }

        private ContextMenuStrip columnSort()//создает и возвращает меню сортироовки по колонкам
        {
            ContextMenuStrip ViborKolonok = new ContextMenuStrip();

            foreach (DataGridViewColumn selCol in dataGridViewPatients.Columns)
            {
                if (selCol.Visible)
                {
                    ToolStripMenuItem sorted = new ToolStripMenuItem();

                    sorted.Text = selCol.HeaderText;
                    sorted.Click += new EventHandler(sorted_Click);
                    sorted.Tag = selCol.DataPropertyName;
                    ViborKolonok.Items.Add(sorted);
                }
            }
            return ViborKolonok;
        }

        void sorted_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            kartyBindingSource.Sort = (string)(((ToolStripMenuItem)sender).Tag);
            Cursor = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewPatients[e.ColumnIndex, e.RowIndex].Selected = true;
                openKarta((DataRowView)kartyBindingSource.Current);
            }
        }

        void searchNext(bool hu)
        {
            if (toolStripTextBoxSearch.Text != "")
            {
                bool fin = false;

                foreach (DataGridViewRow row in dataGridViewPatients.Rows)
                {
                    if (!searchFam)
                    { fin = serchInAllColumns(row.Index); }
                    else
                    { fin = serchInFio(row.Index); }

                    if (fin)
                    { break; }
                }
                if (!fin)
                {
                    toolStripTextBoxSearch.ForeColor = Color.Red;
                    foreach (ToolStripMenuItem mi in toolStripSplitButtonFindNext.DropDownItems)
                    {
                        if (mi.CheckState == CheckState.Checked)
                        {
                            toolStripSplitButtonFindNext.Text = "Поиск " + mi.Text;
                            toolStripSplitButtonFindNext.ForeColor = Color.Black;
                        }
                    }

                    if (!hu)//если метод вызван с ху-ложь(ввод текста в строку поиска),поиск молча закончен
                    {
                        rN = -1; cN = -1;
                        if (hu & MessageBox.Show("Искать с начала?", "Ничего не найдено", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                             DialogResult.Yes)
                        {
                            searchNext(false);
                        }
                    }
                }
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)//поиск по нажатию ентер
        {
            if (e.KeyChar == 13)
            {
                searchNext(false);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)//поиск по изменению текста поиска
        {

            {
                cN = -1; rN = -1;
                searchNext(true);
            }
        }

        private void toolStripSplitButtonFindNext_ButtonClick(object sender, EventArgs e)//кнопка "искать далее"
        {
            searchNext(false);
        }

        private void вездеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButtonFindNext.Text = "Поиск " + ((ToolStripMenuItem)sender).Text;
            foreach (ToolStripMenuItem mi in toolStripSplitButtonFindNext.DropDownItems)
            {

                mi.CheckState = CheckState.Unchecked;
            }
            ((ToolStripMenuItem)sender).CheckState = CheckState.Checked;
        }

        private bool serchInAllColumns(int rowI)
        {
            bool fin1 = false;

            foreach (DataGridViewColumn col in dataGridViewPatients.Columns)
            {

                if (col.Visible)
                {
                    if ((dataGridViewPatients.Rows[rowI].Cells[col.Index].Value.ToString()).ToLower().Contains(toolStripTextBoxSearch.Text.ToLower()))
                    {
                        dataGridViewPatients.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        if ((rowI == rN && col.Index > cN) || rowI > rN)
                        {
                            toolStripTextBoxSearch.ForeColor = Color.Black;
                            dataGridViewPatients.Rows[rowI].Cells[col.Index].Selected = true;
                            rN = rowI;
                            cN = col.Index;
                            fin1 = true;//что-то нашли,
                            toolStripSplitButtonFindNext.Text = "Искать далее";
                            toolStripSplitButtonFindNext.ForeColor = Color.Green;

                            break;//пока стоп поиск
                        }
                    }
                }

            }
            return fin1;
        }

        private void searchByFamToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).CheckState == CheckState.Checked)
            { searchFam = true; }
            else
            { searchFam = false; }
        }

        private bool serchInFio(int rowI)
        {

            bool fin1 = false;

            if ((dataGridViewPatients.Rows[rowI].Cells["pFDataGridViewTextBoxColumn"].Value.ToString()).ToLower().StartsWith(toolStripTextBoxSearch.Text.ToLower()))
            {
                dataGridViewPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (rowI > rN)
                {
                    toolStripTextBoxSearch.ForeColor = Color.Black;
                    dataGridViewPatients.Rows[rowI].Selected = true;
                    dataGridViewPatients.FirstDisplayedScrollingRowIndex = rowI;
                    rN = rowI;
                    fin1 = true;//что-то нашли,
                    toolStripSplitButtonFindNext.Text = "Искать далее";
                    toolStripSplitButtonFindNext.ForeColor = Color.Green;
                }
            }
            return fin1;
        }


        private void openKartaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openKarta((DataRowView)kartyBindingSource.Current);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatients.CurrentCell.FormattedValue.ToString() != "")
            {
                Clipboard.SetText(dataGridViewPatients.CurrentCell.FormattedValue.ToString());
            }
            else
            {
                Clipboard.SetText(" ");
            }
        }

        private void CopyRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatients.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    Clipboard.SetDataObject(
                        dataGridViewPatients.GetClipboardContent());
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    CopyRowToolStripMenuItem.Tag =
                        "Нет выделенных элементов. Пожалуйста, попробуйте еще.";
                }
            }
        }

        private void toolStripButtonUpd_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.kartyTableAdapter.Fill(___BASA__DataSet.Karty, true);
            Cursor = Cursors.Default;

        }

        private void toolStripSplitButtonBD_DropDownOpening(object sender, EventArgs e)
        {
            bool isBD_15Days = false;
            toolStripSplitButtonBD.DropDownItems.Clear();
            foreach (___BASA__DataSet.KartyRow drv in ___BASA__DataSet.Karty.Rows)
            {
                if (!drv.IsPBDNull())
                {
                    if (drv.PBD.DayOfYear - DateTime.Today.DayOfYear >= 0 && drv.PBD.DayOfYear - DateTime.Today.DayOfYear <= 15)
                    {
                        ToolStripMenuItem bmu = new ToolStripMenuItem();
                        bmu.Text = drv.PFIO;

                        bmu.Tag = drv;
                        bmu.Click += new EventHandler(bmu_Click);
                        toolStripSplitButtonBD.DropDownItems.Add(bmu);
                        isBD_15Days = true;
                    }
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
            kartyBindingSource.Position = kartyBindingSource.Find("PID", (int)((DataRow)((ToolStripMenuItem)sender).Tag)["PID"]);
        }

        private void openKarta(DataRowView curent)
        {
            if (curent != null)
            {
                KartaForm pat = new KartaForm();
                pat.Tag = (int)((DataRowView)curent)["PID"];
                pat.Text = "Карточка: " + ((DataRowView)curent)["PFIO"].ToString();
                ((MainForm)this.MdiParent).checkWin(pat);
            }
        }


        private void toolStripButtonNewKarta_Click(object sender, EventArgs e)
        {
            KartaForm pat = new KartaForm();
            pat.Tag = 0;
            ((MainForm)this.MdiParent).checkWin(pat);
        }


        private void toolStripButtonNewTreat_Click(object sender, EventArgs e)
        {
            openNewTreat((DataRowView)kartyBindingSource.Current);

        }

        private void toolStripButtonOpenKart_Click(object sender, EventArgs e)
        {
            openKarta((DataRowView)kartyBindingSource.Current);
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            if (kartyBindingSource.Current != null)
            {
                if (MessageBox.Show("Удалить карточку в карзину?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int PID = (int)((DataRowView)kartyBindingSource.Current)["PID"];
                    kartaTableAdapter.UpdateQueryRealByPID(false, PID);
                    kartyTableAdapter.Fill(___BASA__DataSet.Karty, true);
                }
            }
        }

        void openNewTreat(DataRowView curent)
        {
            if (curent != null)
            {
                Posesenie poses = new Posesenie();
                poses.Tag = (int)((DataRowView)curent)["PID"];
                poses.Text = "Лечение: " + ((DataRowView)curent)["PFIO"].ToString();
                ((MainForm)this.MdiParent).checkWin(poses);
            }
        }

        private void treatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openNewTreat((DataRowView)kartyBindingSource.Current);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripMenuItemColumn.DropDown = columnSelect();
            toolStripMenuItemSort.DropDown = columnSort();
        }

        private void toolStripButtonMoney_Click(object sender, EventArgs e)
        {

            if ((DataRowView)kartyBindingSource.Current != null)
            {
                DataRowView curent = (DataRowView)kartyBindingSource.Current;
                MoneyMoov nov = (MoneyMoov)((MainForm)this.MdiParent).checkWin(new MoneyMoov());
                nov.PatFilter((int)((DataRowView)curent)["PID"], ((DataRowView)curent)["PFIO"].ToString());
            }
        }

    }
}
