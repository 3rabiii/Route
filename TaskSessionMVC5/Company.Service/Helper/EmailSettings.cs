using System.Net;
using System.Net.Mail;

namespace Company.Service.Helper
{
    public static class EmailSettings
    {
        public static void SendEmail(Email input)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("youssefelsherbiny73@gmail.com", "czpojtuxxvirtshg"); // this is services instead of adding your acual password

            client.Send("youssefelsherbiny73@gmail.com", input.To, input.Subject, input.Body);
        }

    }
}
