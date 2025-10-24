using System.Net;
using System.Net.Mail;

namespace MailExercise
{
    public class SentEmailToAddress
    {
        public void SendEmail(string fromAddress, string toAddress, string subject, string content, string gmailAppPassword)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromAddress);
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.Body = content;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(fromAddress, gmailAppPassword);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;

                    smtp.Send(mail);
                }
            }
        }
    }
}
