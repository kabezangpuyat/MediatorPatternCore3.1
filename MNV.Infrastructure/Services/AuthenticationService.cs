using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MNV.Core.Services;
using MNV.Domain.ConfigSections;
using MNV.Domain.Constants;
using MNV.Domain.Models.Authentication;
using MNV.Domain.Models.Responses.Authentication;
using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MNV.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Private global method(s)
        private readonly string _secret;
        #endregion

        #region Constructor(s)
        public AuthenticationService(IOptions<AppSettings> appSettings)
        {
            this._secret = appSettings.Value?.Secret ?? string.Empty;
        }
        #endregion

        #region IAuthenticationService
        public JWTResponse Authenticate(UserViewModel model, string ipAddress)
        {
            // authentication successful so generate jwt and refresh tokens
            var jwtToken = GenerateJwtToken(model);
            var refreshToken = GenerateRefreshToken(ipAddress);
            refreshToken.AppUserID = model.ID;

            return new JWTResponse(model, jwtToken, refreshToken.Token, refreshToken.Expires, refreshToken);
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

        #region Private method(s)
        private RefreshTokenModel GenerateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshTokenModel
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.Now.AddHours(1),
                    Created = DateTime.Now,
                    CreatedByIp = ipAddress
                };
            }
        }
        private string GenerateJwtToken(UserViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"{user.LastName}, {user.FirstName}"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimsContants.CurrentUser,JsonSerializer.Serialize(user, DefaultSerializerOptions())),
                    new Claim(ClaimsContants.CurrentRoles,JsonSerializer.Serialize(user.Roles, DefaultSerializerOptions()))
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        //private CurrentUser SetCurrentUser(UserViewModel user)
        //{
        //    CurrentUser currentUser = new CurrentUser();
        //    currentUser.FullName = $"{user.LastName}, {user.FirstName}";
        //    currentUser.ID = user.ID;

        //    return currentUser;
        //}
        private JsonSerializerOptions DefaultSerializerOptions() =>
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        #endregion
    }
}
