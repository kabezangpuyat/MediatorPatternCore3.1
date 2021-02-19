using MediatR;
using MNV.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Queries
{
    public class CollectionQuery : IRequest<QueryCollectionResponse>
    {
    }
}
