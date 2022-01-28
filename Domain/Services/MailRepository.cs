using ProjectOs.Domain.Interface;
using ProjectOs.Domain.Models;
using ProjectOs.Domain.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace ProjectOs.Domain.Services
{
    public class MailRepository : IMailRepository
    {
        private readonly MailSettings mailSetting;

        public MailRepository(IOptions<MailSettings> options)
        {
            mailSetting = options.Value;
        }

        public async Task SendEmailAsync(SendEmail sendEmail)
        {
            var email = new MimeMessage();

            email.Sender = MailboxAddress.Parse(mailSetting.Mail);
            email.To.Add(MailboxAddress.Parse(sendEmail.ToEmail));

            var builder = new BodyBuilder();

            builder.HtmlBody = sendEmail.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            smtp.Connect(mailSetting.Host, mailSetting.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSetting.Mail, mailSetting.Password);

            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
