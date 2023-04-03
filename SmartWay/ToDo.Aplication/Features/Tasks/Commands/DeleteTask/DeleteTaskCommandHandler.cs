using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ToDo.Application.Contracts.Persistence;
using ToDo.Application.Exceptions;

namespace ToDo.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteTaskCommandHandler> _logger;

        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteTaskCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToDelete = await _unitOfWork.TaskRepository.GetByIdAsync(request.Id);

            if (taskToDelete == null)
            {
                _logger.LogError($"{request.Id} task no existe en el sistema");
                throw new NotFoundException(nameof(Domain.Task), request.Id);
            }

            await _unitOfWork.TaskRepository.DeleteAsync(taskToDelete);
            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.Id} task fue eliminado con exito");

            return Unit.Value;
        }
    }
}
