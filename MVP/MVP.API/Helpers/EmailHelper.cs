using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MVP.API.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        public IConfiguration Configuration { get; }

        public EmailHelper(IConfiguration Configuration = null)
        {
            this.Configuration = Configuration;
        }

        private string GetMailData(string param)
            => Configuration.GetSection("EmailSettings").GetSection(param).Value;

        public bool SendMail(string message, string target)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(GetMailData("Server"));
                mail.From = new MailAddress(GetMailData("From"));
                mail.To.Add(target);
                mail.Subject = GetMailData("Subject");
                mail.Body = message;

                SmtpServer.Port = Convert.ToInt32(GetMailData("Port"));
                SmtpServer.Credentials = new System.Net.NetworkCredential(GetMailData("User"), GetMailData("Password"));
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
