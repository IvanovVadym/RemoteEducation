using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User: AuditableEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
