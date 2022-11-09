using System;

namespace MVP.Services.Exceptions
{
    /// <summary>
    /// Validation Exception
    /// </summary>
    public class ValidationException : Exception
    {
        public ValidationException(string message)
        {
            ErrorMessage = message;
        }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage;
    }
}
