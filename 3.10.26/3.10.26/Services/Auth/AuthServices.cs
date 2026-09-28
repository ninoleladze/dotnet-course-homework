using _3._10._26.Common;
using _3._10._26.Data;
using _3._10._26.DTOs;
using _3._10._26.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _3._10._26.Services.Auth
{
    public class AuthServices : IAuthServices
    {
        private DataContext _dc;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly SymmetricSecurityKey _key;

        public AuthServices(DataContext dc, IConfiguration config)
        {
            _dc = dc;
            _issuer = config["Jwt:Issuer"]!;
            _audience = config["Jwt:Audience"]!;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        }



        public Result<int> Register(RegisterDto req)
        {
            if(string.IsNullOrWhiteSpace(req.Name))
                return Result<int>.BadRequest("Name is required");
            if(string.IsNullOrWhiteSpace(req.Email))
                return Result<int>.BadRequest("Email is required");
            if(string.IsNullOrWhiteSpace(req.Password))
                return Result<int>.BadRequest("Password is required");
            if(_dc.Users.Any(u => u.Email == req.Email))
                return Result<int>.BadRequest("Email already exists");

            User user = new User
            {
                Name = req.Name,
                Email = req.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
            };
            _dc.Users.Add(user);
            _dc.SaveChanges();

            return Result<int>.Ok(user.Id);
        }

        public Result<string> Login(LoginDto req)
        {
            var user = _dc.Users.FirstOrDefault(u => u.Email == req.Email);
            if (user == null)
                return Result<string>.BadRequest("Invalid credentials");

            if(!BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
                return Result<string>.BadRequest("Invalid credentials");

            var token = CreateAccessToken(user);
            return Result<string>.Ok(token);
        }


        private string CreateAccessToken(User user)
        {
            var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.Name),
            new (ClaimTypes.Email, user.Email),

        }
            ;
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
