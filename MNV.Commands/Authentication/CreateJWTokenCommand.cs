using MNV.Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MNV.Commands.Authentication
{
    public static class CreateJWTokenCommand 
    {
        #region Command
        public class Command : AuthenticationModel, ICommand
        {
            public Command( string username, string password)
            {
                this.Username = username;
                this.Password = password;
            }
        }
        #endregion

        #region Handler

        #endregion

        #region Response

        #endregion
    }
}
