using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Web;
using System.IO;

using System.Text.RegularExpressions;

namespace PRParser
{
    public partial class WebBrowserForm : Form
    {
        private Zakamned _zakam;

        public WebBrowserForm(Zakamned zakam)
        {
            InitializeComponent();

            _zakam = zakam;
        }

         private void button2_Click(object sender, EventArgs e)
        {
            Uri ur = new Uri(@"http://zakamned.ru/base/index.php?b=1");
            webBrowser.Url = ur;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc;

            doc = webBrowser.Document;

            HtmlElementCollection coll = doc.Body.All;

            foreach (HtmlElement el in coll)
            {
                if (el.OuterHtml != null)
                {
                    if (el.OuterHtml.Length < 1000)
                    {
                        MatchCollection matches;
                        string pattern = @"<tr.*><td>.*" + _zakam.address + @".*</td>.*<td>.*" + _zakam.grossArea + @"/" +_zakam.livingArea + @"/" +_zakam.kitchenArea+ @".*</td>.*<td>.*" + _zakam.phoneToCall + @".*</td>";
                        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

                        matches = regex.Matches(el.OuterHtml);

                        if (matches.Count > 0)
                        {
                            string a= "border:2px; color:red;";
                            el.Style = a;

                            webBrowser.Document.Window.ScrollTo(new Point(0, el.OffsetRectangle.Y + el.Parent.OffsetRectangle.Y + el.Parent.Parent.OffsetRectangle.Y));
                        }
                    }
                }
            }
        }
    }
}
