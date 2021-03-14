using MediatR;
using MNV.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNV.Commands
{
    public interface ICommand : IRequest<ICommandQueryResponse>
    {
    }
}
