using AutoMapper;
using MediatR;
using MNV.Core.Database;
using MNV.Core.Exceptions;
using MNV.Domain.Constants;
using MNV.Domain.Models.Responses;
using MNV.Domain.Models.Responses.User;
using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MNV.Commands.User
{
    /// <summary>
    /// It handles our Query, handler .Response is in Domain.
    /// We put those three in container for code discoverability purpose.
    /// 
    /// Benefits of using records is its immutable
    /// </summary>
    public static class CreateUser
    {
        #region Command
        public class Command : ICommand
        {
            public UserViewModel UserViewModel { get; set; }
        }
        #endregion

        #region Handler
        public class Handler : CommandHandler, IRequestHandler<Command, ICommandQueryResponse>
        {
            public Handler(IDataContext dataContext, IMapper mapper) : base(dataContext, mapper)
            {
            }
            public async Task<ICommandQueryResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var data = _mapper.Map<Domain.Entities.User>(request);
                _dataContext.User.Add(data);
                await _dataContext.SaveChangesAsync()
                    .ConfigureAwait(false);

                if (data == null)
                    throw new EntityNotCreatedException(ExceptionMessageConstants.ErrorCreatingUser);

                var result = _mapper.Map<UserViewModel>(data);

                return new CreateUserResponse(data.ID, result);
            }
        }
        #endregion
    }
}
