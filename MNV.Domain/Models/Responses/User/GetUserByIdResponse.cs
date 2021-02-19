using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Models.Responses.User
{
    public class GetUserByIdResponse : IRequestResponse
    {
        public long ID { get; set; }
        public UserViewModel User { get; set; }
    }
}
