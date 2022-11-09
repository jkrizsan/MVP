using MVP.Services.DataModels;
using System;
using System.Text;

namespace MVP.Services
{
    /// <summary>
    /// Html Invoice Builder Service class
    /// </summary>
    public class HtmlInvoiceBuilderService : IInvoiceBuilderService
    {
        /// <inheritdoc />
        public string Build(InvoiceResponse response)
        {
            StringBuilder invoice = new StringBuilder(1000);

            invoice.Append($@"<!DOCTYPE html>{Environment.NewLine}");
            invoice.Append($@"<html>{Environment.NewLine}");
            invoice.Append($@"<body>{Environment.NewLine}");

            invoice.Append($@"<table border=1>{Environment.NewLine}");
            invoice.Append($@"<thead>{Environment.NewLine}");
            invoice.Append($@"<tr>{Environment.NewLine}");
            invoice.Append($@"<th>Product Name</th>{Environment.NewLine}");
            invoice.Append($@"<th>Product Price</th>{Environment.NewLine}");
            invoice.Append($@"<th>Product Tax</th>{Environment.NewLine}");
            invoice.Append($@"</tr>{Environment.NewLine}");
            invoice.Append($@"</thead>{Environment.NewLine}");
            invoice.Append($@"<tbody>{Environment.NewLine}");

            foreach (var item in response.ProductPricess)
            {
                invoice.Append($@"<tr>{Environment.NewLine}");
                invoice.Append($@"<td>{item.Name}</td>{Environment.NewLine}");
                invoice.Append($@"<td>{item.Price}</td>{Environment.NewLine}");
                invoice.Append($@"<td>{item.Tax}</td>{Environment.NewLine}");
                invoice.Append($@"</tr>{Environment.NewLine}");
            }

            invoice.Append($@"</tbody>{Environment.NewLine}");
            invoice.Append($@"</table>{Environment.NewLine}");

            invoice.Append($@"<table border=1>{Environment.NewLine}");
            invoice.Append($@"<thead>{Environment.NewLine}");
            invoice.Append($@"<tr>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(response.Country)}</th>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(response.Country.Tax)}</th>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(response.EmailAddress)}</th>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(response.TotalPrices)}</th>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(response.TotalTaxes)}</th>{Environment.NewLine}");
            invoice.Append($@"</tr>{Environment.NewLine}");
            invoice.Append($@"</thead>{Environment.NewLine}");
            invoice.Append($@"</tbody>{Environment.NewLine}");
            invoice.Append($@"<tr>{Environment.NewLine}");
            invoice.Append($@"<td>{response.Country.Name}</td>{Environment.NewLine}");
            invoice.Append($@"<td>{response.Country.Tax}</td>{Environment.NewLine}");
            invoice.Append($@"<td>{response.EmailAddress}</td>{Environment.NewLine}");
            invoice.Append($@"<td>{response.TotalPrices}</td>{Environment.NewLine}");
            invoice.Append($@"<td>{response.TotalTaxes}</td>{Environment.NewLine}");
            invoice.Append($@"</tr>{Environment.NewLine}");
            invoice.Append($@"</tbody>{Environment.NewLine}");
            invoice.Append($@"</table>{Environment.NewLine}");

            invoice.Append($@"</tbody>{Environment.NewLine}");
            invoice.Append($@"</body>{Environment.NewLine}");
            invoice.Append($@"</html>{Environment.NewLine}");

            return invoice.ToString();
        }
    }
}
