namespace StarTech.Application.Common.Mailing
{
    public class MailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //public string? From { get; }
        //public string? DisplayName { get; }
        //public string UserName { get; set; }
        //public string TemporaryPassword { get; set; }

    }

  
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
