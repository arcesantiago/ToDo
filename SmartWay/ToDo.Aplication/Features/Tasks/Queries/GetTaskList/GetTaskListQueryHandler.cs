using AutoMapper;
using MediatR;
using ToDo.Application.Contracts.Persistence;

namespace ToDo.Application.Features.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, List<TaskVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TaskVm>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var taskList = await _unitOfWork.TaskRepository.GetAllAsync();

            return _mapper.Map<List<TaskVm>>(taskList);
        }
    
    }
}
