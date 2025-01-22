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
    public partial class RaspChenge : Form
    {
        public RaspChenge()
        {
            InitializeComponent();
        }

        int wen;
        public int doctor;

        private void RaspChenge_Load(object sender, EventArgs e)
        {
            checkBox1.Tag = dataGridView1;
            checkBox2.Tag = dataGridView2;
            checkBox3.Tag = dataGridView3;
            checkBox4.Tag = dataGridView4;
            checkBox5.Tag = dataGridView5;
            checkBox6.Tag = dataGridView6;
            checkBox7.Tag = dataGridView7;

            whenDatesTableAdapter.Adapter.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(WhenAdapter_RowUpdated);
            raspisanieTableAdapter.Adapter.RowUpdated += new OleDbRowUpdatedEventHandler(RasAdapter_RowUpdated);

            whenDatesDataGridView1.Columns.Clear();
            this.whenDatesTableAdapter.Fill(this.___BASA__DataSet.whenDates);
            raspisanieTableAdapter.Fill(___BASA__DataSet.raspisanie);
            personalVievTableAdapter1.Fill(___BASA__DataSet.PersonalViev, true);
            CalendarColumn col1 = new CalendarColumn();
            whenDatesDataGridView1.Columns.Insert(0, col1);
            col1.Name = col1.DataPropertyName = "begin";
            col1.HeaderText = "Начало периода";

            CalendarColumn col2 = new CalendarColumn();
            whenDatesDataGridView1.Columns.Insert(1, col2);
            col2.Name = col2.DataPropertyName = "end";
            col2.HeaderText = "Конец периода";
            col2.SortMode = col1.SortMode = DataGridViewColumnSortMode.Programmatic;
            whenDatesDataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(whenDatesDataGridView1_CellValidating);
            comboSelChenge();
        }

        void RasAdapter_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            progressBar1.Value += 1;
            progressBar1.Refresh();
        }

        void WhenAdapter_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
        {
            progressBar1.PerformStep();
            progressBar1.Refresh();

            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmdNewID = new OleDbCommand("SELECT @@IDENTITY", whenDatesTableAdapter.Connection);
                cmdNewID.Transaction = whenDatesTableAdapter.Transaction;
                int newID = (int)cmdNewID.ExecuteScalar();
                foreach (___BASA__DataSet.raspisanieRow rR in ___BASA__DataSet.raspisanie.Select("whenID=" + ((___BASA__DataSet.whenDatesRow)e.Row).ID))
                {
                    rR.whenID = newID;
                }
                ((___BASA__DataSet.whenDatesRow)e.Row).ID = (int)cmdNewID.ExecuteScalar();

            }
        }

        void whenDatesDataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].IsInEditMode)
            {
                DataRow checkedRow = ((DataRowView)whenDatesDataGridView1.Rows[e.RowIndex].DataBoundItem).Row;

                if (whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "begin")
                {
                    DateTime editDate = ((CalendarEditingControl)whenDatesDataGridView1.EditingControl).Value.Date;
                    if (editDate > ((DateTime)checkedRow["end"]).Date)
                    {
                        MessageBox.Show("Период должен начаться прежде, чем закончится.", this.Text);
                        e.Cancel = true;
                        ((CalendarEditingControl)whenDatesDataGridView1.EditingControl).Value = (DateTime)whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Value;
                        whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Selected = true;
                    }
                    else
                    {
                        string dataS = "";
                        bool b = false;
                        foreach (DataRow r in ___BASA__DataSet.whenDates.Select("(begin<='" + editDate.ToString() + "' AND end >='" + editDate.ToString() + "' AND end<='" + ((DateTime)checkedRow["end"]).Date.ToString() + "' AND DID=" + comboBox1.SelectedValue.ToString() + ") "
                          + " OR (begin>='" + editDate.ToString() + "' AND end >='" + editDate.ToString() + "' AND end<='" + ((DateTime)checkedRow["end"]).Date.ToString() + "' AND DID=" + comboBox1.SelectedValue.ToString() + ")"))
                        {
                            if (r != checkedRow)
                            {
                                dataS = ((DateTime)r["begin"]).ToShortDateString() + " - " + ((DateTime)r["end"]).ToShortDateString();
                                b = true;
                                break;
                            }
                        }
                        if (b)
                        {
                            MessageBox.Show("Недопустимое значение. Перекрывается существующий период: " + dataS + ".", this.Text);
                            e.Cancel = true;
                            ((CalendarEditingControl)whenDatesDataGridView1.EditingControl).Value = (DateTime)whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Value;
                            whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Selected = true;  // ((CalendarEditingControl)whenDatesDataGridView1.EditingControl).Value = (DateTime)whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Value;
                        }
                    }
                }

                else if (whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "end")
                {
                    DateTime editDate = ((CalendarEditingControl)whenDatesDataGridView1.EditingControl).Value.Date;
                    if (editDate < ((DateTime)checkedRow["begin"]).Date)
                    {
                        MessageBox.Show("Период должен закончиться позже, чем начнется.", this.Text);
                        e.Cancel = true;
                        ((CalendarEditingControl)whenDatesDataGridView1.EditingControl).Value = ((DateTime)whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Value).Date;
                        whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Selected = true;  // whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Selected = true;
                    }
                    else
                    {
                        string dataS = "";
                        bool b = false;
                        foreach (DataRow r in ___BASA__DataSet.whenDates.Select("(end>='" + editDate.ToString() + "' AND begin <='" + editDate.ToString() + "' AND begin>='" + ((DateTime)checkedRow["begin"]).Date.ToString() + "' AND DID=" + comboBox1.SelectedValue.ToString() + ") "
                          + " OR (end<='" + editDate.ToString() + "' AND begin <='" + editDate.ToString() + "' AND begin>='" + ((DateTime)checkedRow["begin"]).Date.ToString() + "' AND DID=" + comboBox1.SelectedValue.ToString() + ") "))
                        {
                            if (r != checkedRow)
                            {
                                dataS = ((DateTime)r["begin"]).ToShortDateString() + " - " + ((DateTime)r["end"]).ToShortDateString();
                                b = true;
                                break;
                            }
                        }
                        if (b)
                        {
                            MessageBox.Show("Недопустимое значение. Перекрывается существующий период: " + dataS + ".", this.Text);
                            e.Cancel = true;
                            ((CalendarEditingControl)whenDatesDataGridView1.EditingControl).Value = (DateTime)whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Value;
                            whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Selected = true;  // ((CalendarEditingControl)whenDatesDataGridView1.EditingControl).Value = (DateTime)whenDatesDataGridView1[e.ColumnIndex, e.RowIndex].Value;

                        }
                    }
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grd = (DataGridView)sender;
            grd.Focus();

            if (e.RowIndex >= 0 && !(grd.Rows[e.RowIndex].Selected))
            {
                grd.ClearSelection();
                grd[e.ColumnIndex, e.RowIndex].Selected = true;
            }

            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                grd[e.ColumnIndex, e.RowIndex].ContextMenuStrip = contextMenuStripCELL;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime t1 = dateTimePicker1.Value.Date;
            DateTime t2 = dateTimePicker2.Value.Date;

            if (t1 > t2)
            {
                MessageBox.Show("Период должен начаться прежде, чем закончится.", this.Text);
            }

            else if (___BASA__DataSet.whenDates.Select("begin<='" + t1.ToString()
                       + "' AND end>='" + t2.ToString() +
                        "' AND DID=" + comboBox1.SelectedValue.ToString()).Length > 0)
            {
                MessageBox.Show("Существующий период перекрывает границы нового.", this.Text);
            }

            else if (___BASA__DataSet.whenDates.Select("begin<='" + t1.ToString()
                       + "' AND end>='" + t1.ToString() +
                        "' AND DID=" + comboBox1.SelectedValue.ToString()).Length > 0)
            {
                MessageBox.Show("Начало нового периода входит в границы существующего.", this.Text);
            }

            else if (___BASA__DataSet.whenDates.Select("  begin>='" + t1.ToString()
                       + "' AND end<='" + t2.ToString() +
                        "' AND DID=" + comboBox1.SelectedValue.ToString()).Length > 0)
            {
                MessageBox.Show("Новый период перекрывает границы существующего.", this.Text);
            }
            else if (___BASA__DataSet.whenDates.Select("begin<='" + t2.ToString()
                       + "' AND end>='" + t2.ToString() +
                        "' AND DID=" + comboBox1.SelectedValue.ToString()).Length > 0)
            {
                MessageBox.Show("Конец нового периода входит в границы существующего.", this.Text);
            }
            else
            {
                ___BASA__DataSet.whenDatesRow ppp = ___BASA__DataSet.whenDates.NewwhenDatesRow();
                ppp.begin = t1;
                ppp.end = t2;
                ppp.DID = (int)comboBox1.SelectedValue;
                ___BASA__DataSet.whenDates.AddwhenDatesRow(ppp);

                for (int i = 0; i <= 6; i++)
                {
                    foreach (___BASA__DataSet.raspisanieRow dr in ___BASA__DataSet.raspisanie.Select("DID=" + comboBox1.SelectedValue.ToString() +
                                 " AND dow=" + i.ToString() + " AND whenID=0"))
                    {
                        ___BASA__DataSet.raspisanieRow added = ___BASA__DataSet.raspisanie.NewraspisanieRow();
                        added.whenID = ppp.ID;
                        added.time = dr.time;
                        added.dow = i;
                        added.DID = dr.DID;
                        added.period = dr.period;
                        ___BASA__DataSet.raspisanieRow newdr = ___BASA__DataSet.raspisanie.NewraspisanieRow();
                        ___BASA__DataSet.raspisanie.AddraspisanieRow(added);
                    }
                }
                checkBoxEdit.Checked = false;
            }
        }


        public DateTime begDay;
        public DateTime endDay;
        public int perDay;
        private void dayParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dayParam dp = new dayParam();
            dp.Tag = this;
            if (dp.ShowDialog() == DialogResult.Yes)
            {
                DataGridView gr12 = (DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
                foreach (DataRow ddrr in ___BASA__DataSet.raspisanie.Select("dow=" + ((string)gr12.Tag) +
                    " AND whenID= " + wen.ToString() + " AND DID=" + comboBox1.SelectedValue.ToString()))
                {
                    ddrr.Delete();
                }

                int N_ofDayItem = (int)(endDay.TimeOfDay.TotalMinutes - begDay.TimeOfDay.TotalMinutes) / perDay;

                DateTime ts = begDay;
                for (int i = 1; i <= N_ofDayItem; i++)
                {

                    ___BASA__DataSet.raspisanieRow r = ___BASA__DataSet.raspisanie.NewraspisanieRow();
                    r.time = ts;
                    r.period = perDay;
                    r.dow = Convert.ToInt32((string)gr12.Tag);
                    r.DID = (int)comboBox1.SelectedValue;
                    r.zap = "";
                    r.whenID = wen;
                    ___BASA__DataSet.raspisanie.AddraspisanieRow(r);

                    ts = ts.AddMinutes(perDay);
                }
            }
        }

        private void whenDatesDataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            whenDatesDataGridView1.Rows[e.RowIndex].Selected = true;
            if (whenDatesBindingSource.Current != null & comboBox1.SelectedValue != null)
            {
                wen = (int)((DataRowView)whenDatesDataGridView1.Rows[e.RowIndex].DataBoundItem)["ID"];
                string did = comboBox1.SelectedValue.ToString();
                string wenID = wen.ToString();

                raspisanieBindingSource1.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=1";
                raspisanieBindingSource2.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=2";
                raspisanieBindingSource3.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=3";
                raspisanieBindingSource4.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=4";
                raspisanieBindingSource5.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=5";
                raspisanieBindingSource6.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=6";
                raspisanieBindingSource7.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=0";
                checkBoxDefault.Checked = false;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView3_Enter(object sender, EventArgs e)
        {
            ((DataGridView)sender).DefaultCellStyle.SelectionBackColor = Color.Gainsboro;//.LightGray;
            ((DataGridView)sender).DefaultCellStyle.SelectionForeColor = Color.MidnightBlue;//.DarkBlue;
        }

        private void dataGridView3_Leave(object sender, EventArgs e)
        {
            ((DataGridView)sender).DefaultCellStyle.SelectionBackColor = Color.White;
            ((DataGridView)sender).DefaultCellStyle.SelectionForeColor = Color.Black;
        }


        int DID = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            if (whenDatesDataGridView1.SelectedRows.Count == 1)
            {
                int when = (int)((DataRowView)whenDatesDataGridView1.SelectedRows[0].DataBoundItem)["ID"];

                for (int i = 0; i <= 6; i++)
                {
                    foreach (___BASA__DataSet.raspisanieRow dr in ___BASA__DataSet.raspisanie.Select("DID=" + DID.ToString() +
                                 " AND dow=" + i.ToString() + " AND whenID=" + when.ToString()))
                    {
                        dr.Delete();
                    }
                }
                ((DataRowView)whenDatesDataGridView1.CurrentRow.DataBoundItem).Row.Delete();
                checkBoxEdit.Checked = false;

                if (___BASA__DataSet.whenDates.Select("DID=" + DID.ToString()).Length == 0)
                {
                    raspisanieBindingSource1.Filter = "DID=" + DID.ToString() + " AND whenID=0" + " AND dow=1";
                    raspisanieBindingSource2.Filter = "DID=" + DID.ToString() + " AND whenID=0" + " AND dow=2";
                    raspisanieBindingSource3.Filter = "DID=" + DID.ToString() + " AND whenID=0" + " AND dow=3";
                    raspisanieBindingSource4.Filter = "DID=" + DID.ToString() + " AND whenID=0" + " AND dow=4";
                    raspisanieBindingSource5.Filter = "DID=" + DID.ToString() + " AND whenID=0" + " AND dow=5";
                    raspisanieBindingSource6.Filter = "DID=" + DID.ToString() + " AND whenID=0" + " AND dow=6";
                    raspisanieBindingSource7.Filter = "DID=" + DID.ToString() + " AND whenID=0" + " AND dow=0";
                    checkBoxDefault.Checked = true;
                    checkBoxDefault.AutoCheck = false;

                }
            }
            else
            {
                MessageBox.Show("Выберите период для удаления.", this.Text);
            }
        }

        private void checkBoxEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEdit.Checked)
            {
                checkBoxEdit.BackColor = Color.LightBlue;

                panel1.Enabled = true;
                dateTimePicker1.Focus();
            }
            else
            {
                checkBoxEdit.BackColor = SystemColors.ButtonHighlight;
                panel1.Enabled = false;
            }
        }

        private void checkBoxDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxDefault.Checked)
            {
                checkBoxDefault.BackColor = SystemColors.ButtonHighlight;
            }
            else
            {
                checkBoxDefault.BackColor = Color.LightBlue;// SystemColors.InactiveCaptionText;
                whenDatesDataGridView1.ClearSelection();
                wen = 0;
                if (comboBox1.SelectedValue != null)
                {
                    string did = comboBox1.SelectedValue.ToString();
                    raspisanieBindingSource1.Filter = "DID=" + did + " AND whenID=0" + " AND dow=1";
                    raspisanieBindingSource2.Filter = "DID=" + did + " AND whenID=0" + " AND dow=2";
                    raspisanieBindingSource3.Filter = "DID=" + did + " AND whenID=0" + " AND dow=3";
                    raspisanieBindingSource4.Filter = "DID=" + did + " AND whenID=0" + " AND dow=4";
                    raspisanieBindingSource5.Filter = "DID=" + did + " AND whenID=0" + " AND dow=5";
                    raspisanieBindingSource6.Filter = "DID=" + did + " AND whenID=0" + " AND dow=6";
                    raspisanieBindingSource7.Filter = "DID=" + did + " AND whenID=0" + " AND dow=0";
                }
                checkBoxDefault.AutoCheck = false;
            }
        }

        private void dayChekParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dayParam dp = new dayParam();
            dp.Tag = this;
            if (dp.ShowDialog() == DialogResult.Yes)
            {
                foreach (CheckBox cb in new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7 })
                {
                    if (cb.Checked)
                    {
                        DataGridView gr12 = (DataGridView)cb.Tag;
                        foreach (DataRow ddrr in ___BASA__DataSet.raspisanie.Select("dow=" + ((string)gr12.Tag) +
                            " AND whenID= " + wen.ToString() + " AND DID=" + comboBox1.SelectedValue.ToString()))
                        {
                            ddrr.Delete();
                        }

                        int N_ofDayItem = (int)(endDay.TimeOfDay.TotalMinutes - begDay.TimeOfDay.TotalMinutes) / perDay;

                        DateTime ts = begDay;
                        for (int i = 1; i <= N_ofDayItem; i++)
                        {

                            ___BASA__DataSet.raspisanieRow r = ___BASA__DataSet.raspisanie.NewraspisanieRow();
                            r.time = ts;
                            r.period = perDay;
                            r.dow = Convert.ToInt32((string)gr12.Tag);
                            r.DID = (int)comboBox1.SelectedValue;
                            r.zap = "";
                            r.whenID = wen;
                            ___BASA__DataSet.raspisanie.AddraspisanieRow(r);

                            ts = ts.AddMinutes(perDay);
                        }
                    }
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            this.Validate();

            raspisanieBindingSource1.EndEdit(); raspisanieBindingSource2.EndEdit(); raspisanieBindingSource3.EndEdit();
            raspisanieBindingSource4.EndEdit(); raspisanieBindingSource5.EndEdit(); raspisanieBindingSource6.EndEdit();
            raspisanieBindingSource7.EndEdit();
            whenDatesBindingSource.EndEdit();
            tableLayoutPanel1.Enabled = false;
            int zaq2 = 0;
            progressBar1.Visible = true;
            progressBar1.Update();
            labelWait.Text = "Ждите, сохранение...";
            labelWait.Update();
            DataTable WDch = ___BASA__DataSet.whenDates.GetChanges();
            DataTable Rch = ___BASA__DataSet.raspisanie.GetChanges();

            if (WDch != null)
            {
                zaq2 += WDch.Rows.Count;
            }

            if (Rch != null)
            {
                zaq2 += Rch.Rows.Count;
            }

            progressBar1.Maximum = zaq2;
            whenDatesTableAdapter.Update(___BASA__DataSet);

            raspisanieTableAdapter.Update(___BASA__DataSet.raspisanie);
        }


        public string zapis = "";
        private void addZapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addZapis((DataGridView)contextMenuStripCELL.SourceControl);
        }

        private void addZapis(DataGridView curGrid)
        {
            bool pusto = true;
            if (curGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in curGrid.SelectedRows)
                {
                    if (((DataRowView)r.DataBoundItem)["zap"].ToString() != "")
                    {
                        pusto = false;
                        break;
                    }
                }
            }
            if (pusto ||
                (!pusto & MessageBox.Show("Выбранные строки содержат записи. Переписать все?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                DataGridViewRow notDel = new DataGridViewRow();
                DateTime minT = new DateTime();
                TimeSpan min = new TimeSpan(23, 59, 59);
                int per = 0;
                foreach (DataGridViewRow r22 in curGrid.SelectedRows)
                {
                    per += (int)((DataRowView)r22.DataBoundItem)["period"];
                    if (((DateTime)((DataRowView)r22.DataBoundItem)["time"]).TimeOfDay < min)
                    {
                        notDel = r22;
                        min = ((DateTime)((DataRowView)r22.DataBoundItem)["time"]).TimeOfDay;
                        minT = (DateTime)((DataRowView)r22.DataBoundItem)["time"];
                    }
                }
                RaspChenAddZap add = new RaspChenAddZap();
                add.Tag = this;
                add.richTextBox1.Text = ((DataRowView)notDel.DataBoundItem)["zap"].ToString();
                if (add.ShowDialog() == DialogResult.Yes)
                {
                    if (curGrid.SelectedRows.Count > 0)
                    {

                        foreach (DataGridViewRow r in curGrid.SelectedRows)
                        {
                            if (r != notDel)
                            {
                                ((DataRowView)r.DataBoundItem).Row.Delete();
                            }
                        }
                        ((DataRowView)notDel.DataBoundItem).Row["period"] = per;
                        ((DataRowView)notDel.DataBoundItem).Row["zap"] = zapis;
                        ((DataRowView)notDel.DataBoundItem).Row["zapTag"] = "zapDef";
                        curGrid.EndEdit();
                    }
                }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboSelChenge();
        }

        private void comboSelChenge()
        {
            if (comboBox1.SelectedValue != null)
            {
                DID = (int)comboBox1.SelectedValue;
                string did = DID.ToString();
                whenDatesBindingSource.Filter = "DID=" + did;
                if (___BASA__DataSet.whenDates.Select("DID=" + did).Length == 0)
                {
                    raspisanieBindingSource1.Filter = "DID=" + did + " AND whenID=0" + " AND dow=1";
                    raspisanieBindingSource2.Filter = "DID=" + did + " AND whenID=0" + " AND dow=2";
                    raspisanieBindingSource3.Filter = "DID=" + did + " AND whenID=0" + " AND dow=3";
                    raspisanieBindingSource4.Filter = "DID=" + did + " AND whenID=0" + " AND dow=4";
                    raspisanieBindingSource5.Filter = "DID=" + did + " AND whenID=0" + " AND dow=5";
                    raspisanieBindingSource6.Filter = "DID=" + did + " AND whenID=0" + " AND dow=6";
                    raspisanieBindingSource7.Filter = "DID=" + did + " AND whenID=0" + " AND dow=0";
                    checkBoxDefault.Checked = true;
                    checkBoxDefault.AutoCheck = false;
                }
            }
            else
            {
                DID = 0;
            }
        }

        private void whenDatesDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            {
                whenDatesDataGridView1.Rows[e.RowIndex].Selected = true;
                if (whenDatesBindingSource.Current != null & comboBox1.SelectedValue != null)
                {
                    checkBoxDefault.Checked = false;
                    checkBoxDefault.AutoCheck = true;
                    wen = (int)((DataRowView)whenDatesDataGridView1.Rows[e.RowIndex].DataBoundItem)["ID"];
                    string did = comboBox1.SelectedValue.ToString();
                    string wenID = wen.ToString();

                    raspisanieBindingSource1.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=1";
                    raspisanieBindingSource2.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=2";
                    raspisanieBindingSource3.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=3";
                    raspisanieBindingSource4.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=4";
                    raspisanieBindingSource5.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=5";
                    raspisanieBindingSource6.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=6";
                    raspisanieBindingSource7.Filter = "DID=" + did + " AND whenID=" + wenID + " AND dow=0";
                }
            }
        }

        private void dataGridView7_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            addZapis((DataGridView)sender);
        }

        private void sumTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView gri = (DataGridView)contextMenuStripCELL.SourceControl;
            if (gri.SelectedRows.Count > 1)
            {
                bool pusto = true;

                foreach (DataGridViewRow r in gri.SelectedRows)
                {
                    if (((DataRowView)r.DataBoundItem)["zap"].ToString() != "")
                    {
                        pusto = false;
                        break;
                    }
                }


                if (pusto ||
                    (!pusto & MessageBox.Show("Выбранные строки содержат записи. Объединение приведет к потере всех записей, кроме верхней.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    DataGridViewRow notDel = new DataGridViewRow();
                    DateTime minT = new DateTime();
                    TimeSpan min = new TimeSpan(23, 59, 59);
                    int per = 0;
                    foreach (DataGridViewRow r in gri.SelectedRows)
                    {
                        per += (int)((DataRowView)r.DataBoundItem)["period"];
                        if (((DateTime)((DataRowView)r.DataBoundItem)["time"]).TimeOfDay < min)
                        {
                            notDel = r;
                            min = ((DateTime)((DataRowView)r.DataBoundItem)["time"]).TimeOfDay;
                            minT = (DateTime)((DataRowView)r.DataBoundItem)["time"];
                        }
                    }
                    foreach (DataGridViewRow r in gri.SelectedRows)
                    {
                        if (r != notDel)
                        {
                            ((DataRowView)r.DataBoundItem).Row.Delete();
                        }
                    }
                    ((DataRowView)notDel.DataBoundItem).Row["period"] = per;
                }
            }

        }

        private void contextMenuStripCELL_Opening(object sender, CancelEventArgs e)
        {
            DataGridView gri = (DataGridView)contextMenuStripCELL.SourceControl;
            if (gri.SelectedRows.Count > 1)
            {
                delimTimeToolStripMenuItem.Enabled = false;
                sumTimeToolStripMenuItem.Enabled = true;
            }
            else
            {
                delimTimeToolStripMenuItem.Enabled = true;
                sumTimeToolStripMenuItem.Enabled = false;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((DataGridView)contextMenuStripCELL.SourceControl).SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in ((DataGridView)contextMenuStripCELL.SourceControl).SelectedRows)
                {
                    ((DataRowView)dgvr.DataBoundItem)["zap"] = ((DataRowView)dgvr.DataBoundItem)["zapTag"] = "";
                }
            }
        }

        public DateTime data_new_delimRasCh = new DateTime();
        public int new_per1 = new int();
        public bool where_zapDelim = true;
        private void delimTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView grid = (DataGridView)contextMenuStripCELL.SourceControl;
            if (grid.SelectedRows.Count == 1)
            {
                DataRowView curent_row = (DataRowView)grid.SelectedRows[0].DataBoundItem;
                ___BASA__DataSet.raspisanieRow cr = (___BASA__DataSet.raspisanieRow)curent_row.Row;
                DelimVremya dv = new DelimVremya();
                int curent_per = dv.periodDefault = cr.period;
                dv.startTime = cr.time;
                dv.Tag = this;
                if (dv.ShowDialog() == DialogResult.OK)
                {
                    cr.period = new_per1;

                    ___BASA__DataSet.raspisanieRow nR = ___BASA__DataSet.raspisanie.NewraspisanieRow();
                    nR.time = data_new_delimRasCh;
                    nR.period = curent_per - new_per1;
                    nR.dow = cr.dow;
                    nR.DID = cr.DID;
                    nR.whenID = cr.whenID;
                    if (where_zapDelim)
                    {
                        nR.zap = nR.zapTag = "";
                    }
                    else
                    {
                        nR.zap = cr.zap;
                        nR.zapTag = cr.zapTag;
                        cr.zapTag = ""; cr.zap = "";
                    }
                    ___BASA__DataSet.raspisanie.AddraspisanieRow(nR);
                }
            }
        }

        private void RaspChenge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
