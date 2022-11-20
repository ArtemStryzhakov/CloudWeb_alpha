using System.Net.Mail;
using System.Net;

namespace CloudWeb.Models
{
    public class Service
    {
        public async void SendEmailDefault()
        {
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("irina1223148@outlook.com", "Моя компания");
                message.To.Add("irina1223148@outlook.com"); //адресат сообщения
                message.Subject = "Сообщение от System.Net.Mail"; //тема сообщения
                message.Body = "<div style=\"color: red;\">Сообщение для тупого тестирования</div>";
                //message.Attachments.Add(new Attachment("... путь к файлу ...")); 

                var client = new SmtpClient("smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("16285c1bbabdd1", "f9122b3e2925fd"),
                    EnableSsl = true
                };
                client.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}
