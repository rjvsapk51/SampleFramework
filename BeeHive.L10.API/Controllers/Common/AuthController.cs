using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BeeHive.L10.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserServices _user;
        public AuthController(IUserServices user)
        {
            _user = user;
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
            var claims = new[] 
            {
                new Claim(JwtRegisteredClaimNames.Sub , model.Username),
                new Claim(JwtRegisteredClaimNames.Jti , model.Password),
                new Claim(ClaimTypes.Role,"User")
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecuredKey"));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddHours(10),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256)
                );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token),expiration = token.ValidTo } );
        }
    }
}