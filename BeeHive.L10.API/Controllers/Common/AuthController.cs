using BeeHive.L10.API.Authentication;
using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            auth.RefreshToken = _tokenGenerator.GenerateRefereshToken(user.Id);
            Response.Cookies.Append("X-Refresh-Token", auth.RefreshToken.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
            return Ok(auth );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshTokenRequest"></param>
        /// <returns></returns>
        [Route("refreshtoken")]
        [HttpPost]
        public IActionResult RefreshToken(RefreshTokenRequestModel refreshTokenRequest)
        {
            //Check if refresh token exists
            RefreshTokenModel refreshToken = _token.GetByRefreshToken(refreshTokenRequest.Token);
            if (refreshToken == null)     
                return BadRequest();
            //Check if User Exists.
            HopperModel user =_user.GetById(refreshToken.HopperId);
            if (user == null)
                return BadRequest("User not found.");
            //Check if validation token is valid.
            if (!_tokenGenerator.ValidateRefreshToken(refreshTokenRequest.Token))
                return BadRequest("Valifdation failed.");

            _token.Delete(refreshToken.Id);
            AuthenticationModel auth = _tokenGenerator.GenerateToken(user);
            auth.RefreshToken = _tokenGenerator.GenerateRefereshToken(user.Id);
            Response.Cookies.Append("X-Refresh-Token", auth.RefreshToken.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
            return Ok(auth);

        }
    }
}