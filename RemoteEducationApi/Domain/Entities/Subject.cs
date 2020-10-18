using Domain.Common;

namespace Domain.Entities
{
    public class Subject : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
