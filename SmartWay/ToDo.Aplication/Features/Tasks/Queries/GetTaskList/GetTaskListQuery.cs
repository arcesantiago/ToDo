using MediatR;

namespace ToDo.Application.Features.Tasks.Queries.GetTaskList
{
    public class GetTaskListQuery : IRequest<List<TaskVm>>
    {
        public string _Status { get; set; } = string.Empty;

        public GetTaskListQuery(string status)
        {
            _Status = status;
        }
    }
}
