using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Net.Mail;

namespace Crawler2._0.Forms
{
    public partial class ReportErrorForm : Form
    {
        ThreadExceptionEventArgs t_error;
        public ReportErrorForm(ThreadExceptionEventArgs t)
        {
            InitializeComponent();
            t_error = t;
        }
        
        private void ReportError_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage("crawler@hellborg.org", "jonatanhellborg@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.citynetwork.se";
            client.Credentials = new NetworkCredential("crawler@hellborg.org","Hotchner13");
            mail.Subject = "Uncaught Error - "+DateTime.Now;
            mail.Body = "Date: " + DateTime.Now +
                        "\n User message: "+ textBox1.Text+
                        "\n Error"+t_error.Exception.Message+
                        "\n Stacktrace "+t_error.Exception.StackTrace+
                        "\n BaseException "+t_error.Exception.GetBaseException();


            try
            {
                client.Send(mail);
                Application.Exit();
            }
            catch ( SmtpFailedRecipientException ex)
            {
                MessageBox.Show(ex.Message);
            }
           



          
            
            


        }
    }
}
