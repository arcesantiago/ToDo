﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDo.Application.Features.Tasks.Commands.CreateTask;
using ToDo.Application.Features.Tasks.Commands.DeleteTask;
using ToDo.Application.Features.Tasks.Commands.UpdateTask;
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

        [HttpGet("{status}",Name = "GetTaskList")]
        [ProducesResponseType(typeof(IEnumerable<TaskVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TaskVm>>> GetTaskList(string status)
        {
            return await _mediator.Send(new GetTaskListQuery(status));
        }

        [HttpPost(Name = "CreateTask")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTask([FromBody] CreateTaskCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("{id}", Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTask(int id)
        {
            await _mediator.Send(new UpdateTaskCommand(id));

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _mediator.Send(new DeleteTaskCommand
            {
                Id = id
            });

            return NoContent();
        }
    }
}
