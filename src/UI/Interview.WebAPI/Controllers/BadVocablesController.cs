using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.UseCases.BadVocables.Commands.CreateBadVocable;
using Interview.Application.UseCases.BadVocables.Queries.GetBadVocables;
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

        [HttpGet]
        public async Task<IActionResult> BadVocables([FromQuery] GetBadVocablesQuery query)
        {
            ListResponse<string> singleResponse = await Mediator.Send(query);
            return singleResponse.ToHttpResponse();
        }
    }
}
