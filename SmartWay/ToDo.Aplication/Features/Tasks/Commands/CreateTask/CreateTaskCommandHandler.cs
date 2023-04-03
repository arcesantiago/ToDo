using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ToDo.Application.Contracts.Persistence;

namespace ToDo.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTaskCommandHandler> _logger;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateTaskCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskEntity = _mapper.Map<Domain.Task>(request);

            _unitOfWork.TaskRepository.AddEntity(taskEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de task");
            }

            _logger.LogInformation($"Task {taskEntity.Id} fue creado exitosamente");

            return taskEntity.Id;
        }
    }
}
