using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
