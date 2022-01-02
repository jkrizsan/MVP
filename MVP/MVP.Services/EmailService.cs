using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;

namespace MVP.Services
{
    public class EmailService : IEmailService
    {
        private const string EmailSettings = nameof(EmailSettings);
        private const string Server = nameof(Server);
        private const string From = nameof(From);
        private const string Subject = nameof(Subject);
        private const string Port = nameof(Port);
        private const string User = nameof(User);
        private const string Password = nameof(Password);

        public IConfiguration Configuration { get; }

        public EmailService(IConfiguration configuration = null)
        {
            Configuration = configuration;
        }

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

        private string GetMailData(string param) =>
            Configuration
            .GetSection(EmailSettings)
            .GetSection(param).Value;
    }
}
