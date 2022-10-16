namespace MVP.Services
{
    /// <summary>
    /// Interface for Email Service
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="message">Message of the Mail</param>
        /// <param name="target">Email Address</param>
        /// <returns></returns>
        bool SendMail(string message, string target);
    }
}
