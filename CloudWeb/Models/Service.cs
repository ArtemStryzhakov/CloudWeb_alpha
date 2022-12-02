using System.Net.Mail;
using System.Net;
using System.Text;

namespace CloudWeb.Models
{
    public class Service
    {
        public async void SendEmailDefault(string Subject, string Body, string recipient, DateTime start, DateTime end, string productName, string productType)
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
            using (FileStream fs = File.Create("gmail.ics"))
            {
                byte[] text = new UTF8Encoding(true).GetBytes(CreateICS.CreateICSFile(start, end, "CloudWeb ostes",
                    $"Teie projekti nimi on {productName}, tüüp on {productType}."));
                fs.Write(text, 0, text.Length);
            }
            mailMessage.Attachments.Add(new Attachment("gmail.ics"));

            SmtpServer.Send(mailMessage);    
        }
    }
}