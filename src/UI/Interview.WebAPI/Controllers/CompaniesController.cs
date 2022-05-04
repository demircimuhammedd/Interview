using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.UseCases.Companies.Commands.JobIncrease;
using Microsoft.AspNetCore.Mvc;

namespace Interview.WebAPI.Controllers
{
    public class CompaniesController : ApiControllerBase
    {
        [HttpPost]
        [Route("job-increase", Name = nameof(JobIncrease))]
        public async Task<IActionResult> JobIncrease([FromBody] JobIncreaseCommand command)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }
    }
}
