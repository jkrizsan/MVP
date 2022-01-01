namespace MVP.Services
{
    public interface IEmailService
    {
        bool SendMail(string message, string target);
    }
}
