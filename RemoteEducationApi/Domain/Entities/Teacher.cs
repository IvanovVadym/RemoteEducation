using Domain.Common;

namespace Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
