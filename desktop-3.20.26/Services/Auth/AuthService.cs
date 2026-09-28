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
        private readonly IConfiguration _config;
        private readonly SmtpService _smtpService;

        public AuthService(DataContext db, IConfiguration config, SmtpService smtpService)
        {
            _db = db;
            _config = config;
            _smtpService = smtpService;
        }

        public Result<int> ForgotPassword(string email)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return Result<int>.NotFound("user not found");

            Random random = new Random();
            user.VerificationCode = random.Next(100_000, 999_999).ToString();
            _db.SaveChanges();

            _smtpService.SendEmail("Email verfication", $"code : {user.VerificationCode}", user.Email);
            return Result<int>.Ok(user.Id);




        }

        public Result<string> Login(LoginDto req)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == req.Email && !u.IsDeleted);
            if (user == null)
                return Result<string>.BadRequest("Invalid Credentials");

            if(!BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
                return Result<string>.BadRequest("Invalid Credentials");
            if(!user.IsVerified)
                return Result<string>.BadRequest("Email is not verified.");

            string Token = CreateAccessToken(user);

            return Result<string>.Ok(Token);

        }

        public Result<int> Register(RegisterDto req)
        {
            if(string.IsNullOrWhiteSpace(req.FirstName))
                return Result<int>.BadRequest("First name is required.");
            if(string.IsNullOrWhiteSpace(req.LastName))
                return Result<int>.BadRequest("Last name is required.");
            if(string.IsNullOrWhiteSpace(req.Email))
                return Result<int>.BadRequest("Email is required.");
            if(string.IsNullOrWhiteSpace(req.Password))
                return Result<int>.BadRequest("Password is required.");
            if(_db.Users.Any(u => u.Email == req.Email))
                return Result<int>.BadRequest("Email is already in use.");

            Random random = new Random();

            User user = new User
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Email = req.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
                VerificationCode = random.Next(100_000, 999_999).ToString()
            };
            _db.Users.Add(user);
            _db.SaveChanges();

            _smtpService.SendEmail("Email verfication", $"code : {user.VerificationCode}",user.Email);
            return Result<int>.Ok(user.Id);
        }

        public Result<int> ResetPassword(ResetPasswordDto req)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == req.Email);

            if (user == null)
                return Result<int>.NotFound("user not found");
            if(user.VerificationCode != req.Code)
                return Result<int>.BadRequest("verification code is not correct");
            user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);

            user.VerificationCode = null;
             _db.SaveChanges();
            return Result<int>.Ok(user.Id);
        }

        public Result<string> VerifyEmail(VerifyEmailDto req)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == req.Email);
            if (user == null) 
                return Result<string>.NotFound("user not found");
            if(user.VerificationCode != req.Code)
              return Result<string>.BadRequest("verification code is not correct");

            user.IsVerified = true;

            _db.SaveChanges();

            string accessToken = CreateAccessToken(user);
            return Result<string>.Ok(accessToken);


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
