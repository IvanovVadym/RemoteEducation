using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Role: AuditableEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
