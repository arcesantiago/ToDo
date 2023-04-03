using MediatR;

namespace ToDo.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public int Id { get; set; }
    }
}
