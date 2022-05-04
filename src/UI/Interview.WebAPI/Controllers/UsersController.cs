using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.UseCases.Users.Commands.CreateUser;
using Interview.Application.UseCases.Users.Queries.GetUsersWithPagination;
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUsersWithPaginationQuery query)
        {
            PagedResponse<GetUsersWithPaginationQueryResponse> pagedResponse = await Mediator.Send(query);
            return pagedResponse.ToHttpResponse();
        }
    }
}
