using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Dtos;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace E_commerceAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        public readonly IConfiguration _configuration;
        private readonly MailOptions _mailOptions;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _mailOptions = _configuration.GetSection("Mail").Get<MailOptions>();

        }

        public async Task SendMailAsync(string to, string subject, string body)
        {

            using (SmtpClient smtpClient = new SmtpClient(_mailOptions.Host, _mailOptions.Port))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_mailOptions.Username, _mailOptions.Password);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage(_mailOptions.Username, to, subject, body))
                {
                    mailMessage.IsBodyHtml = true;
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }

        public async Task SendPasswordResetMailAsync(string to, string resetToken)
        {
            StringBuilder MessageBody = new StringBuilder();
            MessageBody.AppendLine("<a href=\"");
            MessageBody.Append(_configuration["Url:ClientUrl"]);
            MessageBody.AppendLine("/update-password/");
            MessageBody.AppendLine(resetToken);
            MessageBody.AppendLine("\">");
            MessageBody.AppendLine("Click here to renew your password</a>");

            await SendMailAsync(to, "Password Renewal Request", MessageBody.ToString());
        }
    }
}
