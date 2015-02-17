using System;
using System.Net.Mail;
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
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ThreadErrorHandler);
            Application.ThreadException +=Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Abort;
            try
            {
                ReportError_Form reportErrorForm = new ReportError_Form(e);
                reportErrorForm.ShowDialog();

               // result = MessageBox.Show("Whoops! Please contact the developers with the"
                 // + " following information:\n\n" + e.Exception.Message + e.Exception.StackTrace,
                  //"Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
            }
            finally
            {
                if (result == DialogResult.Abort)
                {
                    Application.Exit();
                }
            }
        }
        private static void ThreadErrorHandler(object sender, UnhandledExceptionEventArgs t)
        {

            string message = (t.ExceptionObject as Exception).Message;
            MailMessage mail = new MailMessage("crawler@hellborg.org", "jonatanhellborg@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.citynetwork.se";
            mail.Subject = "this is a test email.";
            mail.Body = message;



            client.Send(mail);
        }
    }
}