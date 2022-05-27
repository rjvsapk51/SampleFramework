using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL20.Model.Common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive.L10.API.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IRefreshTokenService _token;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public TokenGenerator(IRefreshTokenService token)
        {
            _token = token;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public AuthenticationModel GenerateToken(HopperModel user)
        {
            var claims = new[]
           {
                new Claim("Id",user.Id.ToString()),
                new Claim(ClaimTypes.Role,"User")
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyTokenGenerator"));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddMinutes(30),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
            AuthenticationModel auth = new AuthenticationModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo, 
            };
            return auth;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public RefreshToken GenerateRefereshToken(long userId)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyRefreshTokengenerator"));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
            RefreshToken refreshToken = new RefreshToken
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
            };
            RefreshTokenModel tokenDB = new RefreshTokenModel { HopperId = userId, RefreshToken = refreshToken.AccessToken };
            _token.Create(tokenDB);
            return refreshToken;
        }

        public bool ValidateRefreshToken(string token)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyRefreshTokengenerator")),
                ValidIssuer = "http://oec.com",
                ValidAudience = "http://oec.com",
                ValidateIssuer = true,
                ValidateAudience = true,
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
