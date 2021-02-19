using MediatR;
using MNV.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNV.Queries
{
    public interface IQuery : IRequest<IRequestResponse>
    {
    }
}
