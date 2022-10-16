using MVP.Data.Models;
using MVP.Services.Factories;
using System;
using System.Net.Mail;

namespace MVP.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailDataFactory _emailDataFactory;

        public EmailService(IEmailDataFactory emailDataFactory)
        {
            _emailDataFactory = emailDataFactory;
        }

        /// <inheritdoc />
        public bool SendMail(string message, string target)
        {
            try
            {
                EmailData emailData = _emailDataFactory.Create();

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(emailData.From);
                mail.To.Add(target);
                mail.Subject = emailData.Subject;
                mail.Body = message;

                SmtpClient SmtpClient = new SmtpClient(emailData.Server);
                SmtpClient.Port = Convert.ToInt32(emailData.Port);
                SmtpClient.Credentials = new System.Net.NetworkCredential(emailData.User, emailData.Password);
                SmtpClient.EnableSsl = true;

                SmtpClient.Send(mail);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
