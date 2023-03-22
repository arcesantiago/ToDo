using MediatR;

namespace ToDo.Application.Features.Tasks.Queries.GetTaskList
{
    public class GetTaskListQuery : IRequest<List<TaskVm>>
    {
    }
}
