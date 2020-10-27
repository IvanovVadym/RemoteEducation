namespace Domain.Common
{
    public class Group : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        //public IList<Student> Students { get; private set; } = new List<Student>();
    }
}
