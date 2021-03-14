using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Models.Responses.User
{
    public class GetUserByIdResponse : ICommandQueryResponse
    {
        public UserViewModel User { get; set; }
    }
}
