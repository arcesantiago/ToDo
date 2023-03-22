using ToDo.Domain.Common;

namespace ToDo.Domain
{
    public class Task : BaseDomainModel
    {
        public string? Description { get; set; }
        public bool IsDone { get; set; }
    }
}
