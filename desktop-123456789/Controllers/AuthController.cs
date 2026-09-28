using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Services.Auth;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth) => _auth = auth;

        [HttpPost("register")]
        public IActionResult Register(RegisterDto req)
        {
            var result = _auth.Register(req);

            return StatusCode(result.Status, result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto req)
        {
            var result = _auth.Login(req);

            return StatusCode(result.Status, result);
        }

        [HttpPut("verify-email")]
        public IActionResult Verify(VerifyEmailDto req)
        {
            var result = _auth.VerifyEmail(req);

            return StatusCode(result.Status, result);
        }

        [HttpPost("forgot-password/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            var result = _auth.ForgotPassword(email);

            return StatusCode(result.Status, result);
        }

        [HttpPut("reset-password")]
        public IActionResult ResetPassword(ResetPasswordDto req)
        {
            var result = _auth.ResetPassword(req);

            return StatusCode(result.Status, result);
        }
    }
}
