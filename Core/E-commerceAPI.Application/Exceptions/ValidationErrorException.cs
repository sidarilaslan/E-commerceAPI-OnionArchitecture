using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.Application.Middlewares.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException()
        {
        }

        public ValidationErrorException(string? message) : base(message)
        {
        }

        public ValidationErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
