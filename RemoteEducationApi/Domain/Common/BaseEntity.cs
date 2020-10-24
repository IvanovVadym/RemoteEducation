using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public class BaseEntity: AuditableEntity
    {
        public int Id { get; set; }
    }
}
