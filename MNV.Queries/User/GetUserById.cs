using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MNV.Core.Database;
using MNV.Core.Exceptions;
using MNV.Domain.Constants;
using MNV.Domain.Models.Responses;
using MNV.Domain.Models.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MNV.Queries.User
{
    /// <summary>
    /// It handles our Query, handler and response.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class GetUserById 
    {
        #region Query
        public class Query : IQuery 
        {
            public long ID { get; set; }
        }

        #endregion

        #region Handler
        public class GetUserByIdHandler : QueryHandler, IRequestHandler<Query, IRequestResponse>
        {
            public GetUserByIdHandler(IDataContext dataContext) : base(dataContext)
            {
            }
            public async Task<IRequestResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _dataContext.User.Where(x => x.ID == request.ID).FirstOrDefaultAsync();
                if (user is null)
                    throw new DataNoFoundException(ExceptionMessageConstants.DataNotFound);

                var result = _mapper.Map<GetUserByIdResponse>(user);
                result.ID = user.ID;

                return result;
            }
        }
        #endregion
    }
}
