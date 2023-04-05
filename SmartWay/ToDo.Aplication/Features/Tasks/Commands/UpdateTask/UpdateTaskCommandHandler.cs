using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ToDo.Application.Contracts.Persistence;
using ToDo.Application.Exceptions;

namespace ToDo.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTaskCommandHandler> _logger;

        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateTaskCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToUpdate = await _unitOfWork.TaskRepository.GetByIdAsync(request._Id);

            if (taskToUpdate == null)
            {
                _logger.LogError($"No se encontro el task id {request._Id}");
                throw new NotFoundException(nameof(Domain.Task), request._Id);
            }

            //_mapper.Map(request, taskToUpdate, typeof(UpdateTaskCommand), typeof(Domain.Task));
            if(taskToUpdate.Status.ToLower() == "pending")
            taskToUpdate.Status = "completed";
            else taskToUpdate.Status = "pending";

            _unitOfWork.TaskRepository.UpdateEntity(taskToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el task {request._Id}");

            return Unit.Value;
        }
    }
}
