using ToDo.Application.Contracts.Persistence;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Infrastructure.Repositories
{
    public class TaskRepository : RepositoryBase<Domain.Task>, ITaskRepository
    {
        public TaskRepository(ToDoDbContext context) : base(context)
        {
        }
    }
}
