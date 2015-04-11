using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Utility
{
    public class Emailer
    {
        public static bool SendMail(string smtpServer, string from, List<string> to, List<string> bcc, string subject, string content, List<string> attachments, bool isHtml)
        {
            if (string.IsNullOrEmpty(from))
            {
                throw new Exception("From email id not found");
            }
            if (to == null || to.Count == 0)
            {
                return false;
            }
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = subject;
            mailMessage.Body = content;
            mailMessage.From = new MailAddress(from);
            mailMessage.IsBodyHtml = isHtml;
            mailMessage.To.Add(GetCommaSeparatedAddress(to));
            if (bcc != null && bcc.Count > 0)
            {
                mailMessage.Bcc.Add(GetCommaSeparatedAddress(bcc));
            }
            if (attachments != null && attachments.Count > 0)
            {
                foreach (string current in attachments)
                {
                    Attachment item = new Attachment(current);
                    mailMessage.Attachments.Add(item);
                }
            }
            SmtpClient smtpClient = new SmtpClient(smtpServer); //mailhostservername
            smtpClient.Send(mailMessage);
            return true;
        }
        public static bool SendMail(string smtpServer, string from, List<string> to, List<string> bcc, string subject, string content, List<string> attachments)
        {
            return SendMail(smtpServer, from, to, bcc, subject, content, attachments, false);
        }

        private static string GetCommaSeparatedAddress(List<string> addresses)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (addresses != null && addresses.Count > 0)
            {
                foreach (string current in addresses)
                {
                    stringBuilder.Append(current);
                    stringBuilder.Append(",");
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            return stringBuilder.ToString();
        }
    }
}
