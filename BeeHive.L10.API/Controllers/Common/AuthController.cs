using BeeHive.L10.API.Authentication;
using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BeeHive.L10.API.Controllers
{
    /// <summary>
    /// Authentications
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserServices _user;
        ITokenGenerator _tokenGenerator;
        private readonly IRefreshTokenService _token;
        /// <summary>
        /// Authentications
        /// </summary>
        /// <param name="user"></param>
        /// <param name="tokenGenerator"></param>
        /// <param name="token"></param>
        public AuthController(IUserServices user,ITokenGenerator tokenGenerator, IRefreshTokenService token)
        {
            _user = user;
            _tokenGenerator = tokenGenerator;
            _token = token;
        }
        /// <summary>
        /// Username and password are excepted
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            HopperModel user = _user.GetUserByUserNameAndPassword(model);
            if (user == null) return Unauthorized("Invalid username and/or password.");
            AuthenticationModel auth = _tokenGenerator.GenerateToken(user);
            auth.Username = user.Identity;
            RefreshToken refreshToken = _tokenGenerator.GenerateRefereshToken(user.Id);
            Response.Cookies.Append("X-Refresh-Token", refreshToken.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None,Expires= refreshToken.Expiration,Secure=true });
            return Ok(auth );
        }
        /// <summary>
        /// Get Refresh Token
        /// </summary>
        /// <returns></returns>
        [Route("refreshtoken")]
        [HttpGet]
        public IActionResult RefreshToken()
        {
            string refreshToken = Request.Cookies["X-Refresh-Token"];
            //Check if refresh token exists
            RefreshTokenModel refreshTokenModel = _token.GetByRefreshToken(refreshToken);
            if (refreshToken == null)     
                return BadRequest("Session Expired");
            //Check if User Exists.
            HopperModel user =_user.GetById(refreshTokenModel.HopperId);
            if (user == null)
                return BadRequest("User not found.");
            //Check if validation token is valid.
            if (!_tokenGenerator.ValidateRefreshToken(refreshToken))
                return BadRequest("Valifdation failed.");

            _token.Delete(refreshTokenModel.Id);
            AuthenticationModel auth = _tokenGenerator.GenerateToken(user);
            auth.Username = user.Identity;
            RefreshToken refreshedToken = _tokenGenerator.GenerateRefereshToken(user.Id);
            Response.Cookies.Append("X-Refresh-Token", refreshedToken.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None,Expires= refreshedToken.Expiration,Secure=true });
            return Ok(auth);

        }
        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("logout")]
        public IActionResult LogOut()
        {
            string refreshToken = Request.Cookies["X-Refresh-Token"];
            //Check if refresh token exists
            RefreshTokenModel refreshTokenModel = _token.GetByRefreshToken(refreshToken);
          if(refreshTokenModel!= null)
            {
                //Check if User Exists.
                HopperModel user = _user.GetById(refreshTokenModel.HopperId);
                //delete token from backend
                _token.Delete(refreshTokenModel.Id);
            }        
            //delete cookie
            Response.Cookies.Append("X-Refresh-Token", "", new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None, Expires = DateTime.Now.AddDays(-1), Secure = true });
            return Ok("You are logged out sucessfully.");
        }
    }
}