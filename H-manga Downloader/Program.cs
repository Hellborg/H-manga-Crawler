using System;
using System.Threading;
using System.Windows.Forms;
using Crawler2._0.Forms;

namespace Crawler2._0
{
    internal static class Program
    {
        /// <summary>
        ///     The main en
        ///     point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var result = DialogResult.Abort;
            try
            {
                var reportErrorForm = new ReportErrorForm(e);
                reportErrorForm.ShowDialog();
            }
            finally
            {
                if (result == DialogResult.Abort)
                {
                    Application.Exit();
                }
            }
        }

       
    }
}