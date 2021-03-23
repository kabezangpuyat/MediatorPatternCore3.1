using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MNV.Domain.Models.Queries;
using MNV.Domain.Models.User;
using MNV.Queries.User;
using MNV.Commands.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MNV.Domain.Models.Requests;
using Microsoft.AspNetCore.Http;
using MNV.Domain.Models.Authentication;
using MNV.Commands.Authentication;
using MNV.Domain.Models.Responses.Authentication;

namespace MNV.Web.Controllers
{
    public class AccountController : _BaseController
    {
        
        #region Constructor(s)
        public AccountController(IMediator mediator) : base(mediator)
        {
        }
        #endregion


        #region IActionResult(s)

        [HttpPost("authenticate"), AllowAnonymous]
        public async Task<IActionResult> GetAll(AuthenticationModel model)
        {
            var command = new CreateJWToken.Command(model.Username, model.Password, this.IpAddress());
            var response = await _mediator.Send(command) as JWTResponse;

            if (response == null)
                return BadRequest(new { message = "Fail to authenticate user. Please contact your system administrator." });

            this.SetTokenCookie(response.RefreshToken, response.JwtToken, response.ExpiryDate);
            return await ExecuteResult(response).ConfigureAwait(false);
        }

        [AllowAnonymous,
        HttpPost("validatetoken")]
        public IActionResult Validate([FromBody] ValidateTokenModel model)
        {
            bool valid = false;

            var refreshtoken = Request.Cookies["refreshtoken"];
            var expirytoken = Request.Cookies["tokenexpiry"];


            if (!string.IsNullOrEmpty(refreshtoken) || !string.IsNullOrEmpty(expirytoken))
            {
                if (refreshtoken.Trim().ToLower() == model.Token.Trim().ToLower())
                {
                    //if token is 1 minute to expire then tagged is invalid
                    DateTime currentDate = DateTime.Now;
                    var expiry = Convert.ToDateTime(expirytoken);
                    double diffInSeconds = (expiry - currentDate).TotalSeconds;
                    if (diffInSeconds >= 120)
                        valid = true;
                }

            }

            return Ok(new { valid = valid });
        }
        #endregion

        #region Helper Method(s)
        private void SetTokenCookie(string token, string jwttoken, DateTime expiryDate)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expiryDate 
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
            Response.Cookies.Append("jwttoken", jwttoken, cookieOptions);
            Response.Cookies.Append("tokenexpiry", expiryDate.ToString(), cookieOptions);
        }
        private void RemoveSession()
        {
            Response.Cookies.Delete("refreshToken", new CookieOptions() { Secure = true });
            Response.Cookies.Delete("jwttoken", new CookieOptions() { Secure = true });
            Response.Cookies.Delete("tokenexpiry", new CookieOptions() { Secure = true });
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        #endregion
    }
}
