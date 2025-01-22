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
    public partial class MoneyMoov : Form
    {
        public MoneyMoov()
        {
            InitializeComponent();
        }

        string filterPID = "";
        string filterDate1 = "Dates>'" + DateTime.MinValue + "' ";
        string filterDate2 = " AND Dates<'" + DateTime.MaxValue + "' ";
        string filterPred = "'предоплата'";
        string filterPay = " OR Why='оплата лечения'";
        string filterDolgProshen = " OR Why='списание долга'";
        string filterDolgCur = " OR Why='неоплаченный долг'";
        string filterPredBack = " OR Why='возврат предоплаты'";
        string filterNarad = " OR Why='наряд'";
        string filterUchet = " OR Why='учет предоплаты'";

        private void MoneyMoov_Load(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.Date;
            dateTimePicker1.MaxDate = dateTimePicker2.Value.Date;
            filter();
            plataMoovBindingSource.ListChanged += plataMoovBindingSource_ListChanged;
        }

        private void MoneyMoov_Activated(object sender, EventArgs e)
        {
            this.plataMoovTableAdapter.Fill(this.___BASA__DataSet.PlataMoov);
        }

        public void PatFilter(int filtPat, string PFIO)
        {
            EnableButtonAllTime();
            toolStripButtonTakeAll.Checked = true;
            filterPID = " AND PID=" + filtPat.ToString();
            labelPFIO.Text = PFIO;
            panelPFIO.Visible = true;
            onePat_ToolStripMenuItem.Checked = true;
            filter();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            filterDate2 = " AND Dates<'" + dateTimePicker2.Value.Date.AddDays(1).ToString() + "' ";
            filter();
            dateTimePicker1.MaxDate = dateTimePicker2.Value.Date;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filterDate1 = "Dates>='" + dateTimePicker1.Value.Date.ToString() + "' ";
            filter();
            dateTimePicker2.MinDate = dateTimePicker1.Value.Date;
        }

        private void radioButtonPeriod_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonPeriod.Checked)
            {
                DatesCheck();
                dateTimePicker1.Enabled = dateTimePicker2.Enabled = true;
                filterDate2 = " AND Dates<='" + dateTimePicker2.Value.Date.ToString() + "' ";
                filterDate1 = "Dates>='" + dateTimePicker1.Value.Date.ToString() + "' ";
                filter();
                toolStripButtonPeriod.Checked = true;
            }
        }

        private void radioButtonAllTime_Click(object sender, EventArgs e)
        {
            EnableButtonAllTime();
            filter();
        }

        private void EnableButtonAllTime()
        {
            if (!toolStripButtonAllTime.Checked)
            {
                DatesCheck();
                dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
                filterDate2 = "";
                filterDate1 = "Dates>'" + DateTime.MinValue + "' ";
                toolStripButtonAllTime.Checked = true;
            }
        }

        private void DatesCheck()
        {
            foreach (ToolStripButton b in new ToolStripButton[] { toolStripButtonAllTime, toolStripButtonMonth, toolStripButtonPeriod, toolStripButtonToday })
            {
                b.Checked = false;
            }
        }

        private void radioButtonMonth_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonMonth.Checked)
            {
                DatesCheck();
                dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
                filterDate2 = " AND Dates<'" + DateTime.Today.Date.AddDays(-DateTime.Today.Date.Day + 1).AddMonths(1) + "' ";
                filterDate1 = "Dates>='" + DateTime.Today.Date.AddDays(-DateTime.Today.Date.Day + 1) + "' ";
                filter();
                toolStripButtonMonth.Checked = true;
            }
        }

        private void radioButtonToday_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonToday.Checked)
            {
                DatesCheck();
                dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
                filterDate2 = " AND Dates<'" + DateTime.Today.Date.AddDays(1) + "' ";
                filterDate1 = "Dates>='" + DateTime.Today.Date + "' ";
                filter();
                toolStripButtonToday.Checked = true;
            }
        }

        private void plataMoovDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex != -1 & e.ColumnIndex != -1))
            {
                plataMoovDataGridView.CurrentCell = plataMoovDataGridView[e.ColumnIndex, e.RowIndex];
                plataMoovDataGridView[e.ColumnIndex, e.RowIndex].ContextMenuStrip = contextMenuStripCell;
            }
        }

        private void onePat_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!onePat_ToolStripMenuItem.Checked)
            {
                filterPID = " AND PID = '" + ((___BASA__DataSet.PlataMoovRow)((DataRowView)plataMoovDataGridView.CurrentRow.DataBoundItem).Row).PID.ToString() + "'";
                filter();
                onePat_ToolStripMenuItem.Checked = true;
            }
            else
            {
                filterPID = "";
                filter();
                onePat_ToolStripMenuItem.Checked = false;
            }
        }

        private void openKartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int patID = ((___BASA__DataSet.PlataMoovRow)((DataRowView)plataMoovDataGridView.CurrentRow.DataBoundItem).Row).PID;
            if (kartaTableAdapter1.ScalarQueryCuontByPID(patID) == 1)
            {
                KartaForm pat = new KartaForm();
                pat.Tag = patID;
                pat.Text = "Карточка: " + ((___BASA__DataSet.PlataMoovRow)((DataRowView)plataMoovDataGridView.CurrentRow.DataBoundItem).Row).PFIO;
                ((MainForm)this.MdiParent).checkWin(pat);
            }
            else
            {
                MessageBox.Show("Карточка не найдена. Возможно, она была удалена.");
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (filterPID != "")
            {
                onePat_ToolStripMenuItem.Checked = true;
            }
            else
            {
                onePat_ToolStripMenuItem.Checked = false;
            }
        }


        private void plataMoovBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            string localFilter = plataMoovBindingSource.Filter;
            decimal pred = 0;
            decimal pay = 0;
            decimal dolgProstil = 0;
            decimal back = 0;
            decimal narad = 0;

            if (___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='предоплата'").GetType() != typeof(DBNull) && filterPred != "''")
            {
                pred = Convert.ToDecimal(___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='предоплата'"));
            }

            if (___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='оплата лечения'").GetType() != typeof(DBNull) && filterPay != "")
            {
                pay = (decimal)___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='оплата лечения'");
            }
            if (___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='списание долга'").GetType() != typeof(DBNull) && filterDolgProshen != "")
            {
                dolgProstil = (decimal)___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='списание долга'");
            }
            if (___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='возврат предоплаты'").GetType() != typeof(DBNull) && filterPredBack != "")
            {
                back = (decimal)___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='возврат предоплаты'");
            }
            if (___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='неоплаченный долг'").GetType() != typeof(DBNull) && filterDolgCur != "")
            {
                narad = (decimal)___BASA__DataSet.PlataMoov.Compute("SUM(Summa)", filterDate1 + filterDate2 + filterPID + " AND Why='неоплаченный долг'");
            }
            labelPred.Text = pred.ToString();
            labelPay.Text = pay.ToString();
            labelDolg.Text = dolgProstil.ToString();
            labelBack.Text = back.ToString();
            labelDolgCur.Text = narad.ToString();
            decimal pribil = pred + pay;
            labelPrib.Text = pribil.ToString();
            decimal ubit = dolgProstil + back + narad;
            labelUbit.Text = ubit.ToString();
            decimal all = pribil - ubit;
            labelAll.Text = all.ToString();
        }

        private void checkBoxPred_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButtonPred.Checked)
            {
                filterPred = "'предоплата'";
                filter();
            }
            else
            {
                toolStripButtonTakeAll.Checked = false;
                filterPred = "''";
                filter();
            }
        }

        void filter()
        {
            string val = filterDate1 + filterDate2 + filterPID + "AND ( Why=" + filterPred + filterPay + filterDolgProshen
                + filterDolgCur + filterPredBack + filterNarad + filterUchet + ")";
            plataMoovBindingSource.Filter = val;

        }

        private void checkBoxPay_CheckedChanged(object sender, EventArgs e)
        {

            if (toolStripButtonPay.Checked)
            {
                filterPay = " OR Why='оплата лечения'";
                filter();
            }
            else
            {
                toolStripButtonTakeAll.Checked = false;
                filterPay = "";
                filter();
            }
        }

        private void checkBoxDolgProshen_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButtonDolgProshen.Checked)
            {
                filterDolgProshen = " OR Why='списание долга'";
                filter();
            }
            else
            {
                toolStripButtonTakeAll.Checked = false;
                filterDolgProshen = "";
                filter();
            }
        }

        private void checkBoxDolg_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButtonDolg.Checked)
            {
                filterDolgCur = " OR Why='неоплаченный долг'";
                filter();
            }
            else
            {
                toolStripButtonTakeAll.Checked = false;
                filterDolgCur = "";
                filter();
            }
        }

        private void checkBoxPredBack_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButtonPredBack.Checked)
            {
                filterPredBack = " OR Why='возврат предоплаты'";
                filter();
            }
            else
            {
                toolStripButtonTakeAll.Checked = false;
                filterPredBack = "";
                filter();
            }
        }

        private void checkBoxNarad_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButtonNarad.Checked)
            {
                filterNarad = " OR Why='наряд'";
                filter();
            }
            else
            {
                toolStripButtonTakeAll.Checked = false;
                filterNarad = "";
                filter();
            }
        }

        private void buttonRemmovFilter_Click(object sender, EventArgs e)
        {
            panelPFIO.Visible = false;
            toolStripButtonTakeAll.Checked = true;
            onePat_ToolStripMenuItem.Checked = false;
            filterPID = "";
            EnableButtonAllTime();
            filter();
        }

        private void checkBoxTakeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButtonTakeAll.Checked)
            {

                toolStripButtonPred.Checked = toolStripButtonPay.Checked = toolStripButtonDolgProshen.Checked = toolStripButtonDolg.Checked = toolStripButtonPredBack.Checked = toolStripButtonNarad.Checked = true;
                toolStripButtonTakeAll.CheckOnClick = false;
            }
            else
            {
                toolStripButtonTakeAll.CheckOnClick = true;
            }
        }

        private void checkBoxPredYchet_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButtonPredYchet.Checked)
            {
                filterUchet = " OR Why='учет предоплаты'";
                filter();
            }
            else
            {
                toolStripButtonTakeAll.Checked = false;
                filterUchet = "";
                filter();
            }
        }
    }
}
