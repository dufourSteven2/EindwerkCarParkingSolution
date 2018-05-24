using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            string apiKey = "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";
            return Execute(apiKey, subject, message, email);
        }
        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("benny.vanderschaeghe@gmail.com"),
           
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }

    }
}
