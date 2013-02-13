using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace JB
{
    public class Clemail
    {
        public void Sendmailproc(string toaddr, string tosubject, string tobody, int typeofemail)
        {
            //checkcode
            try
            {
                string mailfrom = ConfigurationManager.AppSettings["emailfrom"];
                string mailserver = ConfigurationManager.AppSettings["emailserver"];
                string username = ConfigurationManager.AppSettings["eusername"];
                string password = ConfigurationManager.AppSettings["epassword"];
                short port = Convert.ToInt16(ConfigurationManager.AppSettings["eport"]);

                var message = new MailMessage();
                message.To.Add(toaddr);
                message.Subject = tosubject;
                message.From = new MailAddress(mailfrom);
                message.IsBodyHtml = true;
                message.Body = tobody;
                var smtp = new SmtpClient(mailserver, port) {Credentials = new NetworkCredential(username, password)};
                smtp.Send(message);
            }
            catch (Exception)
            {
                Console.Write("should not occur!");
            }
        }
    }
}