using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Application.Abstractions.Token;
using E_commerceAPI.Infrastructure.Services;
using E_commerceAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerceAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IAppService, AppService>();
            services.AddScoped<IFileHelper, FileHelper>();


        }
    }
}
