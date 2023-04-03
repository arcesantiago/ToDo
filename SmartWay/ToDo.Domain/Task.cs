using ToDo.Domain.Common;

namespace ToDo.Domain
{
    public class Task : BaseDomainModel
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
