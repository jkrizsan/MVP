using Newtonsoft.Json;
using System;

namespace MVP.API.Helpers
{
    public class InvoiceCreatorHelper : IInvoiceCreatorHelper
    {
        public string CreateInvoice(InvoiceResponseDto responseDto)
        {
            switch(responseDto.InvoiceFormat)
            {
                case InvoiceFormat.JSON:
                    return BuildJSONInvoice(responseDto);
                case InvoiceFormat.HTML:
                    return BuildHTMLInvoice(responseDto);
                default:
                    return "Error: Unexpected invoice format!";
            }
        }

        private string BuildHTMLInvoice(InvoiceResponseDto responseDto)
        {
            string result = @$"<!DOCTYPE html>{Environment.NewLine}";
            result += @$"<html>{Environment.NewLine}";
            result += @$"<body>{Environment.NewLine}";

            result += @$"<table border=1>{Environment.NewLine}";
            result += @$"<thead>{Environment.NewLine}";
            result += @$"<tr>{Environment.NewLine}";
            result += @$"<th>Product Name</th>{Environment.NewLine}";
            result += @$"<th>Product Price</th>{Environment.NewLine}";
            result += @$"<th>Product Tax</th>{Environment.NewLine}";
            result += @$"</tr>{Environment.NewLine}";
            result += @$"</thead>{Environment.NewLine}";
            result += @$"<tbody>{Environment.NewLine}";
            foreach (var item in responseDto.ProductPricess)
            {
                result += @$"<tr>{Environment.NewLine}";
                result += @$"<td>{item.Name}</td>{Environment.NewLine}";
                result += @$"<td>{item.Price}</td>{Environment.NewLine}";
                result += @$"<td>{item.Tax}</td>{Environment.NewLine}";
                result += @$"</tr>{Environment.NewLine}";
            }
            result += @$"</tbody>{Environment.NewLine}";
            result += @$"</table>{Environment.NewLine}";

            result += @$"<table border=1>{Environment.NewLine}";
            result += @$"<thead>{Environment.NewLine}";
            result += @$"<tr>{Environment.NewLine}";       
            result += @$"<th>{nameof(responseDto.Country)}</th>{Environment.NewLine}";
            result += @$"<th>{nameof(responseDto.Country.Tax)}</th>{Environment.NewLine}";
            result += @$"<th>{nameof(responseDto.EmailAddress)}</th>{Environment.NewLine}";
            result += @$"<th>{nameof(responseDto.TotalPrices)}</th>{Environment.NewLine}";
            result += @$"<th>{nameof(responseDto.TotalTaxes)}</th>{Environment.NewLine}";
            result += @$"</tr>{Environment.NewLine}";
            result += @$"</thead>{Environment.NewLine}";
            result += @$"</tbody>{Environment.NewLine}";
            result += @$"<tr>{Environment.NewLine}";
            result += @$"<td>{responseDto.Country.Name}</td>{Environment.NewLine}";
            result += @$"<td>{responseDto.Country.Tax}</td>{Environment.NewLine}";
            result += @$"<td>{responseDto.EmailAddress}</td>{Environment.NewLine}";
            result += @$"<td>{responseDto.TotalPrices}</td>{Environment.NewLine}";
            result += @$"<td>{responseDto.TotalTaxes}</td>{Environment.NewLine}";
            result += @$"</tr>{Environment.NewLine}";
            result += @$"</tbody>{Environment.NewLine}";
            result += @$"</table>{Environment.NewLine}";

            result += @$"</tbody>{Environment.NewLine}";
            result += @$"</body>{Environment.NewLine}";
            result += @$"</html>{Environment.NewLine}";
            
            return result;
        }

        private string BuildJSONInvoice(InvoiceResponseDto responseDto)
        {
            string result = "";

            try
            {
                result = JsonConvert.SerializeObject(responseDto);
            }
            catch (Exception e)
            {
                result = $"JSON format exception: {e.Message}";
            }

            return result;
        }
    }
}
