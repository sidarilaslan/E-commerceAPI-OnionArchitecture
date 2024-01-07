namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string body);
        Task SendPasswordResetMailAsync(string to, string resetToken);
    }
}
