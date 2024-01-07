using E_commerceAPI.Application.Dtos;

namespace E_commerceAPI.Application.Middlewares.Exceptions
{
    public class ValidationErrorsProblemDetails : ProblemDetailsResponseBase
    {
        public List<ValidationError> Errors { get; set; }
    }
}
