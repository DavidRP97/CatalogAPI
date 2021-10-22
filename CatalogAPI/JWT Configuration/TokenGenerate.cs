using CatalogAPI.DTOs;
using CatalogAPI.JWT_Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI.JWT_Configuration
{
    public class TokenGenerate : ITokenGenerate
    {
        private readonly IConfiguration _configuration;
        public TokenGenerate(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        UserToken ITokenGenerate.UserTokenGenerate(UserLoginDTO user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = _configuration["TokenConfiguration:ExpireHours"];
            var expirationTime = DateTime.UtcNow.AddHours(double.Parse(expiration));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expirationTime,
                signingCredentials: credentials);

            return new UserToken()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expirationTime,
                Message = "Token JWT OK"
            };
        }
    }
}
