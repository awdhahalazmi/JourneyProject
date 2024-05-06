﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Journy.Model
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration, JourneyContext context)
        {
            _configuration = configuration;
            this.context = context;
        }
        private readonly JourneyContext context;


        public (bool IsValid, string Token) GenerateToken(string username, string password)
        {
            var userAccount = context.Users.SingleOrDefault(r => r.Username == username);
            if (userAccount == null)
            {
                return (false, "");
            }
            var validPassword = userAccount.VerifyPassword(password);
            if (!validPassword)
            {
                return (false, "");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

         
            var claims = new[]
    {
            new Claim(TokenClaimsConstant.Username, userAccount.Username),
            new Claim(TokenClaimsConstant.UserId, userAccount.Id.ToString()),
            new Claim(ClaimTypes.Role, userAccount.IsAdmin ? "admin" : "user")
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddYears(30),
                signingCredentials: credentials);
            var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return (true, generatedToken);
        }
    }
}
