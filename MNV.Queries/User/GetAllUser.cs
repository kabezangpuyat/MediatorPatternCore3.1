using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MNV.Core.Database;
using MNV.Core.Exceptions;
using MNV.Domain.Constants;
using MNV.Domain.Models.Queries;
using MNV.Domain.Models.Responses;
using MNV.Domain.Models.Responses.User;
using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MNV.Queries.User
{
    /// <summary>
    /// It handles our Query, handler except for response.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class GetAllUser
    {
        #region Query
        public class Query : CollectionQuery
        {
            public PagingModel Paging { get; set; }
        }
        #endregion

        #region Handler
        public class GetUserByIdHandler : QueryHandler, IRequestHandler<Query, QueryCollectionResponse>
        {
            public GetUserByIdHandler(IDataContext dataContext,
                IMapper mapper) : base(dataContext, mapper)
            {
            }
            public async Task<QueryCollectionResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = _dataContext.User.AsQueryable();
                if (result is null)
                    throw new DataNoFoundException(ExceptionMessageConstants.DataNotFound);

                if (request.Paging.Page > 0 && request.Paging.PageSize > 0)
                    result = GetPaginated<Domain.Entities.User>(result, request.Paging);

                return await Task.FromResult(new GetAllUserResponse() { Results = result, Total = result.Count() });
            }
        }
        #endregion
    }
}
