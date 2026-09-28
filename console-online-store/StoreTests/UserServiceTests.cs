namespace StoreTests;

using StoreBLL.Services;

/// <summary>
/// Verifies <see cref="UserService"/> registration, authentication and profile management.
/// </summary>
public class UserServiceTests
{
    [Fact]
    public void Authenticate_SeededAdminWithBlankPassword_Succeeds()
    {
        using var context = TestDbContextFactory.Create();
        var service = new UserService(context);

        var result = service.Authenticate("admin", string.Empty);

        Assert.NotNull(result);
        Assert.Equal("admin", result!.Login);
    }

    [Fact]
    public void Authenticate_WrongPassword_ReturnsNull()
    {
        using var context = TestDbContextFactory.Create();
        var service = new UserService(context);

        var result = service.Authenticate("admin", "not-the-password");

        Assert.Null(result);
    }

    [Fact]
    public void Authenticate_UnknownLogin_ReturnsNull()
    {
        using var context = TestDbContextFactory.Create();
        var service = new UserService(context);

        var result = service.Authenticate("nobody", "whatever");

        Assert.Null(result);
    }

    [Fact]
    public void Register_NewLogin_CanThenAuthenticate()
    {
        using var context = TestDbContextFactory.Create();
        var service = new UserService(context);

        var registered = service.Register("Jane", "Smith", "jsmith", "secret123");
        var authenticated = service.Authenticate("jsmith", "secret123");

        Assert.NotNull(authenticated);
        Assert.Equal(registered.Id, authenticated!.Id);
    }

    [Fact]
    public void Register_PasswordIsNeverStoredAsPlainText()
    {
        using var context = TestDbContextFactory.Create();
        var service = new UserService(context);

        service.Register("Jane", "Smith", "jsmith", "secret123");
        var raw = context.Users.Single(u => u.Login == "jsmith");

        Assert.NotEqual("secret123", raw.Password);
    }

    [Fact]
    public void Register_DuplicateLogin_Throws()
    {
        using var context = TestDbContextFactory.Create();
        var service = new UserService(context);
        service.Register("Jane", "Smith", "jsmith", "secret123");

        Assert.Throws<InvalidOperationException>(() => service.Register("Someone", "Else", "jsmith", "whatever"));
    }

    [Fact]
    public void Register_NewUsersGetTheRegisteredRole()
    {
        using var context = TestDbContextFactory.Create();
        var service = new UserService(context);

        var registered = service.Register("Jane", "Smith", "jsmith", "secret123");

        Assert.Equal(2, registered.RoleId);
    }
}
