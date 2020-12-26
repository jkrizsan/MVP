namespace MVP.API.Helpers
{
    public interface IInvoiceDataHelper
    {
        InvoiceResponseDto CheckAndParseInvoice(InvoiceRequestDto requestDto);
    }
}
