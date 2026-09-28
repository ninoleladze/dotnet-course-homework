using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace _06._17._26_DI
{

    public class EmailSender
    {
        // @to - არის მიმღები წერილის
        // @subject - არის წერილის თემატიკა
        // @body - არის უშუალოდ წერილის შიგთავსი
        public void SendEmail(string to, string subject, string body)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential("ninoleladze447@gmail.com", "YOUR_GMAIL_APP_PASSWORD");

            MailMessage mail = new MailMessage();

            mail.IsBodyHtml = true;
            mail.From = new MailAddress("ninoleladze447@gmail.com");
            mail.Subject = subject;
            mail.Body = body;

            // Mimghebi
            mail.To.Add(to);

            smtp.Send(mail);
        }
    }
}