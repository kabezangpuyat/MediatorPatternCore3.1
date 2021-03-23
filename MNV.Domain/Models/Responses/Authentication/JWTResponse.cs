using MNV.Domain.Models.Authentication;
using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MNV.Domain.Models.Responses.Authentication
{
    public class JWTResponse : ICommandQueryResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }
        public DateTime ExpiryDate { get; set; }

        //[JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public RefreshTokenModel RefreshTokenModel { get; set; }

        public JWTResponse(UserViewModel user, string jwtToken, string refreshToken, DateTime expiryDate, RefreshTokenModel refreshModelToken)
        {
            Id = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Email;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
            ExpiryDate = expiryDate;
            RefreshTokenModel = refreshModelToken;
        }
    }
}
