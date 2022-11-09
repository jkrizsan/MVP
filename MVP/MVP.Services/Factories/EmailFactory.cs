using Microsoft.Extensions.Configuration;
using MVP.Services.DataModels;
using System;
using System.Net.Mail;

namespace MVP.Services.Factories
{
    /// <summary>
    /// Email Data Factory
    /// </summary>
    public class EmailFactory : IEmailFactory
    {
        private readonly IConfiguration _configuration;

        public EmailFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public EmailData CreateEmailData()
        {
            EmailData emailData = new EmailData();

            _configuration
                .GetSection(EmailData.EmailSettings)
                .Bind(emailData);

            return emailData;
        }

        /// <inheritdoc />
        public MailMessage CreateMailMessage(EmailData emailData, string target, string message)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(emailData.From);
            mail.To.Add(target);
            mail.Subject = emailData.Subject;
            mail.Body = message;

            return mail;
        }

        /// <inheritdoc />
        public SmtpClient CreateSmtpClient(EmailData emailData)
        {
            SmtpClient SmtpClient = new SmtpClient(emailData.Server);

            SmtpClient.Port = Convert.ToInt32(emailData.Port);
            SmtpClient.Credentials = new System.Net.NetworkCredential(emailData.User, emailData.Password);
            SmtpClient.EnableSsl = true;

            return SmtpClient;
        }
    }
}
