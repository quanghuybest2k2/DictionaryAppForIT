using DictionaryAppForIT.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new CustomMessageBox.Form1());
            Application.Run(new frmLogin());

            //Application.Run(new frmSignUp());

            //Application.Run(new frmMain());
            //Application.Run(new Form1());
        }
    }
}
