using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class JwtService : IJwtService
    {
        public JwtService()
        {

        }

        public string GenerateToken(User user)
        {
            var secretKey = Environment.GetEnvironmentVariable("Secret");
            var expriresIn = Environment.GetEnvironmentVariable("ExpiresIn");
            var issuer = Environment.GetEnvironmentVariable("ValidIssuer");
            var audienceValue = Environment.GetEnvironmentVariable("ValidAudience");
            int itEpires = Convert.ToInt16(expriresIn);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()), // jti = UserId
            new Claim("tokenVersion", user.TokenVersion),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.EmailAddress)
        };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audienceValue,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(itEpires),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

