using _06._22._26_DI_1.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace _06._22._26_DI_1.Services
{
    public class EmailNotifier
    {
        private List<LogEntry> sentLogs = new List<LogEntry>();

        private void AddToLog(string to, string subject, string body)
        {
            sentLogs.Add(new LogEntry
            {
                Recipient = to,
                Subject = subject,
                BodySnippet = body.Length > 30 ? body.Substring(0, 30) + "..." : body,
                SentTime = DateTime.Now
            });
        }

        private void ExecuteSendEmail(string to, string subject, string body)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential("ninoleladze447@gmail.com", "YOUR_GMAIL_APP_PASSWORD");

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("ninoleladze447@gmail.com", "FIGHT NIGHT INFO");
                mail.Subject = subject;
                mail.Body = body;

                mail.To.Add(to);
                smtp.Send(mail);

                AddToLog(to, subject, body);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] Failed to send email to {to}: {ex.Message}");
                Console.ResetColor();
            }
        }

        public void SendNotification(string to)
        {
            string subject = "FIGHT NIGHT - STATUS: CONFIRMED";
            string body = @"
    <div style='background-color: #0a0a0a; padding: 40px 20px; font-family: ""Helvetica Neue"", Helvetica, Arial, sans-serif; color: #ffffff;'>
        <div style='max-width: 600px; margin: 0 auto; background: linear-gradient(145deg, #1a1a1a 0%, #000000 100%); border: 2px solid #e60000; border-radius: 10px; box-shadow: 0 0 20px rgba(230,0,0,0.4); text-align: center; overflow: hidden;'>
            <div style='background-color: #e60000; padding: 20px; letter-spacing: 3px;'>
                <h1 style='margin: 0; font-size: 28px; text-transform: uppercase; font-weight: 900; text-shadow: 2px 2px 4px #000;'>FIGHT NIGHT</h1>
            </div>
            <div style='padding: 40px 30px;'>
                <h2 style='color: #ffffff; font-size: 24px; margin-top: 0; text-transform: uppercase;'>Registration Confirmed</h2>
                <p style='color: #aaaaaa; font-size: 16px; line-height: 1.6;'>Your place in the arena is secured. Prepare yourself for the most brutal and electrifying event of the year.</p>
                <div style='margin: 30px 0; padding: 15px; background-color: #111111; border: 1px dashed #e60000; display: inline-block;'>
                    <span style='color: #e60000; font-weight: bold; font-size: 18px; letter-spacing: 2px;'>STANDARD ACCESS GRANTED</span>
                </div>
                <p style='color: #777777; font-size: 14px; text-transform: uppercase;'>Step into the shadows. We are waiting.</p>
            </div>
        </div>
    </div>";

            ExecuteSendEmail(to, subject, body);
        }

        public void SendNotification(string to, string customMessage)
        {
            string subject = "FIGHT NIGHT - INCOMING TRANSMISSION";
            string body = $@"
    <div style='background-color: #0f0f11; padding: 40px 20px; font-family: Arial, sans-serif; color: #e0e0e0;'>
        <div style='max-width: 600px; margin: 0 auto; border-left: 5px solid #00d2ff; background-color: #1a1a1d; padding: 30px; box-shadow: 5px 5px 15px rgba(0,0,0,0.5);'>
            <h2 style='color: #00d2ff; text-transform: uppercase; margin-top: 0; letter-spacing: 1px; font-size: 22px;'>Incoming Transmission</h2>
            <hr style='border: none; border-bottom: 1px solid #333333; margin-bottom: 20px;'>
            <p style='font-size: 16px; line-height: 1.5; color: #bbbbbb;'>Fighter,</p>
            <div style='background-color: #000000; padding: 25px; border-radius: 5px; border: 1px solid #222222; margin: 25px 0;'>
                <p style='margin: 0; font-size: 18px; color: #ffffff; font-style: italic; letter-spacing: 0.5px;'>""{customMessage}""</p>
            </div>
            <p style='font-size: 12px; color: #666666; margin-bottom: 0;'>SECURE CHANNEL // AUTOMATED SYSTEM</p>
        </div>
    </div>";

            ExecuteSendEmail(to, subject, body);
        }

        public void SendNotification(string[] emails)
        {
            string subject = "FIGHT NIGHT - URGENT OVERRIDE";
            string body = @"
    <div style='background-color: #111111; padding: 40px 20px; font-family: ""Trebuchet MS"", Arial, sans-serif;'>
        <div style='max-width: 600px; margin: 0 auto; background-color: #1a1a1a; border: 3px solid #ffcc00; text-align: center; box-shadow: 0 0 25px rgba(255,204,0,0.2);'>
            <div style='background-color: #ffcc00; padding: 15px;'>
                <h1 style='color: #000000; margin: 0; font-size: 24px; text-transform: uppercase; font-weight: 900;'>⚠️ URGENT UPDATE ⚠️</h1>
            </div>
            <div style='padding: 30px;'>
                <h2 style='color: #ffffff; margin-top: 0; letter-spacing: 1px;'>SCHEDULE OVERRIDE</h2>
                <p style='color: #cccccc; font-size: 16px; line-height: 1.6;'>Attention all fighters and spectators! Critical changes have been made to the event timeline.</p>
                <p style='color: #ffcc00; font-weight: bold; font-size: 18px; margin: 25px 0; text-decoration: underline;'>CHECK THE OFFICIAL PORTAL NOW</p>
                <p style='color: #777777; font-size: 14px; text-transform: uppercase;'>Do not miss your moment. Stay alert.</p>
            </div>
        </div>
    </div>";

            foreach (var email in emails)
            {
                ExecuteSendEmail(email, subject, body);
            }
        }

        public void SendNotification(string to, bool isVip)
        {
            string subject = isVip ? "FIGHT NIGHT - EXCLUSIVE VIP ACCESS" : "FIGHT NIGHT - STATUS: CONFIRMED";
            string body;

            if (isVip)
            {
                body = @"
        <div style='background-color: #000000; padding: 50px 20px; font-family: ""Georgia"", serif; text-align: center;'>
            <div style='max-width: 600px; margin: 0 auto; background: linear-gradient(45deg, #0a0a0a 0%, #1a1a1a 100%); border: 2px solid #d4af37; padding: 40px; border-radius: 3px; box-shadow: 0 0 30px rgba(212,175,55,0.15);'>
                <h1 style='color: #d4af37; font-size: 32px; font-weight: normal; letter-spacing: 4px; text-transform: uppercase; margin-top: 0;'>VIP Access</h1>
                <div style='height: 2px; background: linear-gradient(to right, #000, #d4af37, #000); margin: 20px 0;'></div>
                <p style='color: #ffffff; font-size: 18px; line-height: 1.8; font-family: Arial, sans-serif;'>Welcome to the inner circle.</p>
                <p style='color: #aaaaaa; font-size: 15px; line-height: 1.6; font-family: Arial, sans-serif; margin-bottom: 30px;'>Your presence is requested in the exclusive lounge. Premium catering, unparalleled views, and absolute luxury await you ringside.</p>
                <span style='display: inline-block; padding: 15px 30px; border: 1px solid #d4af37; color: #d4af37; font-family: Arial, sans-serif; font-size: 14px; letter-spacing: 2px; text-transform: uppercase;'>Present This Pass at the Velvet Rope</span>
            </div>
        </div>";
            }
            else
            {
                SendNotification(to);
                return;
            }

            ExecuteSendEmail(to, subject, body);
        }

        public void SendNotification(string to, DateTime eventTime)
        {
            TimeSpan timeRemaining = eventTime - DateTime.Now;
            string subject = "FIGHT NIGHT - SYSTEM COUNTDOWN";
            string body = $@"
    <div style='background-color: #050505; padding: 40px 20px; font-family: ""Courier New"", Courier, monospace; text-align: center;'>
        <div style='max-width: 600px; margin: 0 auto; background-color: #121212; border: 1px solid #333333; padding: 40px; border-radius: 15px; box-shadow: inset 0 0 50px rgba(0,0,0,0.8);'>
            <h2 style='color: #ffffff; text-transform: uppercase; letter-spacing: 2px; margin-top: 0;'>System Countdown</h2>
            <p style='color: #666666; font-family: Arial, sans-serif; font-size: 14px; text-transform: uppercase;'>Time until first blood:</p>
            <div style='background-color: #000000; border: 2px solid #ff003c; border-radius: 10px; padding: 20px; margin: 30px 0; box-shadow: 0 0 20px rgba(255,0,60,0.3);'>
                <span style='color: #ff003c; font-size: 40px; font-weight: bold; text-shadow: 0 0 10px rgba(255,0,60,0.5);'>{timeRemaining.Days}D : {timeRemaining.Hours:D2}H</span>
            </div>
            <p style='color: #aaaaaa; font-family: Arial, sans-serif; font-size: 16px;'>The cage is ready. Are you?</p>
        </div>
    </div>";

            ExecuteSendEmail(to, subject, body);
        }

      
        public void ShowSentLog()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Administrator Log (Sent Emails) ===");
            Console.ResetColor();

            if (sentLogs.Count == 0)
            {
                Console.WriteLine("The log is empty.");
                return;
            }

            foreach (var log in sentLogs)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{log.SentTime:HH:mm:ss}] ");
                Console.ResetColor();
                Console.WriteLine($"| To: {log.Recipient,-25} | Subj: {log.Subject}");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================\n");
            Console.ResetColor();
        }
    }
}