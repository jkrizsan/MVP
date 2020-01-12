using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MVP.API.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        public bool SendMail(string message, string target)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("");
                mail.To.Add(target);
                mail.Subject = "Invoice Mail";
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("", "");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
