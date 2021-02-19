using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public long UserID { get; set; }
        public long RoleID { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
