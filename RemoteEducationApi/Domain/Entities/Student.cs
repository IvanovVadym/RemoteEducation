using Domain.Common;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
