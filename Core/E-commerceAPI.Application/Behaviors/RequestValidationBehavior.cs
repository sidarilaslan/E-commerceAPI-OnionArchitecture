using E_commerceAPI.Application.Dtos;
using E_commerceAPI.Application.Middlewares.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace E_commerceAPI.Application.Behaviors
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationContext<object> context = new(request);
            List<ValidationFailure> failures = _validators
                                               .Select(validator => validator.Validate(context))
                                               .SelectMany(result => result.Errors)
                                               .Where(failure => failure != null)
                                               .ToList();

            if (failures.Count != 0)
            {
                var errorDetails = failures.Select(failure => new ValidationError
                {
                    PropertyName = failure.PropertyName,
                    ErrorMessage = failure.ErrorMessage,
                }).ToList();

                throw new ValidationErrorsException("Validation failed", errorDetails);
            }

            return await next();
        }

    }
}