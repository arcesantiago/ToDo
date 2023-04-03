using MediatR;

namespace ToDo.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
