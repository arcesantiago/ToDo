using ToDo.Application.Contracts.Persistence;
using ToDo.Infrastructure.Persistence;
using ToDo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToDoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
