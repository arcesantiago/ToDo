using ToDo.Domain.Common;

namespace ToDo.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();

        public ITaskRepository TaskRepository { get; }

    }
}
