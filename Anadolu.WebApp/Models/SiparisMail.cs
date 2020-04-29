using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Anadolu.WebApp.Models
{
    public class SiparisMail
    {

        public static void SendMail(string body)
        {
            var fromAddress = new MailAddress("azizvefa15@gmail.com", "Anadolu Toprak Sanayi");
            var toAddress = new MailAddress("azizvefa15@gmail.com");
            const string subject = "Anadolu Toprak Sanayi Siraiş";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "mahmutsami1")
                //trololol kısmı e-posta adresinin şifresi
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }


    }
}