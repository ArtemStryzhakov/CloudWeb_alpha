using System.Net.Mail;
using System.Net;

namespace CloudWeb.Models
{
    public class Service
    {
        public async void SendEmailDefault(string Subject, string Body, string recipient)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
            var mailMessage = new MailMessage()
            {
                From = new MailAddress("testamogus123@hotmail.com"),
                Subject = Subject,
                Body = Body,
                IsBodyHtml = true
            };
            mailMessage.Body = Body;
            mailMessage.To.Add(recipient);
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.EnableSsl = true;
            SmtpServer.Credentials = new NetworkCredential("testamogus123@hotmail.com", "AmogusGaming228");
            SmtpServer.Send(mailMessage);
        }
    }
}
