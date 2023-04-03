using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using ToDo.Application.Features.Tasks.Commands.DeleteTask;
using ToDo.Application.Features.Tasks.Commands.UpdateTask;
using ToDo.Application.Mappings;
using ToDo.Application.UnitTests.Mocks;
using ToDo.Infrastructure.Repositories;
using Xunit;

namespace ToDo.Application.UnitTests.Features.Tasks.Commands
{
    public class UpdateTaskCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeleteTaskCommandHandler>> _logger;

        public UpdateTaskCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<DeleteTaskCommandHandler>>();

            MockTaskRepository.AddDataTaskRepository(_unitOfWork.Object.ToDoDbContext);
        }

        [Fact]
        public async Task DeleteTaskCommand_InputTaskById_ReturnsUnit()
        {
            var TaskInput = new DeleteTaskCommand()
            {
                Id = 1
            };
            var handler = new DeleteTaskCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(TaskInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
