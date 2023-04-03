using AutoFixture;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Application.UnitTests.Mocks
{
    public static class MockTaskRepository
    {
        public static void AddDataTaskRepository(ToDoDbContext toDoDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var tasks = fixture.CreateMany<Domain.Task>().ToList();

            tasks.Add(fixture.Build<Domain.Task>()
                .With(tr => tr.Id, 1)
                .With(tr => tr.Description)
                .With(tr => tr.Status,false)
                .Create());

            tasks.Add(fixture.Build<Domain.Task>()
                .With(tr => tr.Id, 2)
                .With(tr => tr.Description)
                .With(tr => tr.Status, true)
                .Create());

            toDoDbContextFake.Tasks!.AddRange(tasks);
            toDoDbContextFake.SaveChanges();
        }
    }
}
