using AutoMapper;
using MediatR;
using MNV.Core.Database;
using MNV.Core.Exceptions;
using MNV.Core.Services;
using MNV.Domain.Constants;
using MNV.Domain.Models.Requests;
using MNV.Domain.Models.Responses;
using MNV.Domain.Models.Responses.User;
using MNV.Mappers;
using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MNV.Core.Providers;

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
            public CreateUserRequest CreateUserRequest { get; set; }
        }
        #endregion

        #region Handler
        public class Handler : CommandHandler, IRequestHandler<Command, ICommandQueryResponse>
        {
            #region Private global variable(s)
            private readonly IEncryptionService _enryptionService;
            #endregion
            public Handler(IDataContext dataContext,
                IMapper mapper,
                ICurrentUserProvider currentUserProvider,
                IEncryptionService enctryptionService) : base(dataContext, mapper, currentUserProvider)
            {
                this._enryptionService = enctryptionService ?? throw new ArgumentNullException(nameof(enctryptionService));
            }
            public async Task<ICommandQueryResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentuser = _currentUserProvider.GetCurrentUser();
                request.CreateUserRequest.Password = _enryptionService.Encrypt(request.CreateUserRequest.Password);
                var data = _mapper.Map<Domain.Entities.User>(request.CreateUserRequest);
                data.CreatedByID = currentuser.ID;

                _dataContext.User.Add(data);
                await _dataContext.SaveChangesAsync()
                    .ConfigureAwait(false);

                if (data == null)
                    throw new EntityNotCreatedException(ExceptionMessageConstants.ErrorCreatingUser);

                //create user role
                var userRole = new Domain.Entities.UserRole { UserID = data.ID, RoleID = request.CreateUserRequest.RoleId, CreatedByID = currentuser.ID };
                _dataContext.UserRole.Add(userRole);
                await _dataContext.SaveChangesAsync();

                if(userRole == null)
                    throw new EntityNotCreatedException(ExceptionMessageConstants.ErrorCreatingUserRole);

                var result = _dataContext.User.Where(x=>x.ID==data.ID).ToSingleUserViewModel();
                
                return new CreateUserResponse(result);
            }
        }
        #endregion
    }
}
