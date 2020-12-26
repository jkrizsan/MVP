namespace MVP.API.Helpers
{
    public interface IEmailHelper
    {
        bool SendMail(string message, string target);
    }
}
