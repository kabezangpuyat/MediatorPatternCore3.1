using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Models.User
{
    public class RoleViewModel
    {
        public long ID { get; set; }
        public Guid Key { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
