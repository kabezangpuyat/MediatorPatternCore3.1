using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MNV.Core.Database;
using MNV.Core.Exceptions;
using MNV.Core.Providers;
using MNV.Domain.Constants;
using MNV.Domain.Models.Queries;
using MNV.Domain.Models.Responses;
using MNV.Domain.Models.Responses.User;
using MNV.Domain.Models.User;
using MNV.Mappers;
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
                IMapper mapper,
                ICurrentUserProvider currentUserProvider) : base(dataContext, mapper, currentUserProvider)
            {
            }
            public async Task<QueryCollectionResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var currentuser = _currentUserProvider.GetCurrentUser();
                var data = _dataContext.User.AsQueryable();
                var count = data.Count();
                if (data is null)
                    throw new DataNoFoundException(ExceptionMessageConstants.DataNotFound);

                if (request.Paging.Page > 0 && request.Paging.PageSize > 0)
                    data = GetPaginated<Domain.Entities.User>(data, request.Paging);

                var result = data.ToUserViewModelQueryable();

                return await Task.FromResult(new GetAllUserResponse() { Results = result, Total = count });
            }
        }
        #endregion
    }
}
