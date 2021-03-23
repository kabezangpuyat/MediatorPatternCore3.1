using MNV.Domain.Models.Responses.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using MNV.Domain.Models;
using MNV.Domain.Models.Authentication;
using MNV.Domain.Models.User;

namespace MNV.Core.Services
{
    public interface IAuthenticationService
    {
        JWTResponse Authenticate(UserViewModel model, string ipAddress);
        JWTResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(RevokeTokenModel model);
        bool ValidateToken(ValidateTokenModel model);
    }
}
