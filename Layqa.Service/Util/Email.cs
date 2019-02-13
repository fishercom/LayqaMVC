using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Layqa.Service.Util
{
    public class Email
    {

        private string SMTP_Username { get; set; }
        private string SMTP_Password { get; set; }
        private string SMTP_Host { get; set; }
        private int SMTP_Port { get; set; }
        private bool SMTP_SSL { get; set; }

        public string ErrorMsg {get; set;}

        public Email()
        {
            SMTP_Username = ConfigurationManager.AppSettings["SMTP_Username"].ToString();
            SMTP_Password = ConfigurationManager.AppSettings["SMTP_Password"].ToString(); //C0nT@cT0+88
            SMTP_Host = ConfigurationManager.AppSettings["SMTP_Host"].ToString();
            SMTP_Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]); // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
            SMTP_SSL = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTP_SSL"]);
        }

        public bool Send(string ToEmail, string Subject, string Body)
        {
            bool sent = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = SMTP_Host;
            smtp.Port = SMTP_Port;
            smtp.EnableSsl = SMTP_SSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(SMTP_Username, SMTP_Password);

            try
            {
                using (var message = new MailMessage(SMTP_Username, ToEmail))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                    sent = true;
                }
            }
            catch (Exception ex) {
                ErrorMsg = ex.Message;
            }

            return sent;
        }
    }
}
