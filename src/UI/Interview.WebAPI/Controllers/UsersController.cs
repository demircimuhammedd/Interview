using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.UseCases.Users.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Interview.WebAPI.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }
    }
}
