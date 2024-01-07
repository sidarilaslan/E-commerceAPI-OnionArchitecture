using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.Application.Middlewares.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            switch (exception)
            {
                case ValidationErrorException validationErrorException:
                    return CreateValidationErrorException(context, validationErrorException);

                case BusinessException businessException:
                    return CreateBusinessException(context, businessException);

                case NotFoundException notFoundException:
                    return CreateNotFoundException(context, notFoundException);

                case AuthorizationException authorizationException:
                    return CreateAuthorizationException(context, authorizationException);

                case ValidationErrorsException validationErrorsException:
                    return CreateValidationErrorsException(context, validationErrorsException);

                default:
                    return CreateInternalException(context, exception);
            }
        }

        private async Task CreateValidationErrorsException(HttpContext context, ValidationErrorsException exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsync(new ValidationErrorsProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation Errors Exception",
                Detail = exception.Message,
                Instance = context.Request.Path,
                Errors = exception.ValidationErrors
            }.ToString());

        }

        private async Task CreateValidationErrorException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsync(new ProblemDetailsResponseBase()
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation Error Exception",
                Detail = exception.Message,
                Instance = context.Request.Path
            }.ToString());
        }

        private async Task CreateAuthorizationException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            await context.Response.WriteAsync(new ProblemDetailsResponseBase()
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Authorization Exception",
                Detail = exception.Message,
                Instance = context.Request.Path
            }.ToString());

        }

        private async Task CreateInternalException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsync(new ProblemDetailsResponseBase()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Exception",
                Detail = exception.Message,
                Instance = context.Request.Path,
                InnerException = exception.ToString()
            }.ToString());
        }

        private async Task CreateNotFoundException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            await context.Response.WriteAsync(new ProblemDetailsResponseBase()
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Not Found Exception",
                Detail = exception.Message,
                Instance = context.Request.Path
            }.ToString());


        }

        private async Task CreateBusinessException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsync(new ProblemDetailsResponseBase()
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Business Exception",
                Detail = exception.Message,
                Instance = context.Request.Path
            }.ToString());
        }


    }
}
