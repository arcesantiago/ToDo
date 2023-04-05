using MediatR;

namespace ToDo.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public int _Id { get; set; }

        public UpdateTaskCommand(int id)
        {
            _Id = id;
        }
    }
}
