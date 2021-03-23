using MNV.Domain.Models.Authentication;
using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MNV.Domain.Models.Responses.Authentication
{
    public class CreateRefreshTokenResponse : ICommandQueryResponse
    {
        public RefreshTokenModel RefreshToken { get; set; }
        public CreateRefreshTokenResponse(RefreshTokenModel refreshToken)
        {
            this.RefreshToken = refreshToken;
        }
    }
}
