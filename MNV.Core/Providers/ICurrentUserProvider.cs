using MNV.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Core.Providers
{
    public interface ICurrentUserProvider
    {
        UserViewModel GetCurrentUser();
        List<RoleViewModel> GetCurrentRoles();
    }
}
