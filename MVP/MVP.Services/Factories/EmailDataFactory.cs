using Microsoft.Extensions.Configuration;
using MVP.Data.Models;

namespace MVP.Services.Factories
{
    /// <summary>
    /// EmailData Factory
    /// </summary>
    public class EmailDataFactory : IEmailDataFactory
    {
        private readonly IConfiguration _configuration;

        public EmailDataFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public EmailData Create()
        {
            EmailData emailData = new EmailData();

            _configuration
                .GetSection(EmailData.EmailSettings)
                .Bind(emailData);

            return emailData;
        }
    }
}
