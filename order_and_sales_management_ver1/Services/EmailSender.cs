using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Net.Mail;
using Humanizer;

namespace order_and_sales_management_ver1.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            /*
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("gulseven@gulseven.com.tr", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
                        return client.SendEmailAsync(msg);

            */
            SmtpClient SmtpServer = new SmtpClient("hakan@gulseven.com.tr");
            SmtpServer.Port = 587;
            SmtpServer.Credentials =
            new System.Net.NetworkCredential("hakan@gulseven.com.tr", "ZXCvbn123");
            SmtpServer.Host = "mail.gulseven.com.tr";
            MailMessage msg = new MailMessage()
            {
                Subject = subject,
                From = new MailAddress("gulseven@gulseven.com.tr"),
                Body = message,
                IsBodyHtml = true
            };
            msg.To.Add(new MailAddress(email));
            var retval=SmtpServer.SendMailAsync(msg);
            return retval;
        }
    }
}
