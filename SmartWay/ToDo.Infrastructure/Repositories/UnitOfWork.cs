using ToDo.Application.Contracts.Persistence;
using ToDo.Domain.Common;
using ToDo.Infrastructure.Persistence;
using System.Collections;

namespace ToDo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly ToDoDbContext _context;

        private ITaskRepository _taskRepository;
        public ITaskRepository TaskRepository => _taskRepository ??= new TaskRepository(_context);
        public UnitOfWork(ToDoDbContext context)
        {
            _context = context;
        }

        public ToDoDbContext ToDoDbContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if(_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
                _repositories.Add(type, repositoryInstance);
               
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
