using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNV.Core.Exceptions
{
    [Serializable]
    public class DataNoFoundException : Exception
    {
        public DataNoFoundException() { }
        public DataNoFoundException(string message) : base(message) { }
    }
}
