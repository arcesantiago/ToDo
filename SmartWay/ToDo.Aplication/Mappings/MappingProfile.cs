using AutoMapper;
using ToDo.Application.Features.Tasks.Queries.GetTaskList;

namespace ToDo.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Task, TaskVm>();
        }
    }
}
