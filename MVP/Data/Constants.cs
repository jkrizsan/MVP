namespace Data
{
    /// <summary>
    /// Collects of the most common strings
    /// </summary>
    public class Constants
    {
        public const string TimeFormat = "yyyy-MM-dd HH:mm:ss";

        public const char At = '@';

        public const string EmailError = "Email sending is failed!";

        public const string EmailAddressError = "Email Address is invalid!";

        public const string InvalidInvoiceFormat = "Invoice format is invalid!";

        public const string MissingProduct = "Please give one or more products!";

        public const string JsonSerializeError = "JSON Serialize error happened!";

        public const string UnsupportedProduct = "The '{0}' product does not supported!";

        public const string UnsupportedCountry = "The '{0}' country does not supported!";

        public const string NullreferenceException = "The '{0}' is null!";

        public const string InvalidDate = "The '{0}' value is invalid!";

        public const string MustBePositive = "The '{0}' must be 0 or greater!";

        public const string MustBeAtLeastOne = "The '{0}' must be at least 1!";

        public const string TimelineValidation = "The '{0}' value must be lower then '{1}' value!";

        public static string GetString(string format, string param1)
        {
            return string.Format(format, param1);
        }

        public static string GetString(string format, string param1, string param2)
        {
            return string.Format(format, param1, param2);
        }
    }
}
