using MediatR;

namespace ToDo.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
