using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
       
            throw new NotImplementedException();
        }

        private string BuildJSONInvoice(InvoiceResponseDto responseDto)
        {
            string result = JsonConvert.SerializeObject(responseDto);

            return result;
        }
    }
}
