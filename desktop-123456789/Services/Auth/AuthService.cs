using Microsoft.IdentityModel.Tokens;
using SocialMedia.Common;
using SocialMedia.Data;
using SocialMedia.DTOs;
using SocialMedia.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMedia.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _db;
        private readonly SmtpService _smtp;
        private readonly IConfiguration _config;

        public AuthService(DataContext db, IConfiguration config, SmtpService smtp)
        {
            _db = db;
            _config = config;
            _smtp = smtp;
        }

        public Result<int> Register(RegisterDto req)
        {
            if (string.IsNullOrWhiteSpace(req.FirstName))
                return Result<int>.BadRequest("FirstName is required.");

            if (string.IsNullOrWhiteSpace(req.LastName))
                return Result<int>.BadRequest("LastName is required.");

            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<int>.BadRequest("Email is required.");

            if (string.IsNullOrWhiteSpace(req.Password))
                return Result<int>.BadRequest("Password is required.");

            if (_db.Users.Any(u => u.Email == req.Email))
                return Result<int>.BadRequest("user already exists.");

            Random random = new Random();

            User user = new User()
            {
                Email = req.Email,
                LastName = req.LastName,
                FirstName = req.FirstName,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
                VerificationCode = random.Next(100_000, 999_999).ToString()
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            _smtp.SendEmail("Email verification", $"code: {user.VerificationCode}", user.Email);

            return Result<int>.Ok(user.Id);
        }

        public Result<string> Login(LoginDto req)
        {
            throw new NotImplementedException();
        }
        public Result<string> VerifyEmail(VerifyEmailDto req)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == req.Email);

            if (user == null)
                return Result<string>.NotFound("user not found");

            if (user.VerificationCode != req.Code)
                return Result<string>.BadRequest("verification code is not correct.");

            user.IsVerified = true;

            _db.SaveChanges();

            string accessToken = CreateAccessToken(user);

            return Result<string>.Ok(accessToken);
        }

        public Result<int> ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Result<int> ResetPassword(ResetPasswordDto req)
        {
            throw new NotImplementedException();
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
