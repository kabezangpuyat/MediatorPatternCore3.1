using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MNV.Mappers;
using MNV.Core.Database;
using MNV.Core.Exceptions;
using MNV.Domain.Constants;
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
            public Query(long ID)
            {
                this.ID = ID;
            }
            public long ID { get; set; }
        }

        #endregion

        #region Handler
        public class GetUserByIdHandler : QueryHandler, IRequestHandler<Query, ICommandQueryResponse>
        {
            public GetUserByIdHandler(IDataContext dataContext,
                IMapper mapper) : base(dataContext, mapper)
            {
            }
            public async Task<ICommandQueryResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = _dataContext.User.Where(x => x.ID == request.ID).AsQueryable();
                if (user is null)
                    throw new DataNoFoundException(ExceptionMessageConstants.DataNotFound);

                var model = user.ToSingleUserViewModel();
                    //_mapper.Map<UserViewModel>(user);
                var result = new GetUserByIdResponse { User = model };

                return await Task.FromResult(result);
            }
        }
        #endregion
    }
}
