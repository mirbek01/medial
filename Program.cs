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
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;

namespace DSS
{
    static class Program
    {
        [STAThread]

        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                SingleInstanceApplication.Run(new MainForm(), StartupNextInstanceHandler);
            }

            catch (Exception e)
            {
                try
                {
                    using (StreamWriter w = File.AppendText("error_list.log"))
                    {
                        Log("Message: " + e.Message, "StackTrace: " + e.StackTrace, w);
                        w.Close();
                    }
                }
                catch { }
                MessageBox.Show("[" + e.Message + "]\rВ каталоге приложения создан отчет об ошибке \"error_list.log\". Просьба отправить отчет разработчику (doctor.dss@mail.ru).\rПриносим извинения за причиненные неудобства. Приложение будет закрыто.", "Dental Simple Service : Критическая ошибка");
            }
        }

        static void StartupNextInstanceHandler(object sender, StartupNextInstanceEventArgs e)
        {
            e.BringToForeground = true;
        }


        public static void Log(String logMessage,String stack, TextWriter w)
        {
            w.Write("\r\nERROR : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());           
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("  :{0}", stack);
            w.WriteLine("-------------------------------");
                    w.Flush();
        }

    }

}
