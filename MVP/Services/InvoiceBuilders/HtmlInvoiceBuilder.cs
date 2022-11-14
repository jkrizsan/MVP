using Services.DataModels;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Services.InvoiceBuilders
{
    /// <summary>
    /// Html Invoice Builder
    /// </summary>
    public class HtmlInvoiceBuilder : IInvoiceBuilder
    {
        /// <inheritdoc />
        public async Task<string> BuildAsync(InvoiceResponse response)
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

            await AddProductPricesAsync(invoice, response);

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

            return await Task.Run(() => invoice.ToString());
        }

        private async Task AddProductPricesAsync(StringBuilder invoice, InvoiceResponse response)
        {
            foreach (var productPrice in response.ProductPricess)
            {
                invoice.Append($@"<tr>{Environment.NewLine}");
                invoice.Append($@"<td>{productPrice.Name}</td>{Environment.NewLine}");
                invoice.Append($@"<td>{productPrice.Price}</td>{Environment.NewLine}");
                invoice.Append($@"<td>{productPrice.Tax}</td>{Environment.NewLine}");
                invoice.Append($@"</tr>{Environment.NewLine}");
            }
        }
    }
}
