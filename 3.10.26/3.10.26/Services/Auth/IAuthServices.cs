using _3._10._26.Common;
using _3._10._26.DTOs;

namespace _3._10._26.Services.Auth
{
    public interface IAuthServices
    {
        Result<int> Register(RegisterDto req);
        Result<string> Login(LoginDto req);


    }
}
