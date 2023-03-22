using AutoMapper;
using Moq;
using Shouldly;
using ToDo.Application.Features.Tasks.Queries.GetTaskList;
using ToDo.Application.Mappings;
using ToDo.Application.UnitTests.Mocks;
using ToDo.Infrastructure.Repositories;
using Xunit;

namespace ToDo.Application.UnitTests.Features.Tasks.Queries
{
    public class GetTaskListQueryHandlerXUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetTaskListQueryHandlerXUnitTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();

            MockTaskRepository.AddDataTaskRepository(_unitOfWork.Object.ToDoDbContext);
        }
        [Fact]
        public async Task GetVideoListTest()
        {
            var handler = new GetTaskListQueryHandler(_unitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetTaskListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<TaskVm>>();

            result.Count.ShouldBe(5);
        }
    }
}
