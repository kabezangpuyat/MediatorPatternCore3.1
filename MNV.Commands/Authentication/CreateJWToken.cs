using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MNV.Core.Database;
using MNV.Core.Exceptions;
using MNV.Core.Providers;
using MNV.Core.Services;
using MNV.Domain.Constants;
using MNV.Domain.Models.Authentication;
using MNV.Domain.Models.Responses;
using MNV.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MNV.Commands.Authentication
{
    public static class CreateJWToken
    {
        #region Command
        public class Command : AuthenticationModel, ICommand
        {
            public Command( string username, string password, string ipaddress)
            {
                this.Username = username;
                this.Password = password;
                this.IpAddress = ipaddress;
            }
            public string IpAddress { get; set; }
        }
        #endregion

        #region Handler
        public class Handler : CommandHandler, IRequestHandler<Command, ICommandQueryResponse>
        {
            private readonly IEncryptionService _encryptionService;
            private readonly IAuthenticationService _authenticationService;
            private readonly IMediator _mediator;
            public Handler(IDataContext dataContext, 
                IMapper mapper,               
                IMediator mediator,
                ICurrentUserProvider currentUserProvider,
                IEncryptionService encryptionService,
                IAuthenticationService authenticationService) : base(dataContext, mapper, currentUserProvider)
            {
                this._encryptionService = encryptionService ?? throw new ArgumentException(nameof(encryptionService));
                this._authenticationService = authenticationService ?? throw new ArgumentException(nameof(authenticationService));
                this._mediator = mediator ?? throw new ArgumentException(nameof(mediator));
            }

            public async Task<ICommandQueryResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var encryptedPassword = _encryptionService.Encrypt(request.Password);
                var data = _dataContext.User.Where(x => x.Username == request.Username && x.Password == encryptedPassword);

                if(data == null)
                    throw new DataNoFoundException(ExceptionMessageConstants.DataNotFound);

                var user = data.ToSingleUserViewModel();

                var jwtResponse = _authenticationService.Authenticate(user, request.IpAddress);
                //Create RefreshToken
                await _mediator.Send(new CreateRefreshToken.Command { RefreshTokenModel = jwtResponse.RefreshTokenModel });

                return await Task.FromResult(jwtResponse);
            }

        }
        #endregion
    }
}
