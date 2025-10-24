namespace MailExercise
{
    public class EmailModel
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string GmailAppPassword { get; set; }
    }
}
