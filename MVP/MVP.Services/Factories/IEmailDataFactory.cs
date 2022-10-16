using MVP.Data.Models;

namespace MVP.Services.Factories
{
    /// <summary>
    /// Interface for EmailData Factory
    /// </summary>
    public interface IEmailDataFactory
    {
        /// <summary>
        /// Create an EmailData instance based on the configuration 
        /// </summary>
        /// <returns></returns>
        EmailData Create();
    }
}
