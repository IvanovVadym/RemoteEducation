using Domain.Common;

namespace Domain.Entities
{
    public class Teacher : AuditableEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
