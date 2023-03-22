using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDo.Application.Features.Tasks.Queries.GetTaskList;

namespace ToDo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTaskList")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<TaskVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TaskVm>>> GetTaskList()
        {
            return await _mediator.Send(new GetTaskListQuery());
        }
    }
}
