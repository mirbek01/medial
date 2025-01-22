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
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace DSS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int i = 0;  //счетчик окон
        ToolStripStatusLabel activStatLabl = new ToolStripStatusLabel();// активная кнопка
        Font label_enter = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        Font tach = new System.Drawing.Font("Tachoma", 8.25F);
        Font label_leave = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));


        void NovWin(Form addedForm)// при открытии нового окна создает для него кнопку
        {
            Cursor = Cursors.WaitCursor;
            i++;
            pictureBoxIcon.Visible = true;
            pictureBoxFon.Visible = false;
            if (this.MdiChildren.Length > 0 && !winToolStripMenuItem.Visible)
            {
                winToolStripMenuItem.Visible = true;
            }

            buttonClose.Visible = true;

            addedForm.Name = "@@forma" + i.ToString();
            addedForm.Activated += new EventHandler(addedForm_Activated);
            addedForm.ShowIcon = false;
            addedForm.TextChanged += new EventHandler(addedForm_TextChanged);
            addedForm.FormClosed += new FormClosedEventHandler(addedForm_FormClosed);


            ToolStripStatusLabel addedStatLabl = new ToolStripStatusLabel();
            addedStatLabl.Tag = addedForm;
            addedStatLabl.Name = addedForm.Name;
            addedStatLabl.Text = addedForm.Text;
            addedStatLabl.Image = addedForm.Icon.ToBitmap();
            addedStatLabl.Spring = true;
            addedStatLabl.AutoSize = false;
            addedStatLabl.BorderSides = ToolStripStatusLabelBorderSides.All;
            addedStatLabl.ImageAlign = ContentAlignment.TopLeft;
            addedStatLabl.TextAlign = ContentAlignment.BottomLeft;
            addedStatLabl.TextImageRelation = TextImageRelation.ImageAboveText;
            addedStatLabl.MouseDown += new MouseEventHandler(StatusLabelFORfindow_MouseDown);
            addedStatLabl.MouseUp += new MouseEventHandler(StatusLabelFORfindow_MouseUp);
            addedStatLabl.MouseEnter += new EventHandler(StatusLabelFORfindow_MouseEnter);
            addedStatLabl.MouseLeave += new EventHandler(StatusLabelFORfindow_MouseLeave);
            addedStatLabl.MouseHover += new EventHandler(StatusLabelFORfindow_MouseHover);

            statusStripDown.Items.Insert(0, addedStatLabl);

            addedForm.MdiParent = this;

            if (this.MdiChildren.Length == 1)
            {
                addedForm.Height = this.Height - statusStripDown.Height - menuStripMain.Height - 6;
                if (panel_left_menu.Visible)
                {
                    addedForm.Width = this.Width - panel_H_SH.Width - panel_left_menu.Width - 6;
                }
                else
                {
                    addedForm.Width = this.Width - panel_H_SH.Width - 6;
                }
            }
            addedForm.Show();

            Cursor = Cursors.Default;
        }

        void addedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            statusStripDown.Items.RemoveByKey(((Form)sender).Name);
            if (this.MdiChildren.Length == 1)
            {
                pictureBoxFon.Visible = true;
                pictureBoxIcon.Visible = false;
                buttonClose.Visible = false;
                winToolStripMenuItem.Visible = false;
            }
        }

        void closeForm()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
                if (this.ActiveMdiChild != null)
                {
                    this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
                }
            }
        }

        void addedForm_Activated(object sender, EventArgs e)
        {
            activStatLabl.BackColor = Color.Bisque;
            activStatLabl.BorderStyle = Border3DStyle.RaisedInner;

            foreach (ToolStripItem tb in statusStripDown.Items)
            {
                if (tb.GetType() == typeof(ToolStripStatusLabel) && (Form)tb.Tag == this.ActiveMdiChild)
                {
                    activStatLabl = (ToolStripStatusLabel)tb;
                }
            }
            activStatLabl.BackColor = Color.Chocolate;
            activStatLabl.BorderStyle = Border3DStyle.Sunken;

            pictureBoxIcon.Image = activStatLabl.Image;
        }

        void addedForm_TextChanged(object sender, EventArgs e)
        {
            foreach (ToolStripItem lb in statusStripDown.Items)
            {
                if (lb.GetType() == typeof(ToolStripStatusLabel) && ((Form)sender).Name == lb.Name)
                {
                    lb.Text = ((Form)sender).Text;
                }
            }
        }

        void StatusLabelFORfindow_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(statusStripDown, ((ToolStripStatusLabel)sender).Text);
        }

        void StatusLabelFORfindow_MouseLeave(object sender, EventArgs e)
        {
            ((ToolStripStatusLabel)sender).Spring = true;
            ((ToolStripStatusLabel)sender).Font = tach;

            if (((ToolStripStatusLabel)sender) == activStatLabl)
            {
                ((ToolStripStatusLabel)sender).BackColor = Color.Chocolate;
                ((ToolStripStatusLabel)sender).BorderStyle = Border3DStyle.Sunken;
            }
            else
            {
                ((ToolStripStatusLabel)sender).BackColor = Color.Bisque;
                ((ToolStripStatusLabel)sender).BorderStyle = Border3DStyle.RaisedInner;
            }
        }

        void StatusLabelFORfindow_MouseEnter(object sender, EventArgs e)
        {
            if (statusStripDown.Items.Count > 10)
            {
                ((ToolStripStatusLabel)sender).Spring = false;
                ((ToolStripStatusLabel)sender).Width += 50;
            }
            ((ToolStripStatusLabel)sender).Font = label_enter;
            if (((ToolStripStatusLabel)sender) == activStatLabl)
            {
                ((ToolStripStatusLabel)sender).BackColor = Color.Peru;
                ((ToolStripStatusLabel)sender).BorderStyle = Border3DStyle.SunkenInner;
            }
            else
            {
                ((ToolStripStatusLabel)sender).BorderStyle = Border3DStyle.Raised;
                ((ToolStripStatusLabel)sender).BackColor = Color.Linen;
            }
        }

        void StatusLabelFORfindow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ToolStripStatusLabel rCl = (ToolStripStatusLabel)sender;
                CloseDownToolStripMenuItem.Text = "Закрыть " + rCl.Text + " (Ctrl+W)";
                contextMenuStripDown.Tag = rCl.Tag;
                contextMenuStripDown.Show(statusStripDown, rCl.Bounds.Left + e.X, rCl.Bounds.Top + e.Y);
            }
        }

        void StatusLabelFORfindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (((ToolStripStatusLabel)sender) == activStatLabl)
                { ((ToolStripStatusLabel)sender).BorderStyle = Border3DStyle.Sunken; }
                else
                {
                    ((ToolStripStatusLabel)sender).BorderStyle = Border3DStyle.SunkenInner;
                    ((ToolStripStatusLabel)sender).BackColor = Color.Bisque;
                }
            }
            if (e.Button == MouseButtons.Left && ((ToolStripStatusLabel)sender) != activStatLabl)
            {
                ((ToolStripStatusLabel)sender).BorderStyle = Border3DStyle.Sunken;
                ((ToolStripStatusLabel)sender).BackColor = Color.Chocolate;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)//при клике на кнопке активеруется ее окно
        {
            if (this.ActiveMdiChild != (Form)e.ClickedItem.Tag)
            {
                activateForm((Form)e.ClickedItem.Tag);
            }
        }

        private void closeStripMenuItem_Click(object sender, EventArgs e)//close меню кнопки
        {
            ((Form)contextMenuStripDown.Tag).Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            { f.Close(); }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)//закрыть текущ окно(главн. меню)
        {
            closeForm();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form About = new AboutBox1();
            About.ShowDialog();
        }



        private void linkLabel_capt_1_MouseEnter(object sender, EventArgs e)
        {
            ((LinkLabel)sender).Font = label_enter;

            ((LinkLabel)sender).LinkColor = Color.Wheat;
        }

        private void linkLabel_capt_1_MouseLeave(object sender, EventArgs e)
        {
            ((LinkLabel)sender).Font = label_leave;
            ((LinkLabel)sender).LinkColor = Color.White;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (panel_left_menu.Visible)
            {
                panel_left_menu.Visible = false;
            }
            else
            {
                panel_left_menu.Visible = true;
            }
        }

        private void linkLabel_reg_pat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//создаем окно"пациенты"
        {
            checkWin(new PatientsForm());
        }

        void activateForm(Form forma)
        {
            if (forma != this.ActiveMdiChild)
            {
                Cursor = Cursors.WaitCursor;
                forma.Location = new Point(-3, -30);
                forma.Height = this.Height - statusStripDown.Height - menuStripMain.Height - 6;
                if (panel_left_menu.Visible)
                {
                    forma.Width = this.Width - panel_H_SH.Width - panel_left_menu.Width - 6;
                }
                else
                {
                    forma.Width = this.Width - panel_H_SH.Width - 6;
                }
                forma.Activate();
            }
            Cursor = Cursors.Default;
        }


        public Form checkWin(Form checkedForm)//проверка окна-новое или уже родное
        {
            Form forma = new Form();

            if (this.MdiChildren.Length > 0)
            {
                bool ch = false;

                foreach (Form formm in this.MdiChildren)
                {
                    if (checkedForm.Text == formm.Text && checkedForm.Tag.Equals(formm.Tag))
                    {
                        forma = formm;
                        activateForm(formm);

                        ch = true;
                        break;
                    }
                    else
                    {
                        ch = false;
                    }
                }
                if (!ch)
                {
                    forma = checkedForm;
                    NovWin(checkedForm);

                }
            }
            else
            {
                forma = checkedForm;
                NovWin(checkedForm);
            }
            return forma;
        }

        private void linkLabel_reg_newKart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KartaForm nova = new KartaForm();
            nova.Tag = 0;
            checkWin(nova);
        }


        private void linkLabel_reg_zapis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            checkWin(new ZapisZur());
        }


        private void SpravjchnikDS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SpravDS nova = new SpravDS();
            checkWin(nova);
        }


        private void linkLabelDolg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dolg nova = new Dolg();
            checkWin(nova);
        }

        private void linkLabel_pers_spiski_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Personal nova = new Personal();
            checkWin(nova);
        }

        private void linkLabel_pers_grafik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RaspChenge rc = new RaspChenge();
            if (rc.ShowDialog() == DialogResult.Yes)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.GetType() == typeof(ZapisZur))
                    {
                        MessageBox.Show("В данный момент открыто окно предварительной записи,\rне забудте его обновить для учета изменений");
                    }
                }
            }
        }

        private void linkLabel_menu_capt_MouseLeave(object sender, EventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            Panel p2 = (Panel)ll.Parent.Parent;
            ll.LinkColor = Color.Silver;

            if (p2.Height != p2.MinimumSize.Height)
            {
                ll.Image = DSS.Properties.Resources.bullet_up;
            }
            else
            {
                ll.Image = DSS.Properties.Resources.bullet_down;
            }
        }


        void win_Click(object sender, EventArgs e)
        {
            activateForm((Form)((ToolStripMenuItem)sender).Tag);
        }



        private void winToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            winToolStripMenuItem.DropDownItems.Clear();
            ToolStripMenuItem del = (ToolStripMenuItem)winToolStripMenuItem.DropDownItems.Add("Закрыть текущее");
            del.ShortcutKeys = Keys.Control | Keys.W;
            del.Click += закрытьToolStripMenuItem_Click;

            winToolStripMenuItem.DropDownItems.Add("-");
            ToolStripMenuItem delAll = (ToolStripMenuItem)winToolStripMenuItem.DropDownItems.Add("Закрыть все");
            delAll.Click += closeAllToolStripMenuItem_Click;
            winToolStripMenuItem.DropDownItems.Add("-");

            foreach (Form ff in this.MdiChildren)
            {
                ToolStripMenuItem win = (ToolStripMenuItem)winToolStripMenuItem.DropDownItems.Add(ff.Text);
                if (this.ActiveMdiChild == ff)
                {
                    win.Checked = true;
                }
                win.Tag = ff;
                win.Click += new EventHandler(win_Click);
            }
        }



        private void linkLabel_menu_capt_MouseEnter(object sender, EventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            Panel p2 = (Panel)ll.Parent.Parent;
            ll.LinkColor = Color.White;

            if (p2.Height != p2.MinimumSize.Height)
            {
                ll.Image = DSS.Properties.Resources.bullet_up_sel;
            }
            else
            {
                ll.Image = DSS.Properties.Resources.bullet_down_sel;
            }
        }

        private void linkLabel13_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LinkLabel ll = (LinkLabel)sender;
                Panel p2 = (Panel)ll.Parent.Parent;

                if (p2.Height != p2.MinimumSize.Height)
                {
                    p2.Height = p2.MinimumSize.Height;
                    ll.Image = DSS.Properties.Resources.bullet_down_sel;
                }
                else
                {
                    p2.Height = p2.MaximumSize.Height;
                    ll.Image = DSS.Properties.Resources.bullet_up_sel;
                }
            }
        }

        private void buttonShow_MouseHover(object sender, EventArgs e)
        {
            if (panel_left_menu.Visible)
            {
                toolTip1.SetToolTip(buttonShow, "Скрыть панель");
            }
            else
            {
                toolTip1.SetToolTip(buttonShow, "Показать панель");
            }
            toolTip1.AutoPopDelay = 1000;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В данной версии программы не доступно");
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MoneyMoov nova = new MoneyMoov();
            checkWin(nova);
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KorzinaKart k = new KorzinaKart();
            k.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KorzinaKadry k = new KorzinaKadry();
            k.ShowDialog();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StatPoses s = new StatPoses();
            checkWin(s);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StatDiagn sd = new StatDiagn();
            checkWin(sd);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StatTreat s = new StatTreat();
            checkWin(s);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(DSS.Properties.Settings.Default.__BASA__ConnectionString1);
                conn.Open();
                conn.Close();
            }
            catch (Exception q)
            {
                MessageBox.Show(q.Message + "\rПриложение будет закрыто.", "Dental Simple Service - Ошибка подключения к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


    }



}
