using FluentValidation.Results;
using Interview.Application.Commons.Dtos.Concretes.Response;

namespace Interview.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public Response Response { get; }

        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Response = new Response();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            failures.ToList().ForEach(c => Response.ErrorMessages.Add(c.ErrorMessage)); 
        }
    }
}
