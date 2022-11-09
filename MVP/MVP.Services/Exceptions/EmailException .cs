using System;

namespace MVP.Services.Exceptions
{
    /// <summary>
    /// Email Exception
    /// </summary>
    public class EmailException : Exception
    {
        public EmailException(string message)
        {
            ErrorMessage = message;
        }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage;
    }
}
