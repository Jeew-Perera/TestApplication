namespace BusinessLayer
{
    public interface IEmailSender
    {
        void Send(string toAddress, string subject, string body, bool sendAsync = true);
    }
}
