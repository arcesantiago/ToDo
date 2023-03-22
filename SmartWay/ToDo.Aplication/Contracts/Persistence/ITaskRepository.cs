namespace ToDo.Application.Contracts.Persistence
{
    public interface ITaskRepository : IAsyncRepository<Domain.Task>
    {
    }
}
