using System;

namespace MVP.Data.Exceptions
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
