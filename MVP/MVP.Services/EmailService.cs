using MVP.Services.Exceptions;
using MVP.Services.DataModels;
using MVP.Services.Factories;
using System.Net.Mail;

namespace MVP.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailFactory _emailDataFactory;

        public EmailService(IEmailFactory emailDataFactory)
        {
            _emailDataFactory = emailDataFactory;
        }

        /// <inheritdoc />
        public void SendMail(string message, string target)
        {
            try
            {                
                EmailData emailData = _emailDataFactory.CreateEmailData();

                MailMessage mail = _emailDataFactory.CreateMailMessage(emailData, target, message);

                SmtpClient SmtpClient = _emailDataFactory.CreateSmtpClient(emailData);
                
                SmtpClient.Send(mail);
            }
            catch
            {
               throw new EmailException("Email sending is failed!");
            }
        }
    }
}
