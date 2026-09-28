namespace Amazon.Services.Users
{
    internal interface IUserServices
    {
        void Register();
        void Login();
        void Logout();
        void ShowProfile();
    }
}
