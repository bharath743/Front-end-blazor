using FrondEnd.Shared.DTOs;
using FrondEnd.Shared.Models;
using FrontEnd.Api.Contexts;
using FrontEnd.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FrontEnd.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public AuthenticationService(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Response<string>> AuthenticateAsync(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
            if (user == null)
            {
                return new Response<string>("ERROR", "Invalid Credentials");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"], expires: DateTime.Now.AddHours(2), claims: claims,
                signingCredentials: new SigningCredentials(key: signInKey, SecurityAlgorithms.HmacSha256));

            return new Response<string>("SUCCESS", $"{user.Id} is now Connected until {token.ValidTo}!",
                new JwtSecurityTokenHandler().WriteToken(token));

        }

        public Task<Response<UserDTO>> RegisterAsync(UserDTO userDTO)
        {
            throw new NotImplementedException("This method is not available for the moment.");
        }
    }
}
