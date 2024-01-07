using E_commerceAPI.Application.Dtos;

namespace E_commerceAPI.Application.Middlewares.Exceptions
{
    public class ValidationErrorsException : Exception
    {
        public List<ValidationError> ValidationErrors { get; set; }

        public ValidationErrorsException(string message, List<ValidationError> validationErrors) : base(message)
        {
            ValidationErrors = validationErrors;
        }

    }
}
