using System;
using System.Windows.Forms;

using System.Data.Entity;

using PRInterfaces.Interfaces;

using PRUI.Forms;

using PR.Classes;

namespace PR
{
    static class Program
    { 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Debug());
        }
    }
}
