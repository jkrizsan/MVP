using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;

namespace MVP.Services
{
    public class EmailService : IEmailService
    {
        private const string EmailSettings = "EmailSettings";
        private const string Server = "Server";
        private const string From = "From";
        private const string Subject = "Subject";
        private const string Port = "Port";
        private const string User = "User";
        private const string Password = "Password";

        public IConfiguration Configuration { get; }

        public EmailService(IConfiguration Configuration = null)
        {
            this.Configuration = Configuration;
        }

        private string GetMailData(string param)
            => Configuration.GetSection(EmailSettings).GetSection(param).Value;

        /// <inheritdoc />
        public bool SendMail(string message, string target)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(GetMailData(Server));
                mail.From = new MailAddress(GetMailData(From));
                mail.To.Add(target);
                mail.Subject = GetMailData(Subject);
                mail.Body = message;

                SmtpServer.Port = Convert.ToInt32(GetMailData(Port));
                SmtpServer.Credentials = new System.Net.NetworkCredential(GetMailData(User), GetMailData(Password));
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
