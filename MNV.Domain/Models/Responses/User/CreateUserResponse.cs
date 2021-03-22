using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Models.Responses.User
{
    public class CreateUserResponse : ICommandQueryResponse
    {
        public CreateUserResponse(UserViewModel user)
        {
            User = user;
        }
        public UserViewModel User { get; set; }
    }
}
