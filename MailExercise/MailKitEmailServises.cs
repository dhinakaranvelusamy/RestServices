//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MailExercise;
//using MailKit.Net.Smtp;
//using MailKit.Security;
//using MimeKit;

//namespace MailExercise
//{
//    public class MailKitEmailServises: 
//    {
//        public  void SendEmail(string fromaddress, string toaddress, string subject, string content, string gmailAppPassword)
//        {
//            try
//            {
//                // Create a new MimeMessage
//                var message = new MimeMessage();
//                message.From.Add(new MailboxAddress("", FromAddress));
//                message.To.Add(new MailboxAddress("", Toaddress));
//                message.Subject = Subject;
//                message.Body = new TextPart("plain")
//                { Text = Content };
              

//                // Connect and send the email
//                using (var client = new SmtpClient())
//                {
//                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
//                    client.Authenticate(FromAddress, GmailAppPassword);
//                    client.Send(message);
//                    client.Disconnect(true);
//                }

//                Console.WriteLine("Email sent successfully!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred while sending the email: {ex.Message}");
//            }
//        }



//    }
//}
