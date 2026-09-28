using System.Net;
using System.Net.Mail;

namespace SocialMedia.Common
{
    public class SmtpService
    {
        private readonly string _email = "gochazautashvili2017@gmail.com";
        private readonly string _password = "YOUR_GMAIL_APP_PASSWORD";

        public void SendEmail(string subject, string body, string email)
        {
            using var mail = new MailMessage();
            mail.From = new MailAddress(_email, "Social media");
            mail.Subject = subject;
            mail.To.Add(email);
            mail.Body = body;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(_email, _password),
            };

            smtpClient.SendMailAsync(mail);
        }
    }
}
