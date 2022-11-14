namespace Services.DataModels
{
    /// <summary>
    /// Email Data
    /// </summary>
    public class EmailData
    {
        /// <summary>
        /// Email Settings
        /// </summary>
        public const string EmailSettings = nameof(EmailSettings);

        /// <summary>
        /// Server
        /// </summary>
        public string Server { get; init; } = string.Empty;

        /// <summary>
        /// From
        /// </summary>
        public string From { get; init; } = string.Empty;

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; init; } = string.Empty;

        /// <summary>
        /// Port
        /// </summary>
        public string Port { get; init; } = string.Empty;

        /// <summary>
        /// User
        /// </summary>
        public string User { get; init; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; init; } = string.Empty;
    }
}
