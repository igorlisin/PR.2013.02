using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Word;

using PRInterfaces.Interfaces;

namespace PRDocument
{
    public class ReportGenerator
    {
        public static void Generate(IReport report, string reportTemplatesFolderPath, string reportsFolderPath)
        {
            Microsoft.Office.Interop.Word.Application a = new Microsoft.Office.Interop.Word.Application();

            string c = reportTemplatesFolderPath + @"\reportTemplate.dotx";
            object d = (object)c;
            string reportName;

            Document b = a.Documents.Add(ref d);

            reportName = reportsFolderPath + @"\report " + DateTime.Now.ToString().Replace(":", ".") + @".docx";

            try
            {
                Paragraph pr = b.Paragraphs.Add();
                Range rg;

                Bookmarks bk = b.Bookmarks;
                int bkcount = bk.Count;

                rg = bk["bookmark1"].Range;

                rg.Text = "blablabla";
            }
            catch
            {
            }

            b.SaveAs2(reportName);

            b.Close();

            a.Quit();
        }
    }
}
