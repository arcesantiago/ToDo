using ToDo.Infrastructure.Persistence;
using ToDo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ToDo.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<ToDoDbContext>()
                .UseInMemoryDatabase(databaseName: $"ToDoDbContext-{Guid.NewGuid()}")
                .Options;

            var toDoDbContextFake = new ToDoDbContext(options);

            toDoDbContextFake.Database.EnsureDeleted();

            var mockUnitOfWork = new Mock<UnitOfWork>(toDoDbContextFake);

            return mockUnitOfWork;
        }
    }
}
