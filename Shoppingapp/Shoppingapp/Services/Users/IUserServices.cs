using ShoppingApp.Models;

namespace ShoppingApp.Services.Users
{
    public interface IUserServices
    {
        void Register();
        void Login();
        void Logout();
        void ShowProfile();

        // parameterized helpers for testing
        void Register(string username, string email, string password);
        User? Login(string username, string password);
    }
}