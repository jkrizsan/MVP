using MVP.Data.DTOs;

namespace MVP.Services
{
    public interface IInvoiceService
    {
        string CreateInvoice(InvoiceResponseDto responseDto);

        InvoiceResponseDto CheckAndParseInvoice(InvoiceRequestDto requestDto);
    }
}
