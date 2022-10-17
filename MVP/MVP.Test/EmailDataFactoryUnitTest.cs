using Microsoft.Extensions.Configuration;
using MVP.Data.Models;
using MVP.Services.Factories;
using NUnit.Framework;
using System.Collections.Generic;

namespace MVP.Test
{
    public class EmailDataFactoryUnitTest
    {
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string> 
            {
                {EmailData.EmailSettings, nameof(EmailData.EmailSettings)},
                {$"{EmailData.EmailSettings}:{nameof(EmailData.Server)}", nameof(EmailData.Server)},
                {$"{EmailData.EmailSettings}:{nameof(EmailData.Port)}", nameof(EmailData.Port)},
                {$"{EmailData.EmailSettings}:{nameof(EmailData.From)}", nameof(EmailData.From)},
                {$"{EmailData.EmailSettings}:{nameof(EmailData.Subject)}", nameof(EmailData.Subject)},
                {$"{EmailData.EmailSettings}:{nameof(EmailData.User)}", nameof(EmailData.User)},
                {$"{EmailData.EmailSettings}:{nameof(EmailData.Password)}", nameof(EmailData.Password)},
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        [Test]
        public void Create_OK()
        {
            EmailFactory emailDataFactory = new EmailFactory(_configuration);

            EmailData result = emailDataFactory.CreateEmailData();

            Assert.AreEqual($"{nameof(EmailData.Server)}", result.Server);
            Assert.AreEqual($"{nameof(EmailData.Port)}", result.Port);
            Assert.AreEqual($"{nameof(EmailData.From)}", result.From);
            Assert.AreEqual($"{nameof(EmailData.Subject)}", result.Subject);
            Assert.AreEqual($"{nameof(EmailData.User)}", result.User);
            Assert.AreEqual($"{nameof(EmailData.Password)}", result.Password);
        }
    }
}
