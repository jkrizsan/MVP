using Services.Exceptions;
using Services.DataModels;
using Services.Factories;
using System.Net.Mail;
using Data;

namespace Services
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
               throw new EmailException(Constants.EmailError);
            }
        }
    }
}
