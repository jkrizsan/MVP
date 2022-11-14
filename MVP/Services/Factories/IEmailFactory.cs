using Services.DataModels;
using System.Net.Mail;

namespace Services.Factories
{
    /// <summary>
    /// Interface for Email Factory
    /// </summary>
    public interface IEmailFactory
    {
        /// <summary>
        /// Create an EmailData instance based on the configuration 
        /// </summary>
        /// <returns></returns>
        EmailData CreateEmailData();

        /// <summary>
        /// Create a MailMessage instance
        /// </summary>
        /// <param name="emailData"></param>
        /// <param name="target"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        MailMessage CreateMailMessage(EmailData emailData, string target, string message);

        /// <summary>
        /// Create a SmtpClient instance
        /// </summary>
        /// <param name="emailData"></param>
        /// <returns></returns>
        SmtpClient CreateSmtpClient(EmailData emailData);
    }
}
