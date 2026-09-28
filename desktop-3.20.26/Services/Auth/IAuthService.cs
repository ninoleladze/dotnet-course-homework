using SocialMedia.Common;
using SocialMedia.DTOs;

namespace SocialMedia.Services.Auth
{
    public interface IAuthService
    {
        Result<int> Register(RegisterDto req);
        Result<string> Login(LoginDto req);
        Result<string> VerifyEmail (VerifyEmailDto req);
        
        Result<int> ForgotPassword (string email);
        Result<int> ResetPassword (ResetPasswordDto req);

    }
}
