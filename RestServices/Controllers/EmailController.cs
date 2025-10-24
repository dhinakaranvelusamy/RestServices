using Microsoft.AspNetCore.Mvc;
using System;
using MailExercise;

namespace RestServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // POST api/email
        [HttpPost]
        public IActionResult Post([FromBody] EmailModel sendEmail) 
        {
            try
            {
                var emailSender = new SentEmailToAddress();
                emailSender.SendEmail(
                    sendEmail.FromAddress,
                    sendEmail.ToAddress,
                    sendEmail.Subject,
                    sendEmail.Content,
                    sendEmail.GmailAppPassword
                );

                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
