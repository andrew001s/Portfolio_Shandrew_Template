using ShandrewPage.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
namespace ShandrewPage.Conections
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration) { 
            _configuration = configuration;
        }

        public void SendEmail(Email email)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:Username").Value));
            message.To.Add(MailboxAddress.Parse(email.EmailAddress));
            message.Subject = email.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = email.Message
            };
            using var smtp = new SmtpClient();
            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
                );
            smtp.Authenticate(_configuration.GetSection("Email:Username").Value, _configuration.GetSection("Email:Password").Value);
            smtp.Send(message);
            smtp.Disconnect(true);
        }

    
    }
   
}
