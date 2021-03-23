using Microsoft.AspNetCore.Http;
using MNV.Core.Providers;
using MNV.Domain.Constants;
using MNV.Domain.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Infrastructure.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        #region Constructor(s)
        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor ?? throw new ArgumentException(nameof(httpContextAccessor));
        }
        #endregion

        #region ICurrentUserProvider
        public List<RoleViewModel> GetCurrentRoles()
        {
            List<RoleViewModel> curretnRoles = new List<RoleViewModel>();
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var roleClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimsContants.CurrentRoles);
                if (roleClaim != null)
                    curretnRoles = JsonConvert.DeserializeObject<List<RoleViewModel>>(roleClaim.Value);
            }
            else
                curretnRoles = null;

            return curretnRoles;
        }

        public UserViewModel GetCurrentUser()
        {
            UserViewModel currentUser = new UserViewModel();
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var userClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimsContants.CurrentUser);
                if (userClaim != null)
                    currentUser = JsonConvert.DeserializeObject<UserViewModel>(userClaim.Value);
            }
            else
                currentUser = null;

            return currentUser;
        } 
        #endregion
    }
}
