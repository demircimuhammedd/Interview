using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.UseCases.Users.Commands.BadVocable;
using Microsoft.AspNetCore.Mvc;

namespace Interview.WebAPI.Controllers
{
    public class BadVocablesController : ApiControllerBase
    {
        [HttpPost] 
        public async Task<IActionResult> CreateBadVocable([FromBody] CreateBadVocableCommand command)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }
    }
}
