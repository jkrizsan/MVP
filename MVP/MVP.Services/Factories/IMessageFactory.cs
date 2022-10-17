﻿using MVP.Data.Models;
using MVP.Services.Abstractions;

namespace MVP.Services.Factories
{
    /// <summary>
    /// Interface of the MessageFactory
    /// </summary>
    public interface IMessageFactory
    {
        /// <summary>
        /// Create InvoiceMessage instance
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        InvoiceMessage Create(InvoiceResponse response);
    }
}
