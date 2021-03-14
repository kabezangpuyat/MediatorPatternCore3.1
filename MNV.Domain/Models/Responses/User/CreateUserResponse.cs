using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Models.Responses.User
{
    public class CreateUserResponse : ICommandQueryResponse
    {
        public CreateUserResponse(long id, UserViewModel user)
        {
            ID = id;
            User = user;
        }
        public long ID { get; set; }
        public UserViewModel User { get; set; }
    }
}
