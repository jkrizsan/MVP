using Data.Enums;

namespace Services.DataModels
{
    /// <summary>
    /// Data class for invoice history request
    /// </summary>
    public class HistoryRequest
    {
        /// <summary>
        /// Start date
        /// </summary>
        public string Start { get; init; }

        /// <summary>
        /// End date
        /// </summary>
        public string End { get; init; }

        /// <summary>
        /// Number of items that will be skipped
        /// </summary>
        public int Skip { get; init; } = 0;

        /// <summary>
        /// Number of items that will be took
        /// </summary>
        public int Take { get; init; } = 100;

        /// <summary>
        /// Invoice format
        /// </summary>
        public InvoiceFormat InvoiceFormat { get; init; } = InvoiceFormat.Unknown;
    }
}
