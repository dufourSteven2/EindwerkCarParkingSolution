
namespace EindwerkCarParkingCore.Services
{
    public interface lMailService
    {
        void SendMessage(string to, string subject, string body);
        void SendMail(object p, string email, string v, string message);
    }
}