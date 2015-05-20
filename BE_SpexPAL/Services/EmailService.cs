using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;


namespace BE_SpexPAL.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendAsync(message);
           
        }

        private async  Task configSendAsync(IdentityMessage message)
        {
            var myMessage = new MailMessage();
            myMessage.To.Add("sithelo@live.com");
            myMessage.From = new MailAddress("sithelo@gmail.com", "S Ngwenya");
            myMessage.Subject = "hi there";
            myMessage.Body = "I am good";
            myMessage.IsBodyHtml = true;
           
            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.SendMailAsync(myMessage);
            }
           
        }

       
    }
}