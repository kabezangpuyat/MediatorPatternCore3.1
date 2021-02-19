using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Models.Responses
{
    public class QueryCollectionResponse
    {
        public object Results { get; set; }
        public int Total { get; set; }
    }
}
