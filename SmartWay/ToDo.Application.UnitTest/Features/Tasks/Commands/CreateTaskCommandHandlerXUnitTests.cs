using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using ToDo.Application.Features.Tasks.Commands.CreateTask;
using ToDo.Application.Mappings;
using ToDo.Application.UnitTests.Mocks;
using ToDo.Infrastructure.Repositories;
using Xunit;

namespace ToDo.Application.UnitTests.Features.Tasks.Commands
{
    public class CreateTaskCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateTaskCommandHandler>> _logger;

        public CreateTaskCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<CreateTaskCommandHandler>>();

            MockTaskRepository.AddDataTaskRepository(_unitOfWork.Object.ToDoDbContext);
        }

        [Fact]
        public async Task CreateTaskCommand_InputTask_ReturnsNumber()
        {
            var TaskInput = new CreateTaskCommand()
            {
                Title = "Test task 1 title",
                Description = "Test task 1 description"
            };
            var handler = new CreateTaskCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(TaskInput, CancellationToken.None);

            result.ShouldBeOfType<int>();
        }
    }
}
