using MNV.Core.Services;
using MNV.Domain.Models.Authentication;
using MNV.Domain.Models.Responses.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Private global method(s)

        #endregion

        #region Constructor(s)
        public AuthenticationService()
        {

        }
        #endregion

        #region IAuthenticationService
        public JWTResponse Authenticate(AuthenticationModel model, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public JWTResponse RefreshToken(string token, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public bool RevokeToken(RevokeTokenModel model)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(ValidateTokenModel model)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
