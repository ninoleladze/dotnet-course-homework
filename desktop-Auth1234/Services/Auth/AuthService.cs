using Microsoft.IdentityModel.Tokens;
using SocialMedia.Data;
using SocialMedia.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMedia.Services.Auth
{
    public class AuthService : IAuthService
    {
        private DataContext _db;
        private IConfiguration _config;

        public AuthService(DataContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        private string CreateAccessToken(User user)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var claims = new List<Claim>
            {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, $"${user.FirstName} ${user.LastName}"),
            new (ClaimTypes.Email, user.Email),
            new ("firstName", user.FirstName),
            new ("lastName", user.LastName),
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
