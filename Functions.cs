using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using WebJob.Entities;
using Microsoft.Azure.WebJobs;

namespace WebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("queue")] ActionDescription jsonMessage, TextWriter log)
        {
            Console.WriteLine(jsonMessage.Email);

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(jsonMessage.Email));
            ServerMailSettings serverMail = new ServerMailSettings { Mail = "davidcondrea@gmail.com", Subject = "test mail subject", Body="Battery level low", Password = "***"};
            mail.From = new MailAddress(serverMail.Mail);
            mail.Subject = serverMail.Subject;
            mail.Body = serverMail.Body;

            client.Credentials = new System.Net.NetworkCredential(serverMail.Mail, serverMail.Password);
            client.Send(mail);
        }
    }
}
