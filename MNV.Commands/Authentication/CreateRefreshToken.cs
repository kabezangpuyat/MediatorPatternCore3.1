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
using MNV.Domain.Models.Responses.Authentication;
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
    public static class CreateRefreshToken
    {
        #region Command
        public class Command : ICommand
        {
           public RefreshTokenModel RefreshTokenModel { get; set; }
        }
        #endregion

        #region Handler
        public class Handler : CommandHandler, IRequestHandler<Command, ICommandQueryResponse>
        {
            private readonly IEncryptionService _encryptionService;
            private readonly IAuthenticationService _authenticationService;
            public Handler(IDataContext dataContext, 
                IMapper mapper,
                ICurrentUserProvider currentUserProvider,
                IEncryptionService encryptionService,
                IAuthenticationService authenticationService) : base(dataContext, mapper, currentUserProvider)
            {
                this._encryptionService = encryptionService ?? throw new ArgumentException(nameof(encryptionService));
                this._authenticationService = authenticationService ?? throw new ArgumentException(nameof(authenticationService));
            }

            public async Task<ICommandQueryResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var data = new Domain.Entities.RefreshToken
                {
                    UserID = request.RefreshTokenModel.AppUserID,
                    Token = request.RefreshTokenModel.Token,
                    Expires = request.RefreshTokenModel.Expires,
                    Created = request.RefreshTokenModel.Created,
                    CreatedByIp = request.RefreshTokenModel.CreatedByIp,
                    Revoked = request.RefreshTokenModel.Revoked,
                    RevokedByIp = request.RefreshTokenModel.RevokedByIp,
                    ReplacedByToken = request.RefreshTokenModel.ReplacedByToken
                };
                _dataContext.RefreshToken.Add(data);
                await _dataContext.SaveChangesAsync();

                return new CreateRefreshTokenResponse(request.RefreshTokenModel);
            }

        }
        #endregion
    }
}
