using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Services.Auth;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IAuthService _authService;

        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto req)
        {
            var result = _authService.Register(req);
            return StatusCode(result.Status, result);

        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto req)
        {
            var result = _authService.Login(req);
            return StatusCode(result.Status, result);


        }

        [HttpPut("verify-email")]
        public IActionResult VerifyEmail(VerifyEmailDto req)
        {
            var result = _authService.VerifyEmail(req);
            return StatusCode(result.Status, result);

        }


        [HttpPost("forgot-password/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            var result = _authService.ForgotPassword(email);
            return StatusCode(result.Status, result);
        }

        [HttpPut("reset-password")]
        public IActionResult ResetPassword(ResetPasswordDto req)
        {
            var result = _authService.ResetPassword(req);
            return StatusCode(result.Status, result);

        }




        }
}
