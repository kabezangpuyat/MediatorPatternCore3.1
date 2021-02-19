using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNV.Core.Exceptions
{
    [Serializable]
    public class EntityNotCreatedException : Exception
    {
        public EntityNotCreatedException() { }
        public EntityNotCreatedException(string message) : base(message) { }
    }
}
