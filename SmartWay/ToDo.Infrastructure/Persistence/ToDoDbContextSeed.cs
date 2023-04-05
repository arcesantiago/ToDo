using Microsoft.Extensions.Logging;

namespace ToDo.Infrastructure.Persistence
{
    public class ToDoDbContextSeed
    {
        public static async Task SeedAsync(ToDoDbContext context, ILogger<ToDoDbContextSeed> logger)
        {
            if (!context.Tasks!.Any())
            {
                context.Tasks!.AddRange(GetPreconfiguredToDo());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(ToDoDbContext).Name);
            }
        }

        private static IEnumerable<Domain.Task> GetPreconfiguredToDo()
        {
            return new List<Domain.Task>
            {
                new Domain.Task{CreatedBy = "santiagoarce", Description = "Crear modelo", Status = "pending"},
                new Domain.Task{CreatedBy = "santiagoarce", Description = "Crear repositorio", Status = "completed"}
            };
        }
    }
}
