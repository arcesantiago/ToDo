using AutoMapper;
using ToDo.Application.Features.Tasks.Commands.CreateTask;
using ToDo.Application.Features.Tasks.Commands.UpdateTask;
using ToDo.Application.Features.Tasks.Queries.GetTaskList;

namespace ToDo.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Task, TaskVm>();
            CreateMap<CreateTaskCommand, Domain.Task>();
            CreateMap<UpdateTaskCommand, Domain.Task>();
            CreateMap<CreateTaskCommand, Domain.Task>();
        }
    }
}
