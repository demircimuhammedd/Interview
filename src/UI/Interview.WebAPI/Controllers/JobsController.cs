using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.UseCases.Jobs.Commands.CreateJob;
using Interview.Application.UseCases.Jobs.Queries.GetJobsWithPagination;
using Microsoft.AspNetCore.Mvc;

namespace Interview.WebAPI.Controllers
{
    public class JobsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobCommand command)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetJobsWithPaginationQuery query)
        {
            PagedResponse<GetJobsWithPaginationQueryResponse> pagedResponse = await Mediator.Send(query);
            return pagedResponse.ToHttpResponse();
        }
    }
}
