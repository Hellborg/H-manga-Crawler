using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Crawler2._0.Forms
{
    public partial class ReportError_Form : Form
    {
        ThreadExceptionEventArgs t_error;
        public ReportError_Form(ThreadExceptionEventArgs t)
        {
            InitializeComponent();
            t_error = t;
        }
        
        private void ReportError_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = t_error.Exception.Message;
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
