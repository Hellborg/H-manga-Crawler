using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace Crawler2._0.Forms
{
    public partial class ReportErrorForm : Form
    {
        private readonly ThreadExceptionEventArgs _tError;

        public ReportErrorForm(ThreadExceptionEventArgs t)
        {
            InitializeComponent();
            _tError = t;
        }

        private void ReportError_Form_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Date: " + DateTime.Now +
                        "\n User message: " + textBox1.Text +
                        "\n Error" + _tError.Exception.Message +
                        "\n Stacktrace " + _tError.Exception.StackTrace +
                        "\n BaseException " + _tError.Exception.GetBaseException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mail = new MailMessage("crawler@hellborg.org", "jonatanhellborg@gmail.com");
            var client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.citynetwork.se";
            client.Credentials = new NetworkCredential("crawler@hellborg.org", "");
            mail.Subject = "Uncaught Error - " + DateTime.Now;
            mail.Body = "Date: " + DateTime.Now +
                        "\n User message: " + textBox1.Text +
                        "\n Error" + _tError.Exception.Message +
                        "\n Stacktrace " + _tError.Exception.StackTrace +
                        "\n BaseException " + _tError.Exception.GetBaseException();


            try
            {
                client.Send(mail);
                Application.Exit();
            }
            catch (SmtpFailedRecipientException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}