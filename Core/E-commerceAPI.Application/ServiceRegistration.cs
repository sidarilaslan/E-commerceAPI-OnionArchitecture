using E_commerceAPI.Application.Behaviors;
using E_commerceAPI.Application.Features.Products.ValidationRules;
using E_commerceAPI.Application.Features.Users.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_commerceAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddScoped<UserBusinessRules>();
            services.AddValidatorsFromAssemblyContaining(typeof(CreateProductValidator));
        }
    }
}
