using System;
using ElearningPortal.Models;
using ElearningPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ElearningPortal.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext _dbcontext, IConfiguration configuration)
        {
            _configuration = configuration;
            context = _dbcontext;
        }

        public async Task<string> Login([FromBody] Login authDetails)
        {
            var userFound = await context.Users.FirstOrDefaultAsync(x => x.Email == authDetails.Email);
            if (userFound == null)
            {
                return "User not found";
            }
            else if (userFound.Password != authDetails.Password)
            {
                return "Invalid Email or Password";
            }
            else
            {
                string token = CreateToken(userFound);
                return token;
            }

        }

        private string CreateToken(UserData user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id",""+user.UserId),
                new Claim("UserRole", ""+user.Role),
                new Claim(ClaimTypes.Role, ""+user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


    }

}
